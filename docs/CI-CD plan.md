# CI/CD Plan

## Goals
- Provide consistent validation for the ASP.NET API, Angular client, and PostgreSQL schema on every pull request.
- Automate production deployments to the existing AWS Elastic Beanstalk environment with traceable artifacts.
- Include database migration, frontend asset packaging, and smoke testing to ensure end-to-end integrity.

## Workflow Summary
- Maintain two GitHub Actions workflows: `ci.yml` (pull requests) and `deploy.yml` (protected branches such as `main` and release tags).
- Run all jobs on Ubuntu runners, pinning the .NET SDK via `global.json` and Node.js via `.nvmrc`/package metadata.
- Use GitHub secrets for AWS IAM access keys, Elastic Beanstalk identifiers, connection strings, and environment-specific values; expose them only in jobs that require them.
- Cache NuGet packages, Node modules, and other build artifacts to accelerate repeated runs.

## `ci.yml` – Pull Request Validation
### Jobs
- **api-build-test**
  - `actions/checkout@v5` followed by `actions/setup-dotnet@v4`.
  - Restore, build (`dotnet build -tl`), and test (`dotnet test --filter "FullyQualifiedName!~AcceptanceTests"`).
  - Publish test results and MSBuild binary logs on failure.
- **client-build-test**
  - `actions/setup-node@v4` with caching.
  - `npm ci`, `npm run lint`, unit tests (`npm run test -- --watch=false --browsers=ChromeHeadless`), and `npm run build -- --configuration production`.
- **db-validate** (optional but recommended)
  - Launches a disposable PostgreSQL service container.
  - Runs EF Core migration compilation or database schema validation (e.g., `dotnet ef migrations bundle`, `psql` dry-run scripts).

### Behaviour
- Jobs run in parallel when independent; deploy workflows are blocked until all succeed.
- Artifacts such as Angular `dist/`, EF migration bundles, and coverage reports are uploaded for downstream inspection.

## `deploy.yml` – Production Deployment
### Triggers & Gates
- Trigger on pushes to `main` and release tags; require status checks and environment approval (`environment: production`).
- Reuse the same build/test steps or download artifacts from the CI workflow to guarantee reproducible inputs.

### Jobs
1. **build** (needs previous CI success if artifacts are reused)
   - Executes API build/test and Angular production build.
   - Publishes app with `dotnet publish src/Web/Web.csproj -c Release -r linux-x64 --self-contained false -o publish/`.
   - Copies Angular output into `publish/wwwroot`.
   - Packages static assets, configs (`appsettings.*`), and binaries into `publish/`.
2. **db-migrate**
   - Uses stored DB credentials (`DB_HOST`, `DB_NAME`, etc.).
   - Runs EF Core migrations or SQL scripts against the live PostgreSQL instance.
   - Captures logs; fails fast on migration errors.
3. **deploy** (needs: build, db-migrate)
   - Zips `publish/` into `app.zip`.
   - Installs AWS CLI/EB CLI.
   - Creates a new Elastic Beanstalk application version (`aws elasticbeanstalk create-application-version`).
   - Updates the environment (`aws elasticbeanstalk update-environment`) to the new version.
   - Stores bundle label with timestamp/Git SHA for traceability.
4. **post-deploy-smoke** (needs: deploy)
   - Hits API health endpoint (`/healthz`) and key routes via `curl` or lightweight integration tests.
   - Optionally runs Angular e2e smoke tests (`npm run e2e -- --base-url=https://<env>`).
   - Verifies DB connectivity via a simple query.
   - On failure, triggers rollback to the previous Beanstalk version and surfaces logs.

## Secrets & Configuration Management
- Store all sensitive values in GitHub Secrets: `AWS_ACCESS_KEY_ID`, `AWS_SECRET_ACCESS_KEY`, `AWS_REGION`, `EB_APP_NAME`, `EB_ENV_NAME`, `DB_*`, `ASPNETCORE_ENVIRONMENT`, and Angular API endpoints.
- Use step-level environment exports rather than repository environment variables to limit exposure.
- For Angular configurations, prefer build-time replacement using environment files fetched from secrets or API-driven configuration.

## Observability, Rollback, and Notifications
- After deployment, request Elastic Beanstalk environment logs (`aws elasticbeanstalk request-environment-info` / `retrieve-environment-info`) when failures occur.
- Send success/failure notifications (Slack, email, etc.) as part of the final job.
- Retain the last N application versions and document the rollback command (`aws elasticbeanstalk update-environment --version-label <previous>`).

## Open Items / Assumptions
- Elastic Beanstalk application and environment already exist with correct platform (ASP.NET Core on Linux) and IAM instance profile.
- EF Core migrations are the authoritative schema mechanism; adjust steps if raw SQL scripts are preferred.
- Define exact SDK versions in `global.json` and `.nvmrc` to keep runner toolchains consistent.
- Update Angular tests or smoke suites to be fast and reliable for pipeline use.
