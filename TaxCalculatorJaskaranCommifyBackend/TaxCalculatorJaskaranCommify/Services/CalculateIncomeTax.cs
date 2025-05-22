using TaxCalculatorJaskaranCommify.Core.DTOs;
using TaxCalculatorJaskaranCommify.Core.Entities;
using TaxCalculatorJaskaranCommify.Core.Interfaces;

namespace TaxCalculatorJaskaranCommify.Services;

public class CalculateIncomeTax(IIncomeTaxBandRepository repository) : ICalculateIncomeTax
{
    public IncomeTaxCalculatorResultDto CalculateTax(SalaryDto salary)
    {
        var bands = repository.GetIncomeTaxBands();
        var grossSalary = salary.GrossSalary;

        var totalTax = CalculateTotalTax(grossSalary, bands);
        var netSalary = grossSalary - totalTax;

        return MapToResult(grossSalary, netSalary, totalTax);
    }

    private static decimal CalculateTotalTax(decimal income, List<IncomeTaxBand> bands)
    {
        decimal totalTax = 0;
        decimal remaining = income;

        foreach (var band in bands)
        {
            if (income <= band.MinimumIncomeThreshold) break;

            decimal bandRange = band.MaximumIncomeThreshold - band.MinimumIncomeThreshold;
            decimal taxableAmount = Math.Min(remaining, bandRange);

            totalTax += taxableAmount * (band.TaxRate / 100);
            remaining -= taxableAmount;

            if (remaining <= 0) break;
        }

        return totalTax;
    }

    private static IncomeTaxCalculatorResultDto MapToResult(decimal grossSalary, decimal netSalary, decimal totalTax)
    {
        return new IncomeTaxCalculatorResultDto(
            GrossAnnualSalary: Math.Round(grossSalary, 2),
            GrossMonthlySalary: Math.Round(grossSalary / 12, 2),
            NetAnnualSalary: Math.Round(netSalary, 2),
            NetMonthlySalary: Math.Round(netSalary / 12, 2),
            AnnualTaxPaid: Math.Round(totalTax, 2),
            MonthlyTaxPaid: Math.Round(totalTax / 12, 2)
        );
    }
}

