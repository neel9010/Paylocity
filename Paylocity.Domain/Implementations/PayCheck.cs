using Paylocity.Domain.Interfaces;

namespace Paylocity.Domain.Implementations
{
    public class PayCheck : IPayCheck
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public decimal GrossPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
    }
}