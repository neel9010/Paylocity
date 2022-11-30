using Paylocity.Domain.Implementations;

namespace Paylocity.Domain.Interfaces
{
    public interface IPayCheck
    {
        Guid Id { get; set; }
        Employee Employee { get; set; }
        decimal GrossPay { get; set; }
        decimal Deductions { get; set; }
        decimal NetPay { get; set; }
    }
}