using TaxCalculatorJaskaranCommify.Core.Entities;

namespace TaxCalculatorJaskaranCommify.Core.Interfaces;

public interface IIncomeTaxBandRepository
{
    List<IncomeTaxBand> GetIncomeTaxBands();
}
