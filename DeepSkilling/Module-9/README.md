# Module 9 - Application Debugging

## What this demonstrates
- A deliberately buggy standalone Angular component
  (`debug-lab/src/product-list-buggy.component.ts`) covering five common,
  realistic bug patterns:
  1. Using a property before it's initialized
  2. A subscription that is never cleaned up (`ngOnDestroy` leak)
  3. Stale derived state that doesn't recompute when its source changes
  4. An off-by-one index bug
  5. A missing bounds check that surfaces the previous bug as a runtime
     `TypeError`
- A ready-to-use VS Code `launch.json` (`vscode-config/launch.json`) for
  attaching the built-in JavaScript debugger to a running `ng serve`
  instance
- A step-by-step `debugging-guide.md` that walks through finding each bug
  first with Chrome DevTools (Elements, Sources, breakpoints, Scope panel)
  and then with the VS Code debugger (breakpoints, watch expressions)

## To run
1. Copy `debug-lab/src/product-list-buggy.component.ts` and its template
   into an Angular project that already has the `ProductService` and
   `Product` model from Module 8 (adjust the import paths to match your
   project layout).
2. Add a route or drop `<app-product-list-buggy>` into an existing
   template so it renders.
3. Copy `vscode-config/launch.json` into your project's `.vscode/` folder.
4. Follow `debugging-guide.md` end to end - do not read the component
   source and "spot" the bugs by inspection alone; the exercise is to
   practice using breakpoints, the Scope/Watch panels, and the Console to
   locate them the way you would with unfamiliar production code.
