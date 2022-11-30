using Paylocity.Data.Interfaces;
using Paylocity.Domain.Implementations;
using Paylocity.Services.Interfaces;
using Paylocity.Services.Model;

namespace Paylocity.Services.Impementations
{
    public class PayrollService : IPayrollService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDeductionService _deductionService;
        private readonly IPayCheckService _payCheckService;
        private IReadOnlyList<Employee> _employees;

        public PayrollService(IEmployeeRepository employeeRepository, IPayCheckService payCheckService, IDeductionService deductionService)
        {
            _employeeRepository = employeeRepository;
            _deductionService = deductionService;
            _payCheckService = payCheckService;
        }

        public async Task RunPayroll()
        {
            _employees = await _employeeRepository.GetAllEmployees();

            foreach (Employee employee in _employees)
            {
                PayCheck check = await _payCheckService.CreatePayCheck(employee.Id);

                if (check != null)
                {
                    _payCheckService.CalculateCheck(check);
                    await _payCheckService.UpdatePayCheck(check.Id);
                }
            }
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