Architecture Overview

Flow: Browser → (optional) Route 53 DNS → Security Group exposing 80/443 → Single Amazon Linux 2023 EC2 (t4g.small) running Nginx for TLS offload and reverse proxy → systemd-hosted Kestrel serving the ASP.NET + Angular bundle (UseStaticFiles + SPA fallback, src/Web/Program.cs:26 and src/Web/Program.cs:36) → Local PostgreSQL 15 on the same instance with nightly pg_dump uploads to an S3 Standard bucket; CloudWatch Agent ships basic host metrics and logs.
AWS Services

Amazon EC2 t4g.small (or t3.micro while on Free Tier) to host the monolithic web/API runtime and Angular static assets built during publish (Directory.Build.props:4, src/Web/Web.csproj:79).
gp3 EBS volume (~30 GiB) for OS, application files, and PostgreSQL data.
Amazon S3 Standard bucket for versioned pg_dump archives kept lean with lifecycle rules.
CloudWatch Agent + Logs for CPU/disk/memory metrics and log rotation (mostly Free Tier).
IAM instance profile granting scoped S3 (backup) and CloudWatch permissions.
Elastic IP so the host keeps a stable address (free while attached) plus optional Route 53 hosted zone for DNS.
Rationale

The solution targets .NET 9.0 and runs as a single ASP.NET app that already serves Angular assets from wwwroot, so co-locating frontend and backend on one host keeps deployment simple and cheap (Directory.Build.props:4, src/Web/Program.cs:26, src/Web/Program.cs:36, src/Web/Web.csproj:79).
EF Core is wired to PostgreSQL via Npgsql with no other infrastructure dependencies, making a local PostgreSQL service the lowest-cost fit (src/Infrastructure/DependencyInjection.cs:29, src/Web/appsettings.Development.json:3).
The app is stateless aside from the database, exposes a health check at /health, and has no background workers, so a single instance with systemd supervision is sufficient (src/Web/Program.cs:24).
Database seeding/reset logic runs only in Development; production will rely on a one-time schema creation/migration step (src/Infrastructure/Data/ApplicationDbContextInitialiser.cs:14, src/Infrastructure/Data/ApplicationDbContextInitialiser.cs:51).
Angular 20 dependencies are compiled during publish, letting the runtime stay lean without Node.js once deployed (src/Web/ClientApp/package.json:17, src/Web/Web.csproj:79).
Optional upgrade path: if managed backups or patching become a need, migrating to RDS PostgreSQL (db.t4g.micro) is straightforward but adds ~$24/month; keeping it local now avoids that fixed cost.
Cost Estimate

Service/Assumption                     Est. Monthly Cost (USD)
EC2 t4g.small on-demand (730 h)        ~12.30   (t3.micro ≈ $0 with Free Tier headroom but tight on RAM)
30 GiB gp3 EBS (3,000 IOPS baseline)   ~ 2.70
S3 Standard backups (5 GiB, 10k PUT)   ~ 0.15
Data transfer out (50 GiB)             ~ 4.50   (pay only what you use)
CloudWatch Logs/metrics (1 GiB logs)   ~ 1.50   (often within Free Tier)
Elastic IP attached                    0.00
----------------------------------------------
Estimated monthly total                ≈ 21.15
Add ~$24 more if you later adopt RDS db.t4g.micro with 20 GiB storage.

Deployment Plan

Step 1: On your workstation run dotnet publish src/Web/Web.csproj -c Release -o publish to generate the self-contained output with Angular assets (src/Web/Web.csproj:79).
Step 2: Provision an EC2 t4g.small (or t3.micro if testing) in the preferred region using Amazon Linux 2023, attach a 30 GiB gp3 volume, assign an IAM role with S3/CloudWatch access, and attach/allocate an Elastic IP.
Step 3: Harden the security group: allow 22 only from your IP, keep 80/443 open to the world, and block all other inbound ports.
Step 4: SSH in, update packages, install .NET 9 runtime, Nginx, PostgreSQL 15, AWS CLI, and (optionally) certbot for Let’s Encrypt.
Step 5: Create PostgreSQL role and database (createdb LeoLMSDb), adjust postgresql.conf to listen only on localhost, and restrict pg_hba.conf to local connections.
Step 6: Copy the publish folder to /var/www/leolms, set ConnectionStrings__LeoLMSDb (pointing to Host=localhost;Port=5432;...), ASPNETCORE_ENVIRONMENT=Production, and ASPNETCORE_URLS=http://127.0.0.1:5000 as systemd environment overrides.
Step 7: Define a systemd unit running dotnet LeoLMS.Web.dll from the publish directory, enable Restart=always, and start the service.
Step 8: Configure Nginx to terminate TLS on 443 and proxy to http://127.0.0.1:5000, obtain a Let’s Encrypt certificate, and redirect HTTP → HTTPS.
Step 9: Run initial EF Core migration/SQL script once (generate migrations locally first) so the production database schema matches the model — avoid running the dev-only initializer.
Step 10: Set up cron (or systemd timer) executing pg_dump nightly to /var/backups and sync to S3 (aws s3 cp), and enable a CloudWatch Agent config for host metrics/log forwarding.
Step 11: Test /health and basic user flows, snapshot the EBS volume with Data Lifecycle Manager, and document the simple restore steps.
Security Basics

Lock down SSH to your IP, disable password auth, and rotate EC2 key pairs; optionally enable AWS Systems Manager Session Manager to avoid exposing port 22.
Keep PostgreSQL bound to localhost with a dedicated OS user, enforce strong passwords, and disallow superuser logins from the app role.
Use Let’s Encrypt auto-renewal (or manual ACM+Nginx certificate import) for TLS, and redirect all traffic to HTTPS.
Store secrets in .env files owned by root or, better, Systems Manager Parameter Store (Standard tier is free) and load them into systemd via EnvironmentFile.
Run dnf upgrade monthly (or automate with cron) and watch CloudWatch alarms for CPU, disk, or failed backups; enable email alerts via SNS only when needed to avoid extra cost.
If you want to iterate further, consider: 1) moving PostgreSQL to RDS when uptime requirements grow, 2) layering CloudWatch alarms + SNS for specific metrics, or 3) adding a lightweight GitHub Actions build that zips the publish output for easier uploads.

