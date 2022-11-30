using Paylocity.Domain.Implementations;

namespace Paylocity.Data.Interfaces
{
    /// <summary>
    /// Repository for interacting with employee checks
    /// </summary>
    public interface IPayCheckRepository
    {
        /// <summary>
        /// Create an employee check
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Check for the current employee</returns>
        Task<PayCheck> CreateCheck(Guid employeeId);

        /// <summary>
        /// Update an employee check
        /// </summary>
        /// <param name="payCheck">check id</param>
        /// <returns>Updated Employee Check</returns>
        Task<PayCheck> UpdateCheck(Guid checkId);
    }
}