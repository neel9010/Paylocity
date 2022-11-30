using Paylocity.Domain.Enums;
using Paylocity.Domain.Interfaces;

namespace Paylocity.Domain.Implementations
{
    public class Employee : IPerson, IPayable
    {
        public Employee()
        {
            Dependents = new List<Dependent>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public PayFrequency PayFrequency { get; set; }
        public decimal Compensation { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}