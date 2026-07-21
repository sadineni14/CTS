import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ProductService } from './product.service';
import { Product } from '../models/product.model';

// Unit Testing with Jasmine and Karma / Service Testing sub-topic
describe('ProductService', () => {
  let service: ProductService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductService]
    });
    service = TestBed.inject(ProductService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // ensures no outstanding requests
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getAll() should return an array of products', () => {
    const mockProducts: Product[] = [
      { productId: 1, name: 'Laptop', price: 999.99, categoryId: 1 }
    ];

    service.getAll().subscribe(products => {
      expect(products.length).toBe(1);
      expect(products).toEqual(mockProducts);
    });

    const req = httpMock.expectOne('https://localhost:5001/api/products');
    expect(req.request.method).toBe('GET');
    req.flush(mockProducts);
  });

  it('create() should POST a new product', () => {
    const newProduct: Product = { productId: 0, name: 'Tablet', price: 299.99, categoryId: 1 };

    service.create(newProduct).subscribe(product => {
      expect(product.name).toBe('Tablet');
    });

    const req = httpMock.expectOne('https://localhost:5001/api/products');
    expect(req.request.method).toBe('POST');
    req.flush({ ...newProduct, productId: 5 });
  });
});
