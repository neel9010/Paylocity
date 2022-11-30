using Paylocity.Data.Interfaces;
using Paylocity.Domain.Implementations;
using Paylocity.Services.Interfaces;

namespace Paylocity.Services.Impementations
{
    public class PayCheckService : IPayCheckService
    {
        private readonly IPayCheckRepository _payCheckRepository;
        private readonly IDeductionService _deductionService;

        public PayCheckService(IPayCheckRepository payCheckRepository, IDeductionService deductionService)
        {
            _payCheckRepository = payCheckRepository;
            _deductionService = deductionService;
        }

        public async Task<PayCheck> CreatePayCheck(Guid employeeId)
        {
            return await _payCheckRepository.CreateCheck(employeeId);
        }

        public async Task<PayCheck> UpdatePayCheck(Guid checkId)
        {
            return await _payCheckRepository.UpdateCheck(checkId);
        }

        public void CalculateCheck(PayCheck payCheck)
        {
            Employee employee = payCheck.Employee;
            payCheck.GrossPay = employee.Compensation;
            payCheck.Deductions = _deductionService.GetTotalDeductionAmount(employee);
            payCheck.NetPay = payCheck.GrossPay - payCheck.Deductions;
        }
    }
}