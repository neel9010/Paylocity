using Paylocity.Domain.Enums;
using Paylocity.Domain.Interfaces;

namespace Paylocity.Domain.Implementations
{
    public class Dependent : IPerson, IDependent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public Guid EmployeeId { get; set; }
    }
}