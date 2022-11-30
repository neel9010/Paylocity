using Paylocity.Domain.Enums;
using Paylocity.Domain.Implementations;
using Paylocity.Domain.Interfaces;
using Paylocity.Services.Constants;
using Paylocity.Services.Helpers;
using Paylocity.Services.Interfaces;

namespace Paylocity.Services.Impementations
{
    public class DeductionService : IDeductionService
    {
        public decimal CalculateDeductionAmount(decimal discountRate, decimal deductionCost, PayFrequency payFrequency)
        {
            decimal discountedAmount = deductionCost * discountRate;
            decimal deductionAmount = (deductionCost - discountedAmount) / (decimal)payFrequency;
            return deductionAmount;
        }

        public decimal GetDeductionCost(IPerson person)
        {
            return person.PersonType switch
            {
                PersonType.Employee => DeductionCosts.EMPLOYEE_COST,
                PersonType.Spouse => DeductionCosts.SPOUSE_COST,
                PersonType.Child => DeductionCosts.CHILD_COST,
                _ => 0m,
            };
        }

        public decimal GetDiscountRate(IPerson person)
        {
            if (person.Name.ToLower().StartsWith("a"))
            {
                return DiscountRates.TEN_PERCENT_DISCOUNT;
            }

            return DiscountRates.NO_DISCOUNT;
        }

        public decimal CalculateDeductionPerPerson(IPerson person, PayFrequency payFrequency)
        {
            decimal deductionRate = GetDiscountRate(person);
            decimal deductionCost = GetDeductionCost(person);
            decimal deductionAmount = CalculateDeductionAmount(deductionRate, deductionCost, payFrequency);

            return deductionAmount.FormatAmount();
        }

        public IReadOnlyDictionary<Guid, decimal> GetDeductionCosts(IPerson person)
        {
            Dictionary<Guid, decimal> costs = new();
            decimal deductionCost;

            if (person is IPayable)
            {
                Employee employee = (Employee)person;
                deductionCost = CalculateDeductionPerPerson(person, employee.PayFrequency);
                costs.Add(employee.Id, deductionCost);

                // Dependents Calculation
                foreach (var dependent in employee.Dependents)
                {
                    deductionCost = CalculateDeductionPerPerson(dependent, employee.PayFrequency);
                    costs.Add(dependent.Id, deductionCost);
                }
            }
            else
            {
                // Default calculate for bi-weekly (26) pay period for any type of person
                deductionCost = CalculateDeductionPerPerson(person, PayFrequency.BiWeekly);
                costs.Add(person.Id, deductionCost);
            }

            return costs;
        }

        public decimal GetTotalDeductionAmount(IPerson person)
        {
            decimal deductionAmount = 0;
            IReadOnlyDictionary<Guid, decimal> deductionCosts = GetDeductionCosts(person);

            if (deductionCosts != null)
            {
                deductionAmount = deductionCosts.Sum(x => x.Value);
            }

            return deductionAmount;
        }
    }
}