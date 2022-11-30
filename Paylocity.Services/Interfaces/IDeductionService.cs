using Paylocity.Domain.Enums;
using Paylocity.Domain.Interfaces;

namespace Paylocity.Services.Interfaces
{
    /// <summary>
    /// Service for employee deductions
    /// </summary>
    public interface IDeductionService
    {
        /// <summary>
        /// Get discount rate for a person
        /// </summary>
        /// <param name="Person">Person</param>
        /// <returns>Discount Rate for person</returns>
        decimal GetDiscountRate(IPerson Person);

        /// <summary>
        /// Get Deduction Cost for a person
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>Discount Rate for person</returns>
        decimal GetDeductionCost(IPerson person);

        /// <summary>
        /// Calculate Deduction Amount
        /// </summary>
        /// <param name="discountRate">Discount Rate</param>
        /// <param name="deductionCost">Deduction Cost</param>
        /// <param name="payFrequency">Pay Frequency</param>
        /// <returns></returns>
        decimal CalculateDeductionAmount(decimal discountRate, decimal deductionCost, PayFrequency payFrequency);

        /// <summary>
        /// Calculate Deduction Amount Per Person
        /// </summary>
        /// <param name="person">Current Person</param>
        /// <param name="payFrequency">Pay Frequency</param>
        /// <returns>Deduction Amount for a person</returns>
        decimal CalculateDeductionPerPerson(IPerson person, PayFrequency payFrequency);

        /// <summary>
        /// Get Deduction Costs
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>Gets List of deductions for employee and all dependents with their id</returns>
        IReadOnlyDictionary<Guid, decimal> GetDeductionCosts(IPerson person);

        /// <summary>
        /// Get Total Deduction Amount
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>Gets Total Deduction Amount for employee</returns>
        decimal GetTotalDeductionAmount(IPerson person);
    }
}