using Paylocity.Domain.Enums;
using Paylocity.Domain.Implementations;

namespace Paylocity.Domain.Interfaces
{
    public interface IPayable
    {
        decimal Compensation { get; set; }
        PayFrequency PayFrequency { get; set; }
        List<Dependent> Dependents { get; set; }
    }
}