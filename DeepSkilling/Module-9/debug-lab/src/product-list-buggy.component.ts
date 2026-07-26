import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ProductService } from '../../Module-8/src/app/services/product.service';
import { Product } from '../../Module-8/src/app/models/product.model';

/**
 * DEBUG LAB - Module 9: Application Debugging
 *
 * This component intentionally contains several bugs commonly seen in real
 * Angular applications. Use Chrome DevTools and the VS Code debugger
 * (see ../debugging-guide.md) to find and fix each one.
 *
 * DO NOT fix the bugs before reading the guide - the goal is to practice
 * the debugging *process*, not just read the corrected code.
 */
@Component({
  selector: 'app-product-list-buggy',
  standalone: true,
  templateUrl: './product-list-buggy.component.html'
})
export class ProductListBuggyComponent implements OnInit, OnDestroy {
  products: Product[] = [];
  filteredProducts: Product[];   // BUG 1: used before it is ever assigned a value
  selectedIndex = 0;
  private sub: Subscription;    // BUG 2: subscription is created but never unsubscribed

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.sub = this.productService.getProducts().subscribe(data => {
      this.products = data;
      // BUG 3: this filter runs once, on load, and never re-runs when
      // `products` changes later (e.g. after an add/delete) - a classic
      // "stale derived state" bug. Set a breakpoint here and inspect
      // `this.products` vs `this.filteredProducts` in the Sources panel.
      this.filteredProducts = this.products.filter(p => p.price > 0);
    });
  }

  selectNext(): void {
    // BUG 4: off-by-one error - this can select an index that does not
    // exist in the array, causing `undefined` to reach the template.
    this.selectedIndex = this.selectedIndex + 1;
  }

  get selectedProduct(): Product {
    // BUG 5: no bounds check - throws "Cannot read properties of
    // undefined" once selectNext() runs past the end of the array.
    // This is a great spot for a VS Code breakpoint with a watch on
    // `this.selectedIndex` and `this.products.length`.
    return this.products[this.selectedIndex];
  }

  ngOnDestroy(): void {
    // sub.unsubscribe() is intentionally missing here (see BUG 2)
  }
}
