using TaxCalculatorJaskaranCommify.Core.DTOs;

namespace TaxCalculatorJaskaranCommify.Core.Interfaces;

public interface ICalculateIncomeTax
{
    IncomeTaxCalculatorResultDto CalculateTax(SalaryDto salary);
}