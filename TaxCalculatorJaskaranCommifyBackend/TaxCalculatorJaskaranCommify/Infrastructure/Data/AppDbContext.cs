using Microsoft.EntityFrameworkCore;
using TaxCalculatorJaskaranCommify.Core.Entities;

namespace TaxCalculator.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<IncomeTaxBand> TaxBands => Set<IncomeTaxBand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IncomeTaxBand>().HasData(
            new IncomeTaxBand { Id = 1, MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 },
            new IncomeTaxBand { Id = 2, MinimumIncomeThreshold = 5000, MaximumIncomeThreshold = 20000, TaxRate = 20 },
            new IncomeTaxBand { Id = 3, MinimumIncomeThreshold = 20000, MaximumIncomeThreshold = decimal.MaxValue, TaxRate = 40 });
    }
}
