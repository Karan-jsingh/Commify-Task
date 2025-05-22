using Moq;
using TaxCalculatorJaskaranCommify.Services;
using TaxCalculatorJaskaranCommify.Core.Interfaces;
using TaxCalculatorJaskaranCommify.Core.DTOs;
using TaxCalculatorJaskaranCommify.Core.Entities;

namespace IncomeTaxCalculator.NUnitTests.Services
{
    public class TaxCalculationServiceTests
    {
        [Test]
        public void CalculateTax_Given25000GrossSalary_ReturnsExpectedResults()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(repo => repo.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0,  MaximumIncomeThreshold = 5000, TaxRate = 0 },
                new() { MinimumIncomeThreshold = 5000,  MaximumIncomeThreshold = 20000, TaxRate = 20 },
                new() { MinimumIncomeThreshold = 20000,  MaximumIncomeThreshold = decimal.MaxValue, TaxRate = 40 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var salary = new SalaryDto(25000);
            var result = service.CalculateTax(salary);

            Assert.That(result.GrossAnnualSalary, Is.EqualTo(25000));
            Assert.That(result.GrossMonthlySalary, Is.EqualTo(2083.33).Within(0.01));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(20000));
            Assert.That(result.NetMonthlySalary, Is.EqualTo(1666.67).Within(0.01));
            Assert.That(result.AnnualTaxPaid, Is.EqualTo(5000));
            Assert.That(result.MonthlyTaxPaid, Is.EqualTo(416.67).Within(0.01));
        }

        [Test]
        public void CalculateTax_IncomeBelowFirstBand_ReturnsZeroTax()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 5000, MaximumIncomeThreshold = 20000, TaxRate = 20 },
                new() { MinimumIncomeThreshold = 20000, MaximumIncomeThreshold = 50000, TaxRate = 40 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(4000));

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(0));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(4000));
        }

        [Test]
        public void CalculateTax_IncomeExactlyAtBandLimit_ReturnsCorrectTax()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 },
                new() { MinimumIncomeThreshold = 5000, MaximumIncomeThreshold = 20000, TaxRate = 20 },
                new() { MinimumIncomeThreshold = 20000, MaximumIncomeThreshold = 50000, TaxRate = 40 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(20000));

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(3000));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(17000));
        }

        [Test]
        public void CalculateTax_HighIncomeAcrossBands_ReturnsCorrectTax()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 },
                new() { MinimumIncomeThreshold = 5000, MaximumIncomeThreshold = 20000, TaxRate = 20 },
                new() { MinimumIncomeThreshold = 20000, MaximumIncomeThreshold = decimal.MaxValue, TaxRate = 40 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(100000));

            var expectedTax = 0 + (15000 * 0.20m) + (80000 * 0.40m);
            var expectedNet = 100000 - expectedTax;

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(expectedTax));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(expectedNet));
        }

        [Test]
        public void CalculateTax_ZeroSalary_ReturnsAllZero()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(0));

            Assert.That(result.GrossAnnualSalary, Is.EqualTo(0));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(0));
            Assert.That(result.AnnualTaxPaid, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTax_NegativeSalary_ReturnsZeroTax()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(-5000));

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(0));
            Assert.That(result.NetAnnualSalary, Is.EqualTo(-5000));
        }

        [Test]
        public void CalculateTax_RoundingTest_PrecisionMatchesExpected()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>
            {
                new() { MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 10000, TaxRate = 10 },
                new() { MinimumIncomeThreshold = 10000, MaximumIncomeThreshold = 20000, TaxRate = 15 }
            });

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(15000));

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(1750));
            Assert.That(result.MonthlyTaxPaid, Is.EqualTo(145.83).Within(0.01));
        }

        [Test]
        public void CalculateTax_WithNoTaxBands_ReturnsZeroTax()
        {
            var mockRepo = new Mock<IIncomeTaxBandRepository>();
            mockRepo.Setup(r => r.GetIncomeTaxBands()).Returns(new List<IncomeTaxBand>());

            var service = new CalculateIncomeTax(mockRepo.Object);
            var result = service.CalculateTax(new SalaryDto(30000));

            Assert.That(result.AnnualTaxPaid, Is.EqualTo(0));
        }
    }
}