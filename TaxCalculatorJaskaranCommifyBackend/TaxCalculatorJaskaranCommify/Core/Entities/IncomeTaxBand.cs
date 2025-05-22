namespace TaxCalculatorJaskaranCommify.Core.Entities;

public class IncomeTaxBand
{
    public int Id { get; set; }
    public decimal MinimumIncomeThreshold { get; set; }
    public decimal MaximumIncomeThreshold { get; set; }
    public decimal TaxRate { get; set; }
}
