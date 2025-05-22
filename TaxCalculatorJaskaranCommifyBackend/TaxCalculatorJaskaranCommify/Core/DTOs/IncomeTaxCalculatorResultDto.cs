namespace TaxCalculatorJaskaranCommify.Core.DTOs;

public record IncomeTaxCalculatorResultDto(
    decimal GrossAnnualSalary,
    decimal GrossMonthlySalary,
    decimal NetAnnualSalary,
    decimal NetMonthlySalary,
    decimal AnnualTaxPaid,
    decimal MonthlyTaxPaid
    );