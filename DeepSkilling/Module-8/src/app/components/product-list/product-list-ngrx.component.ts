import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.model';
import * as ProductActions from '../../store/products/product.actions';
import { selectAllProducts, selectProductsLoading } from '../../store/products/product.selectors';

// Same UI as ProductListComponent, but sourced from the NgRx store instead of calling
// ProductService directly — demonstrates "Using Services for State Management" evolving
// into "NgRx for Advanced State Management".
@Component({
  selector: 'app-product-list-ngrx',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <h2>Products (NgRx-powered)</h2>
    <p *ngIf="loading$ | async">Loading...</p>
    <ul>
      <li *ngFor="let p of products$ | async">
        {{ p.name }} - {{ p.price | currency }}
        <button (click)="deleteProduct(p.productId)">Delete</button>
      </li>
    </ul>
    <a routerLink="/products/new">Add Product</a>
  `
})
export class ProductListNgrxComponent implements OnInit {
  products$: Observable<Product[]> = this.store.select(selectAllProducts);
  loading$: Observable<boolean> = this.store.select(selectProductsLoading);

  constructor(private store: Store) {}

  ngOnInit(): void {
    this.store.dispatch(ProductActions.loadProducts());
  }

  deleteProduct(productId: number): void {
    this.store.dispatch(ProductActions.deleteProduct({ productId }));
  }
}
