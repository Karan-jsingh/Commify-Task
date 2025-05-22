import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TaxCalculatorComponent } from './tax-calculator.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TaxService } from '../../../core/services/tax.service';

describe('TaxCalculatorComponent', () => {
  let component: TaxCalculatorComponent;
  let fixture: ComponentFixture<TaxCalculatorComponent>;
  let taxService: TaxService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, TaxCalculatorComponent],
      providers: [TaxService] 
    }).compileComponents();

    fixture = TestBed.createComponent(TaxCalculatorComponent);
    component = fixture.componentInstance;
    taxService = TestBed.inject(TaxService);
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should call TaxService when salary is submitted', () => {
    spyOn(taxService, 'calculateTax').and.callThrough();
    
    component.onSalarySubmit(50000);
    expect(taxService.calculateTax).toHaveBeenCalledWith(50000);
  });
});
