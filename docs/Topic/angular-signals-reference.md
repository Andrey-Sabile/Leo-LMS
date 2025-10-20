### Angular Signals for Reactive State Management

Source: https://context7.com/context7/angular_dev/llms.txt

Implements a counter component using Angular Signals for reactive state management. It utilizes writable signals for state, computed signals for derived values, and effects for side effects that react to state changes. Includes methods to increment, decrement, and reset the count.

```typescript
import { Component, signal, computed, effect } from '@angular/core';

@Component({
  selector: 'app-counter',
  standalone: true,
  template: `
    <div>
      <h2>Count: {{ count() }}</h2>
      <h3>Double: {{ doubleCount() }}</h3>
      <button (click)="increment()">Increment</button>
      <button (click)="decrement()">Decrement</button>
      <button (click)="reset()">Reset</button>
    </div>
  `
})
export class CounterComponent {
  // Create a writable signal
  count = signal(0);

  // Create a computed signal that derives from count
  doubleCount = computed(() => this.count() * 2);

  constructor() {
    // Create an effect that runs whenever count changes
    effect(() => {
      console.log(`Count changed to: ${this.count()}`);
      if (this.count() > 10) {
        console.warn('Count is getting high!');
      }
    });
  }

  increment() {
    this.count.update(value => value + 1);
  }

  decrement() {
    this.count.update(value => value - 1);
  }

  reset() {
    this.count.set(0);
  }
}
```

--------------------------------

### Angular Custom Directives for Enhanced Templating (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Illustrates the creation of custom attribute and structural directives in Angular. The attribute directive 'appHighlight' changes the background color on hover, while the structural directive 'appUnless' conditionally renders an element. Both are implemented as standalone directives and shown with usage examples.

```typescript
import { Directive, ElementRef, HostListener, Input, TemplateRef, ViewContainerRef } from '@angular/core';

// Attribute directive
@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {
  @Input() appHighlight = 'yellow';
  @Input() defaultColor = 'transparent';

  constructor(private el: ElementRef) {}

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight(this.appHighlight);
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight(this.defaultColor);
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }
}

// Structural directive
@Directive({
  selector: '[appUnless]',
  standalone: true
})
export class UnlessDirective {
  private hasView = false;

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef
  ) {}

  @Input() set appUnless(condition: boolean) {
    if (!condition && !this.hasView) {
      this.viewContainer.createEmbeddedView(this.templateRef);
      this.hasView = true;
    } else if (condition && this.hasView) {
      this.viewContainer.clear();
      this.hasView = false;
    }
  }
}

// Usage in component
@Component({
  selector: 'app-directive-demo',
  standalone: true,
  imports: [HighlightDirective, UnlessDirective, CommonModule],
  template: `
    <p appHighlight="lightblue">Hover over me!</p>
    <p appHighlight>Hover for default yellow</p>

    <button (click)="show = !show">Toggle</button>
    <p *appUnless="show">This is shown when show is false</p>
  `
})
export class DirectiveDemoComponent {
  show = true;
}

```

--------------------------------

### Implement Lazy Loading with @defer in Angular (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates using Angular's declarative deferred loading syntax (`@defer`) to split templates into lazy-loadable chunks. This improves initial load performance by deferring the rendering of certain components based on triggers like viewport visibility, hover, idle time, specific conditions, or timers. It supports placeholders, loading indicators, and error handling.

```typescript
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>Dashboard</h1>

    <!-- Load immediately -->
    <div class="header">
      <p>This loads right away</p>
    </div>

    <!-- Defer loading until user scrolls to this section -->
    @defer (on viewport) {
      <app-analytics-chart />
    } @placeholder {
      <div class="placeholder">Chart loading...</div>
    } @loading (minimum 500ms) {
      <div class="spinner">Loading chart data...</div>
    } @error {
      <div class="error">Failed to load chart</div>
    }

    <!-- Defer loading until user hovers -->
    @defer (on hover) {
      <app-user-profile />
    } @placeholder {
      <div>Hover to load profile</div>
    }

    <!-- Defer loading after idle time -->
    @defer (on idle) {
      <app-recommendations />
    }

    <!-- Defer loading when condition is met -->
    @defer (when dataLoaded) {
      <app-data-table [data]="tableData" />
    } @placeholder {
      <p>Waiting for data...</p>
    }

    <!-- Defer with timer -->
    @defer (on timer(2000ms)) {
      <app-notifications />
    }
  `
})
export class DashboardComponent {
  dataLoaded = false;
  tableData: any[] = [];

  ngOnInit() {
    // Simulate data loading
    setTimeout(() => {
      this.tableData = [/* data */];
      this.dataLoaded = true;
    }, 3000);
  }
}

```

--------------------------------

### Angular HTTP Client for API Requests (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates how to make various HTTP requests (GET, POST, PUT, DELETE) using Angular's HttpClient module. Includes examples for typed responses, query parameters, request headers, error handling withrxjs operators like retry and catchError, and usage within a component.

```typescript
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';

interface User {
  id: number;
  name: string;
  email: string;
}

interface Post {
  id: number;
  userId: number;
  title: string;
  body: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://jsonplaceholder.typicode.com';

  constructor(private http: HttpClient) {}

  // GET request with typed response
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/users`)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  // GET request with query parameters
  getUserPosts(userId: number): Observable<Post[]> {
    const params = new HttpParams()
      .set('userId', userId.toString());

    return this.http.get<Post[]>(`${this.apiUrl}/posts`, { params })
      .pipe(
        map(posts => posts.slice(0, 5)),
        catchError(this.handleError)
      );
  }

  // POST request
  createPost(post: Partial<Post>): Observable<Post> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<Post>(`${this.apiUrl}/posts`, post, { headers })
      .pipe(catchError(this.handleError));
  }

  // PUT request
  updatePost(id: number, post: Partial<Post>): Observable<Post> {
    return this.http.put<Post>(`${this.apiUrl}/posts/${id}`, post)
      .pipe(catchError(this.handleError));
  }

  // DELETE request
  deletePost(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/posts/${id}`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('Network error:', error.error);
    } else {
      console.error(`Backend returned code ${error.status}, body:`, error.error);
    }
    return throwError(() => new Error('Something went wrong; please try again later.'));
  }
}

// Usage in component
@Component({
  selector: 'app-posts',
  template: `
    <button (click)="loadPosts()">Load Posts</button>
    <ul>
      <li *ngFor="let post of posts">{{ post.title }}</li>
    </ul>
  `
})
export class PostsComponent {
  posts: Post[] = [];

  constructor(private apiService: ApiService) {}

  loadPosts() {
    this.apiService.getUserPosts(1).subscribe({
      next: (posts) => {
        this.posts = posts;
        console.log('Loaded posts:', posts);
      },
      error: (error) => {
        console.error('Error loading posts:', error);
      }
    });
  }
}

```

--------------------------------

### Angular Custom Pipes for Data Transformation (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates how to create custom pipes in Angular to transform data in templates. Includes examples of pipes with optional parameters and settings for pure/impure behavior. These pipes can be used for formatting numbers, truncating strings, and filtering lists, enhancing template readability and functionality.

```typescript
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'exponential',
  standalone: true
})
export class ExponentialPipe implements PipeTransform {
  transform(value: number, exponent = 1): number {
    return Math.pow(value, exponent);
  }
}

@Pipe({
  name: 'truncate',
  standalone: true
})
export class TruncatePipe implements PipeTransform {
  transform(value: string, limit = 25, ellipsis = '...'): string {
    if (value.length <= limit) {
      return value;
    }
    return value.substring(0, limit) + ellipsis;
  }
}

@Pipe({
  name: 'filter',
  standalone: true,
  pure: false // Impure pipe, recalculates on every change detection
})
export class FilterPipe implements PipeTransform {
  transform<T>(items: T[], searchText: string, field: keyof T): T[] {
    if (!items || !searchText) {
      return items;
    }

    return items.filter(item => {
      const value = String(item[field]).toLowerCase();
      return value.includes(searchText.toLowerCase());
    });
  }
}

// Usage in component
@Component({
  selector: 'app-pipe-demo',
  standalone: true,
  imports: [CommonModule, ExponentialPipe, TruncatePipe, FilterPipe],
  template: `
    <p>2 to the power of 3: {{ 2 | exponential:3 }}</p>
    <!-- Output: 8 -->

    <p>{{ longText | truncate:20 }}</p>
    <!-- Output: "This is a very long..." -->

    <input [(ngModel)]="searchTerm" placeholder="Search users" />
    <ul>
      <li *ngFor="let user of users | filter:searchTerm:'name'">
        {{ user.name }}
      </li>
    </ul>

    <p>{{ today | date:'fullDate' }}</p>
    <p>{{ price | currency:'USD':'symbol':'1.2-2' }}</p>
    <p>{{ completion | percent:'1.0-0' }}</p>
  `
})
export class PipeDemoComponent {
  longText = 'This is a very long text that needs to be truncated';
  today = new Date();
  price = 1234.56;
  completion = 0.856;
  searchTerm = '';

  users = [
    { name: 'Alice', age: 30 },
    { name: 'Bob', age: 25 },
    { name: 'Charlie', age: 35 }
  ];
}

```

--------------------------------

### Custom Directives

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates the creation and usage of custom attribute and structural directives in Angular.

```APIDOC
## Custom Directives

### Description
This section covers creating and using custom directives in Angular.

### Attribute Directive: `appHighlight`

#### Description
Changes the background color of an element on mouse enter and revert on mouse leave.

#### Selector
`[appHighlight]`

#### Inputs
- **appHighlight** (string) - Optional - The color to apply on mouse enter. Defaults to 'yellow'.
- **defaultColor** (string) - Optional - The color to revert to on mouse leave. Defaults to 'transparent'.

#### Usage Example
```html
<p appHighlight="lightblue">Hover over me!</p>
<p appHighlight>Hover for default yellow</p>
```

### Structural Directive: `appUnless`

#### Description
Conditionally renders an embedded template based on a boolean expression. If the condition is false, the template is rendered; otherwise, it is removed from the view.

#### Selector
`*appUnless`

#### Inputs
- **appUnless** (boolean) - Required - If `false`, the template is rendered. If `true`, the template is not rendered.

#### Usage Example
```html
<button (click)="show = !show">Toggle</button>
<p *appUnless="show">This is shown when show is false</p>
```
```

--------------------------------

### Generate Angular Components, Services, and Modules

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates commands to generate various Angular building blocks using the Angular CLI. This includes generating components with their associated files, services for data handling, modules for organization, and components with inline templates and styles.

```bash
# Generate a new component
ng generate component user-profile

# Output creates:
# CREATE src/app/user-profile/user-profile.component.ts
# CREATE src/app/user-profile/user-profile.component.html
# CREATE src/app/user-profile/user-profile.component.css
# CREATE src/app/user-profile/user-profile.component.spec.ts

# Generate a service
ng generate service data

# Generate a module
ng generate module admin --routing

# Generate with inline template and styles
ng generate component header --inline-template --inline-style
```

--------------------------------

### Angular CLI Build and Deploy Commands (Bash)

Source: https://context7.com/context7/angular_dev/llms.txt

Provides essential Angular CLI commands for building applications for production, development, and analysis, as well as deployment configurations for platforms like Firebase and Netlify. These commands help optimize application bundles and streamline the deployment process.

```bash
# Build for production
ng build --configuration production

# Output:
# ✔ Browser application bundle generation complete.
# ✔ Copying assets complete.
# ✔ Index html generation complete.
#
# Initial chunk files   | Names            | Raw size | Estimated transfer size
# main-ABC123.js        | main             | 250.5 kB | 65.2 kB
# polyfills-XYZ789.js   | polyfills        | 32.1 kB  | 10.3 kB
# styles-DEF456.css     | styles           | 15.2 kB  | 3.1 kB
#
# Build at: 2025-10-14T19:00:00.000Z - Hash: abc123def456 - Time: 15234ms

# Build with source maps
ng build --source-map

# Build with specific base href
ng build --base-href /my-app/

# Analyze bundle size
ng build --stats-json
npx webpack-bundle-analyzer dist/my-app/stats.json

# Development build with watch mode
ng build --watch --configuration development

# Build for server-side rendering
ng build --configuration production
ng run my-app:server:production

# Deploy to Firebase
npm install -g firebase-tools
firebase login
firebase init
firebase deploy

# Deploy to GitHub Pages
ng build --output-path docs --base-href /my-app/
# Commit and push docs/ folder

# Deploy to Netlify
ng build --configuration production
# Upload dist/my-app/browser folder to Netlify

```

--------------------------------

### Common Angular CLI Commands (Bash)

Source: https://context7.com/context7/angular_dev/llms.txt

A collection of fundamental Angular CLI commands used for project scaffolding, development, and management. These commands simplify tasks such as creating new workspaces, applications, components, services, and configuring project settings.

```bash
# Create new workspace
ng new my-workspace --routing --style=scss

```

--------------------------------

### Angular Routing Configuration with Guards and Lazy Loading

Source: https://context7.com/context7/angular_dev/llms.txt

Illustrates setting up application routes using Angular Router, including lazy loading of modules and components, and implementing route guards for access control. The example shows a basic authentication guard and how to navigate programmatically within a component. This is essential for structuring navigation and securing routes.

```typescript
import { Routes } from '@angular/router';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

// Define route guard
export const authGuard = () => {
  const router = inject(Router);
  const isAuthenticated = localStorage.getItem('token') !== null;

  if (!isAuthenticated) {
    router.navigate(['/login']);
    return false;
  }
  return true;
};

// Configure routes
export const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadComponent: () => import('./home/home.component').then(m => m.HomeComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./dashboard/dashboard.component').then(m => m.DashboardComponent),
    canActivate: [authGuard]
  },
  {
    path: 'users/:id',
    loadComponent: () => import('./user-detail/user-detail.component').then(m => m.UserDetailComponent)
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.routes').then(m => m.ADMIN_ROUTES),
    canActivate: [authGuard]
  },
  {
    path: '**',
    loadComponent: () => import('./not-found/not-found.component').then(m => m.NotFoundComponent)
  }
];

// Use router in component
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-navigation',
  template: `
    <button (click)="goToHome()">Home</button>
    <button (click)="goToUser(123)">User 123</button>
  `
})
export class NavigationComponent {
  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {}

  goToHome() {
    this.router.navigate(['/home']);
  }

  goToUser(userId: number) {
    this.router.navigate(['/users', userId]);
  }
}
```

--------------------------------

### Angular Reactive Form with Validation and Dynamic Controls

Source: https://context7.com/context7/angular_dev/llms.txt

This Angular component demonstrates the creation of a reactive form using FormBuilder, including required field validation, email format validation, and nested form groups for address. It handles form submission and displays submitted data.

```typescript
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  template: `
    <form [formGroup]="registrationForm" (ngSubmit)="onSubmit()">
      <div>
        <label>Name:</label>
        <input formControlName="name" />
        <div *ngIf="registrationForm.get('name')?.invalid && registrationForm.get('name')?.touched">
          <small *ngIf="registrationForm.get('name')?.errors?.['required']">
            Name is required
          </small>
        </div>
      </div>

      <div>
        <label>Email:</label>
        <input formControlName="email" type="email" />
        <div *ngIf="registrationForm.get('email')?.invalid && registrationForm.get('email')?.touched">
          <small *ngIf="registrationForm.get('email')?.errors?.['required']">
            Email is required
          </small>
          <small *ngIf="registrationForm.get('email')?.errors?.['email']">
            Invalid email format
          </small>
        </div>
      </div>

      <div formGroupName="address">
        <label>Street:</label>
        <input formControlName="street" />

        <label>City:</label>
        <input formControlName="city" />
      </div>

      <button type="submit" [disabled]="registrationForm.invalid">
        Submit
      </button>
    </form>

    <div *ngIf="submitted">
      <h3>Submitted Data:</h3>
      <pre>{{ submittedData | json }}</pre>
    </div>
  `
})
export class RegistrationComponent {
  registrationForm: FormGroup;
  submitted = false;
  submittedData: any;

  constructor(private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      address: this.fb.group({
        street: [''],
        city: ['']
      })
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.submittedData = this.registrationForm.value;
      this.submitted = true;
      console.log('Form submitted:', this.submittedData);
      // Output: { name: 'John Doe', email: 'john@example.com', address: { street: '123 Main St', city: 'NYC' } }
    }
  }
}

```

--------------------------------

### POST /posts

Source: https://context7.com/context7/angular_dev/llms.txt

Creates a new post. Expects a JSON request body and returns the created post.

```APIDOC
## POST /posts

### Description
Creates a new blog post.

### Method
POST

### Endpoint
/posts

### Parameters
#### Path Parameters
None

#### Query Parameters
None

#### Request Body
- **post** (object) - Required - An object containing the post data. Expected fields include 'userId', 'title', and 'body'.

### Request Example
```json
{
  "userId": 1,
  "title": "New Post Title",
  "body": "This is the content of the new post."
}
```

### Response
#### Success Response (201 - typically, though example shows 200)
- **post** (Post) - The newly created post object, including its assigned ID.

#### Response Example
```json
{
  "userId": 1,
  "title": "New Post Title",
  "body": "This is the content of the new post.",
  "id": 101 
}
```
```

--------------------------------

### Configure Angular Universal for Server-Side Rendering (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Sets up an Express server for Angular Universal to enable server-side rendering with hydration. It configures the server to serve static files and handle SSR requests by rendering the Angular application on the server before sending it to the client. Dependencies include express and @angular/ssr.

```typescript
// server.ts - Express server configuration
import { APP_BASE_HREF } from '@angular/common';
import { CommonEngine } from '@angular/ssr';
import express from 'express';
import { fileURLToPath } from 'node:url';
import { dirname, join, resolve } from 'node:path';
import bootstrap from './src/main.server';

export function app(): express.Express {
  const server = express();
  const serverDistFolder = dirname(fileURLToPath(import.meta.url));
  const browserDistFolder = resolve(serverDistFolder, '../browser');
  const indexHtml = join(serverDistFolder, 'index.server.html');

  const commonEngine = new CommonEngine();

  server.set('view engine', 'html');
  server.set('views', browserDistFolder);

  // Serve static files
  server.get('*.*', express.static(browserDistFolder, {
    maxAge: '1y'
  }));

  // SSR for all routes
  server.get('*', (req, res, next) => {
    const { protocol, originalUrl, baseUrl, headers } = req;

    commonEngine
      .render({
        bootstrap,
        documentFilePath: indexHtml,
        url: `${protocol}://${headers.host}${originalUrl}`,
        publicPath: browserDistFolder,
        providers: [{ provide: APP_BASE_HREF, useValue: baseUrl }],
      })
      .then((html) => res.send(html))
      .catch((err) => next(err));
  });

  return server;
}

function run(): void {
  const port = process.env['PORT'] || 4000;
  const server = app();
  server.listen(port, () => {
    console.log(`Node Express server listening on http://localhost:${port}`);
  });
}

run();

```

--------------------------------

### GET /posts?userId={userId}

Source: https://context7.com/context7/angular_dev/llms.txt

Retrieves posts for a specific user, limited to the first 5 posts. Includes error handling.

```APIDOC
## GET /posts?userId={userId}

### Description
Retrieves posts authored by a specific user, returning a maximum of 5 posts.

### Method
GET

### Endpoint
/posts

### Parameters
#### Query Parameters
- **userId** (number) - Required - The ID of the user whose posts are to be retrieved.

#### Request Body
None

### Request Example
None

### Response
#### Success Response (200)
- **posts** (Post[]) - An array of post objects, where each post has 'id', 'userId', 'title', and 'body'. Only the first 5 matching posts are returned.

#### Response Example
```json
[
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  }
]
```
```

--------------------------------

### Angular Unit Testing Components and Services (TypeScript)

Source: https://context7.com/context7/angular_dev/llms.txt

Provides examples of writing unit tests for Angular components and services using Jasmine and Karma. It leverages TestBed for module configuration and testing utilities like ComponentFixture and DebugElement for interaction and assertion. This ensures the reliability and correctness of application logic.

```typescript
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

// Component to test
@Component({
  selector: 'app-welcome',
  standalone: true,
  template: `
    <h1>{{ title }}</h1>
    <button (click)="onClick()">Click me</button>
    <p *ngIf="clicked">Button was clicked!</p>
  `
})
export class WelcomeComponent {
  title = 'Welcome';
  clicked = false;

  onClick() {
    this.clicked = true;
  }
}

// Test suite
describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;
  let debugElement: DebugElement;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WelcomeComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    debugElement = fixture.debugElement;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display title', () => {
    const h1 = debugElement.query(By.css('h1'));
    expect(h1.nativeElement.textContent).toBe('Welcome');
  });

  it('should set clicked to true when button is clicked', () => {
    const button = debugElement.query(By.css('button'));
    button.nativeElement.click();

    expect(component.clicked).toBe(true);
  });

  it('should display message after button click', () => {
    const button = debugElement.query(By.css('button'));
    button.nativeElement.click();
    fixture.detectChanges();

    const paragraph = debugElement.query(By.css('p'));
    expect(paragraph.nativeElement.textContent).toBe('Button was clicked!');
  });
});

// Service testing
@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  add(a: number, b: number): number {
    return a + b;
  }

  multiply(a: number, b: number): number {
    return a * b;
  }
}

describe('CalculatorService', () => {
  let service: CalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should add two numbers correctly', () => {
    expect(service.add(2, 3)).toBe(5);
  });

  it('should multiply two numbers correctly', () => {
    expect(service.multiply(4, 5)).toBe(20);
  });
});

```

--------------------------------

### DELETE /posts/{id}

Source: https://context7.com/context7/angular_dev/llms.txt

Deletes a post by its ID. Returns a void response on success.

```APIDOC
## DELETE /posts/{id}

### Description
Deletes a blog post identified by its ID.

### Method
DELETE

### Endpoint
/posts/{id}

### Parameters
#### Path Parameters
- **id** (number) - Required - The ID of the post to delete.

#### Query Parameters
None

#### Request Body
None

### Request Example
None

### Response
#### Success Response (200)
- No content is returned upon successful deletion.

#### Response Example
None
```

--------------------------------

### Angular Component Definition with @Component Decorator

Source: https://context7.com/context7/angular_dev/llms.txt

Defines an Angular component named 'UserCardComponent' using the @Component decorator. It includes standalone component setup, imports for CommonModule, an inline template with data binding and directives (*ngFor), and inline CSS styles for presentation.

```typescript
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="user-card">
      <h2>{{ user.name }}</h2>
      <p>{{ user.email }}</p>
      <button (click)="onFollow()">
        {{ isFollowing ? 'Unfollow' : 'Follow' }}
      </button>
      <ul>
        <li *ngFor="let post of user.posts">{{ post.title }}</li>
      </ul>
    </div>
  `,
  styles: [
    `.user-card {
      border: 1px solid #ddd;
      padding: 20px;
      border-radius: 8px;
    }`
  ]
})
export class UserCardComponent {
  user = {
    name: 'Jane Doe',
    email: 'jane@example.com',
    posts: [
      { title: 'First Post' },
      { title: 'Second Post' }
    ]
  };

  isFollowing = false;

  onFollow() {
    this.isFollowing = !this.isFollowing;
    console.log(`User ${this.isFollowing ? 'followed' : 'unfollowed'}`);
  }
}
```

--------------------------------

### Angular Dependency Injection with Services

Source: https://context7.com/context7/angular_dev/llms.txt

Demonstrates how to define and inject services using Angular's hierarchical dependency injection system. It shows creating a `UserService` and injecting it into a `UserListComponent` using both the `inject()` function and constructor injection. This pattern is crucial for managing application state and business logic.

```typescript
import { Injectable } from '@angular/core';
import { Component, inject } from '@angular/core';

// Define a service
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private users = [
    { id: 1, name: 'Alice', role: 'Admin' },
    { id: 2, name: 'Bob', role: 'User' }
  ];

  getUsers() {
    return this.users;
  }

  getUserById(id: number) {
    return this.users.find(u => u.id === id);
  }

  addUser(name: string, role: string) {
    const id = Math.max(...this.users.map(u => u.id)) + 1;
    this.users.push({ id, name, role });
    return id;
  }
}

// Inject and use the service in a component
@Component({
  selector: 'app-user-list',
  standalone: true,
  template: `
    <h2>Users</h2>
    <ul>
      <li *ngFor="let user of users">
        {{ user.name }} - {{ user.role }}
      </li>
    </ul>
  `
})
export class UserListComponent {
  // Modern inject() function
  private userService = inject(UserService);

  // Or use constructor injection
  // constructor(private userService: UserService) {}

  users = this.userService.getUsers();
}
```

--------------------------------

### PUT /posts/{id}

Source: https://context7.com/context7/angular_dev/llms.txt

Updates an existing post by its ID. Expects a JSON request body with updated fields.

```APIDOC
## PUT /posts/{id}

### Description
Updates an existing blog post identified by its ID.

### Method
PUT

### Endpoint
/posts/{id}

### Parameters
#### Path Parameters
- **id** (number) - Required - The ID of the post to update.

#### Query Parameters
None

#### Request Body
- **post** (object) - Required - An object containing the fields to update for the post. Expected fields include 'title' and 'body'.

### Request Example
```json
{
  "title": "Updated Post Title",
  "body": "Updated content for the post."
}
```

### Response
#### Success Response (200)
- **post** (Post) - The updated post object.

#### Response Example
```json
{
  "userId": 1,
  "id": 1,
  "title": "Updated Post Title",
  "body": "Updated content for the post."
}
```
```

--------------------------------

### Create and Serve New Angular Application

Source: https://context7.com/context7/angular_dev/llms.txt

Installs the Angular CLI globally, generates a new Angular workspace and application, navigates into the project directory, and serves the application locally for development. The application typically runs on http://localhost:4200.

```bash
# Install Angular CLI globally
npm install -g @angular/cli

# Create a new Angular workspace and application
ng new my-angular-app

# Navigate to the project directory
cd my-angular-app

# Serve the application locally
ng serve

# Application runs at http://localhost:4200
# Output:
# ✔ Browser application bundle generation complete.
# ✔ Compiled successfully.
# ** Angular Live Development Server is listening on localhost:4200 **
```

--------------------------------

### GET /users

Source: https://context7.com/context7/angular_dev/llms.txt

Retrieves a list of all users. Includes error handling and retries.

```APIDOC
## GET /users

### Description
Retrieves a list of all users from the API.

### Method
GET

### Endpoint
/users

### Parameters
#### Query Parameters
None

#### Request Body
None

### Request Example
None

### Response
#### Success Response (200)
- **users** (User[]) - An array of user objects, where each user has 'id', 'name', and 'email'.

#### Response Example
```json
[
  {
    "id": 1,
    "name": "Leanne Graham",
    "email": "Sincere@april.biz"
  }
]
```
```