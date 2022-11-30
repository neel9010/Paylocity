using Paylocity.Domain.Enums;

namespace Paylocity.Domain.Interfaces
{
    public interface IPerson
    {
        Guid Id { get; set; }
        string Name { get; set; }

        PersonType PersonType { get; set; }
    }
}