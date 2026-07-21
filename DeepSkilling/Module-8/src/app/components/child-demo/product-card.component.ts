import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product.model';

// Parent-Child Communication using @Input and @Output sub-topic
@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="product-card" [ngClass]="{ 'low-stock': isLowStock }" [ngStyle]="{ border: '1px solid #ccc', padding: '8px' }">
      <h4>{{ product.name }}</h4>
      <p>{{ product.price | currency }}</p>

      <!-- ngSwitch sub-topic -->
      <ng-container [ngSwitch]="product.categoryId">
        <span *ngSwitchCase="1">Electronics</span>
        <span *ngSwitchCase="2">Books</span>
        <span *ngSwitchDefault>Other</span>
      </ng-container>

      <button (click)="remove.emit(product.productId)">Remove</button>
    </div>
  `
})
export class ProductCardComponent {
  @Input() product!: Product;         // data passed down from parent
  @Input() isLowStock = false;
  @Output() remove = new EventEmitter<number>(); // event emitted up to parent
}

// Parent usage example:
// <app-product-card
//   *ngFor="let p of products"
//   [product]="p"
//   [isLowStock]="p.price < 10"
//   (remove)="deleteProduct($event)">
// </app-product-card>
