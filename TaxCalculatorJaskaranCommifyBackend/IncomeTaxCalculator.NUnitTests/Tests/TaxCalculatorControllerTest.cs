using Moq;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Api.Controllers;
using TaxCalculatorJaskaranCommify.Core.DTOs;
using TaxCalculatorJaskaranCommify.Core.Interfaces;

namespace IncomeTaxCalculator.NUnitTests.Controllers
{
    public class TaxCalculatorControllerTests
    {
        private Mock<ICalculateIncomeTax> _mockService = null!;
        private TaxCalculatorController _controller = null!;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<ICalculateIncomeTax>();
            _controller = new TaxCalculatorController(_mockService.Object);
        }

        [Test]
        public void Calculate_WhenSalaryIsZero_ReturnsBadRequest()
        {
            var salary = new SalaryDto(0);

            var result = _controller.Calculate(salary);

            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
        
        [Test]
        public void Calculate_ValidSalary_ReturnsOkWithResult()
        {
            var salary = new SalaryDto(40000);
            var expectedResult = new IncomeTaxCalculatorResultDto(
                  40000m,     // GrossAnnualSalary
                  3333.33m,   // GrossMonthlySalary
                  32000m,     // NetAnnualSalary
                  2666.67m,   // NetMonthlySalary
                  8000m,      // AnnualTaxPaid
                  666.67m     // MonthlyTaxPaid
             );

            _mockService.Setup(s => s.CalculateTax(salary)).Returns(expectedResult);

            var result = _controller.Calculate(salary);

            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult!.Value, Is.EqualTo(expectedResult));
        }
    }
}