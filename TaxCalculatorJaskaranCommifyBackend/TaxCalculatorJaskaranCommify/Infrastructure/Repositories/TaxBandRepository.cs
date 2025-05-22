using TaxCalculator.Infrastructure.Data;
using TaxCalculatorJaskaranCommify.Core.Entities;
using TaxCalculatorJaskaranCommify.Core.Interfaces;

namespace TaxCalculator.Infrastructure.Repositories;

public class TaxBandRepository(AppDbContext context) : IIncomeTaxBandRepository
{
    public List<IncomeTaxBand> GetIncomeTaxBands()
    {
        var query = from band in context.TaxBands
                    orderby band.MinimumIncomeThreshold
                    select band;

        return query.ToList();
    }
}
