import { Component } from '@angular/core';
import { TaxCalculatorComponent } from './features/components/tax-calculator/tax-calculator.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TaxCalculatorComponent],
  template: `<app-tax-calculator />`
})
export class AppComponent {}