import { createAction, props } from '@ngrx/store';
import { Product } from '../../models/product.model';

// Actions sub-topic — one action per intent/event
export const loadProducts = createAction('[Products] Load Products');
export const loadProductsSuccess = createAction(
  '[Products] Load Products Success',
  props<{ products: Product[] }>()
);
export const loadProductsFailure = createAction(
  '[Products] Load Products Failure',
  props<{ error: string }>()
);

export const addProduct = createAction(
  '[Products] Add Product',
  props<{ product: Product }>()
);
export const addProductSuccess = createAction(
  '[Products] Add Product Success',
  props<{ product: Product }>()
);

export const deleteProduct = createAction(
  '[Products] Delete Product',
  props<{ productId: number }>()
);
export const deleteProductSuccess = createAction(
  '[Products] Delete Product Success',
  props<{ productId: number }>()
);
