# Module 8 - Angular (v20.0)

## What this demonstrates
- Standalone components (`ProductListComponent`, `ProductFormComponent`, `ProductCardComponent`)
- Data binding: property binding, event binding, two-way binding (`ngModel`)
- Structural directives: `*ngFor`, `*ngSwitch`/`*ngSwitchCase`/`*ngSwitchDefault` (in
  `ProductCardComponent`)
- Attribute directives: `ngClass`, `ngStyle` (in `ProductCardComponent`)
- A custom pipe (`pipes/truncate.pipe.ts`)
- Parent-child communication with `@Input`/`@Output` (`components/child-demo/product-card.component.ts`)
- Both form styles: **Reactive Forms** (`product-form.component.ts`) and **Template-driven
  Forms** (`product-template-form.component.ts`)
- A reusable, injectable service (`ProductService`) using `HttpClient` + Observables, covering
  full CRUD: **GET, POST, PUT, DELETE**
- Routing (`app.routes.ts`) including a route guard (`guards/auth.guard.ts` — `CanActivate`)
  and a lazy-loaded standalone component (`components/reports/reports.component.ts`)
- An HTTP interceptor (`interceptors/auth.interceptor.ts`) that attaches a JWT to outgoing
  requests
- Unit tests with Jasmine/Karma: a service test (`product.service.spec.ts`, using
  `HttpClientTestingModule`) and a component test (`product-list.component.spec.ts`)
- Wiring it all together in `app.config.ts` using the standalone bootstrap style

## To run
1. `npm install -g @angular/cli`
2. `ng new deep-skilling-angular --standalone` (or add these files into an existing project)
3. Copy the files under `src/app/` into the matching folders of your generated project.
4. Update `product.service.ts`'s `baseUrl` to point at your running ProductService
   (Module 6/7), e.g. `https://localhost:5001/api/products`.
5. `ng serve` and visit `http://localhost:4200/products`.
6. Run unit tests: `ng test`

Note: NgRx (Advanced State Management) is now included in `store/products/` — actions,
reducer, effects, and selectors, following the standard NgRx feature-slice pattern. See
`components/product-list/product-list-ngrx.component.ts` for a version of the product list
that reads from the store instead of calling `ProductService` directly, and dispatches actions
instead of subscribing to service calls in the component. Requires `@ngrx/store` and
`@ngrx/effects` packages: `npm install @ngrx/store @ngrx/effects`.
