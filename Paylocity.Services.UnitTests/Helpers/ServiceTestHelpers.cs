using Paylocity.Domain.Enums;
using Paylocity.Domain.Implementations;
using Paylocity.Domain.Interfaces;

namespace Paylocity.Services.UnitTests.Helpers
{
    public static class ServiceTestHelpers
    {
        public static Employee GetEmployee()
        {
            var employee = new Employee
            {
                Id = new Guid("48c77891-47ea-44ab-8d55-c643355c2bf6"),
                Name = "A Test Guy",
                PersonType = PersonType.Employee,
                PayFrequency = PayFrequency.BiWeekly,
                Compensation = 2000.00m
            };

            employee.Dependents.AddRange(GetDependents(employee.Id));

            return employee;
        }

        public static List<Dependent> GetDependents(Guid empId)
        {
            List<Dependent> dependents = new();

            Dependent dependent_one = new()
            {
                Id = new Guid("48c77891-47ea-44ab-8d65-c643355c2bf6"),
                EmployeeId = empId,
                Name = "Spouse Dependent",
                PersonType = PersonType.Spouse,
            };
            dependents.Add(dependent_one);

            Dependent dependent_two = new()
            {
                Id = new Guid("48c87891-47ea-44ab-8d65-c643355c2bf6"),
                EmployeeId = empId,
                Name = "A First Child Dependent",
                PersonType = PersonType.Child,
            };
            dependents.Add(dependent_two);

            Dependent dependent_three = new()
            {
                Id = new Guid("48c77897-47ea-44ab-8d65-c643355c2bf6"),
                EmployeeId = empId,
                Name = "Second Child Dependent",
                PersonType = PersonType.Child,
            };
            dependents.Add(dependent_three);

            return dependents;
        }
    }
}