using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using TaxCalculatorJaskaranCommify.Core.DTOs;


namespace IncomeTaxCalculator.NUnitTests.Integration
{
    public class IncomeTaxCalculatorEndpointTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void Cleanup()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [Test]
        public async Task CalculateTaxEndpoint_ReturnsOkAndCorrectResult()
        {
            var salary = new SalaryDto(25000);
            var response = await _client.PostAsJsonAsync("/api/taxcalculator/calculate", salary);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var result = await response.Content.ReadFromJsonAsync<IncomeTaxCalculatorResultDto>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.GrossAnnualSalary, Is.EqualTo(25000));
        }
    }
}