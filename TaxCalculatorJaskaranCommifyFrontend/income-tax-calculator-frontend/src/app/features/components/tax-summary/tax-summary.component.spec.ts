import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TaxSummaryComponent } from './tax-summary.component';
import { CommonModule } from '@angular/common';

describe('TaxSummaryComponent', () => {
  let component: TaxSummaryComponent;
  let fixture: ComponentFixture<TaxSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonModule, TaxSummaryComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(TaxSummaryComponent);
    component = fixture.componentInstance;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should not render anything if result is undefined', () => {
    component.result = undefined;
    fixture.detectChanges();
  
    const compiled = fixture.nativeElement;
    expect(compiled.textContent.trim()).toBe('');
  });

  it('should render tax summary when result is set', () => {
    component.result = {
      grossAnnualSalary: 40000,
      grossMonthlySalary: 3333.33,
      netAnnualSalary: 29000,
      netMonthlySalary: 2416.67,
      annualTaxPaid: 11000,
      monthlyTaxPaid: 916.67
    };
    fixture.detectChanges();

    const compiled = fixture.nativeElement;
    expect(compiled.textContent).toContain('Gross Annual Salary: £40000');
    expect(compiled.textContent).toContain('Gross Monthly Salary: £3,333.33');
    expect(compiled.textContent).toContain('Net Annual Salary: £29000');
    expect(compiled.textContent).toContain('Net Monthly Salary: £2,416.67');
    expect(compiled.textContent).toContain('Annual Tax Paid: £11000');
    expect(compiled.textContent).toContain('Monthly Tax Paid: £916.67');
  });
});