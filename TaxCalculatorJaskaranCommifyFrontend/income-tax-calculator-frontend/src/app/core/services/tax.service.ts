import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaxResult } from '../models/tax-result.model'; 

@Injectable({
  providedIn: 'root' 
})
export class TaxService {
  private apiUrl = 'https://localhost:7056/api/taxcalculator/calculate';

  constructor(private http: HttpClient) {}

  calculateTax(grossSalary: number): Observable<TaxResult> {
    return this.http.post<TaxResult>(this.apiUrl, { grossSalary });
  }
}