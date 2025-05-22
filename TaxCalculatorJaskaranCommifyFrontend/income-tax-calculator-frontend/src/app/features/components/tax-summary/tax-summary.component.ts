import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tax-summary',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tax-summary.component.html',
  styleUrls: ['./tax-summary.component.css']
})
export class TaxSummaryComponent {
  @Input() result: any;
}