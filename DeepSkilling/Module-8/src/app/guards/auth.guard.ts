import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

// Router Guards: CanActivate sub-topic — blocks access if no auth token is present
export const authGuard: CanActivateFn = () => {
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (token) {
    return true;
  }

  router.navigate(['/login']);
  return false;
};

// Apply in app.routes.ts:
// { path: 'products/new', component: ProductFormComponent, canActivate: [authGuard] }
