import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-salary-form',
  standalone: true,
  templateUrl: './salary-form.component.html',
  styleUrls: ['./salary-form.component.css'],
  imports: [FormsModule] 
})
export class SalaryFormComponent {
  @Input() value: number = 0;
  @Output() salarySubmitted = new EventEmitter<number>();

  submit() {
    this.salarySubmitted.emit(this.value);
  }
}