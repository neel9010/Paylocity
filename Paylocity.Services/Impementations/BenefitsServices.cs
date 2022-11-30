using Paylocity.Data.Interfaces;
using Paylocity.Domain.Implementations;
using Paylocity.Services.Interfaces;
using Paylocity.Services.Model;

namespace Paylocity.Services.Impementations
{
    public class BenefitsServices : IBenefitsService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDeductionService _deductionService;

        public BenefitsServices(IEmployeeRepository employeeRepository, IDeductionService deductionService)
        {
            _employeeRepository = employeeRepository;
            _deductionService = deductionService;
        }

        public async Task Enroll(Guid personId)
        {
            await _employeeRepository.GetEmployeeById(personId);

            //TODO: Rest of the logic here for enrollment process
        }

        public async Task<EmployeeDeductions> ViewDeductionCosts(Guid personId)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(personId);
            EmployeeDeductions employeeDeductions = new()
            {
                Compensation = employee.Compensation,
                DeductionInformation = _deductionService.GetDeductionCosts(employee),
                TotalDeductions = _deductionService.GetTotalDeductionAmount(employee)
            };

            return employeeDeductions;
        }
    }
}