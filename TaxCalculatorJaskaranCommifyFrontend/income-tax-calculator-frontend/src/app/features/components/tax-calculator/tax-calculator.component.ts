import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TaxService } from '../../../core/services/tax.service'; 
import { TaxResult } from '../../../core/models/tax-result.model';
import { SalaryFormComponent } from '../../components/salary-form/salary-form.component';
import { TaxSummaryComponent } from '../../components/tax-summary/tax-summary.component';

@Component({
  selector: 'app-tax-calculator',
  standalone: true,  
  imports: [CommonModule, FormsModule, SalaryFormComponent, TaxSummaryComponent],  
  templateUrl: './tax-calculator.component.html',
  styleUrls: ['./tax-calculator.component.css']
})
export class TaxCalculatorComponent {
  taxResult: TaxResult | null = null;
  grossSalary: number = 0;
  calculated = false;

  constructor(private taxService: TaxService) {}  

  onSalarySubmit(salary: number) {
    if (salary <= 0) {
      this.resetCalculator();
      return;
    }

    this.taxService.calculateTax(salary).subscribe({
      next: (result) => {
        this.taxResult = result;
        this.grossSalary = salary;
        this.calculated = true;
      },
      error: (err) => console.error('API error:', err)
    });
  }

  resetCalculator() {  
    this.taxResult = null;
    this.grossSalary = 0;
    this.calculated = false;
  }

  toggleTheme(event: Event) {  
    const isDark = (event.target as HTMLInputElement).checked;
    document.body.classList.toggle('dark-mode', isDark);
  }
}
