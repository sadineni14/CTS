import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';

// Template-driven form: uses ngModel + a template reference variable for validation,
// as opposed to product-form.component.ts, which uses Reactive Forms.
@Component({
  selector: 'app-product-template-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-template-form.component.html'
})
export class ProductTemplateFormComponent {
  product: Product = { productId: 0, name: '', price: 0, categoryId: 1 };

  constructor(private productService: ProductService) {}

  onSubmit(form: NgForm): void {
    if (form.invalid) return;
    this.productService.create(this.product).subscribe(() => {
      form.resetForm();
    });
  }
}
