using Microsoft.AspNetCore.Mvc;
using TaxCalculatorJaskaranCommify.Core.DTOs;
using TaxCalculatorJaskaranCommify.Core.Interfaces;


namespace TaxCalculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaxCalculatorController(ICalculateIncomeTax service) : ControllerBase
{
    [HttpPost("calculate")]
    public ActionResult<IncomeTaxCalculatorResultDto> Calculate([FromBody] SalaryDto salary)
    {
        if (salary.GrossSalary <= 0) return BadRequest("Gross salary must be greater than 0.");
        var result = service.CalculateTax(salary);
        return Ok(result);
    }
}