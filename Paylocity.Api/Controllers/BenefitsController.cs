using Microsoft.AspNetCore.Mvc;
using Paylocity.Services.Interfaces;
using Paylocity.Services.Model;

namespace Paylocity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenefitsController : ControllerBase
    {
        private readonly ILogger<BenefitsController> _logger;
        private readonly IBenefitsService _benefitsService;

        public BenefitsController(ILogger<BenefitsController> logger, IBenefitsService benefitsService)
        {
            _logger = logger;
            _benefitsService = benefitsService;
        }

        [HttpGet("ViewDeductionCosts/{id}")]
        public async Task<EmployeeDeductions> GetDeductionCosts(Guid id)
        {
            _logger.LogInformation($"Getting Deduction Costs For employeeId: {id}");
            return await _benefitsService.ViewDeductionCosts(id);
        }

        [HttpPost("Enroll/{id}")]
        public async Task Enroll(Guid id)
        {
            _logger.LogInformation($"Enrolling employeeId: {id} in benefits");
             await _benefitsService.Enroll(id);
        }
    }
}