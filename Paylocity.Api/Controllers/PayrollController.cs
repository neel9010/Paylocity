using Microsoft.AspNetCore.Mvc;
using Paylocity.Services.Interfaces;
using Paylocity.Services.Model;

namespace Paylocity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly ILogger<PayrollController> _logger;
        private readonly IPayrollService _payrollService;

        public PayrollController(ILogger<PayrollController> logger, IPayrollService payrollService)
        {
            _logger = logger;
            _payrollService = payrollService;
        }

        [HttpGet("ViewDeductionCosts/{id}")]
        public async Task<EmployeeDeductions> GetDeductionCosts(Guid id)
        {
            _logger.LogInformation($"Getting Deduction Costs For employeeId: {id}");
            return await _payrollService.ViewDeductionCosts(id);
        }

        [HttpPost("Run")]
        public async Task RunPayroll()
        {
            _logger.LogInformation($"Running Payroll");
            await _payrollService.RunPayroll();
        }
    }
}