import { Component } from '@angular/core';

// This component is only fetched/loaded when the user navigates to /reports —
// demonstrates Lazy Loading with the standalone loadComponent() API (Angular v20 style).
@Component({
  selector: 'app-reports',
  standalone: true,
  template: `<h2>Reports (lazy-loaded)</h2><p>This chunk was loaded on demand.</p>`
})
export class ReportsComponent {}
