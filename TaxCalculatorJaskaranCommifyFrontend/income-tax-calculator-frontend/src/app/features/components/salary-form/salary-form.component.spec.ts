import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SalaryFormComponent } from './salary-form.component';

describe('SalaryFormComponent', () => {
  let component: SalaryFormComponent;
  let fixture: ComponentFixture<SalaryFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({

      imports: [SalaryFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SalaryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should emit salary when button is clicked', () => {
    spyOn(component.salarySubmitted, 'emit');
    component.value = 25000;
    fixture.detectChanges();

    const button = fixture.nativeElement.querySelector('button');
    button.click();

    expect(component.salarySubmitted.emit).toHaveBeenCalledWith(25000);
  });

  it('should disable button when salary is 0', () => {
    component.value = 0;
    fixture.detectChanges();

    const button = fixture.nativeElement.querySelector('button');
    expect(button.disabled).toBeTrue();
  });
});