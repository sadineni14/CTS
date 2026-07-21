import { Pipe, PipeTransform } from '@angular/core';

// Creating Custom Pipes sub-topic — truncates long product names for display
@Pipe({
  name: 'truncate',
  standalone: true
})
export class TruncatePipe implements PipeTransform {
  transform(value: string, limit = 20, suffix = '...'): string {
    if (!value) return '';
    return value.length > limit ? value.substring(0, limit) + suffix : value;
  }
}

// Usage in a template: {{ product.name | truncate:15 }}
