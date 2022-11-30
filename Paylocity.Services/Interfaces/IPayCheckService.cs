using Paylocity.Domain.Implementations;

namespace Paylocity.Services.Interfaces
{
    /// <summary>
    /// Service for Employee PayChecks
    /// </summary>
    public interface IPayCheckService
    {
        /// <summary>
        /// Generate Pay Check
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Employee PayCheck</returns>
        Task<PayCheck> CreatePayCheck(Guid employeeId);

        /// <summary>
        /// Calculate Check
        /// </summary>
        /// <param name="payCheck">Employee PayCheck</param>
        void CalculateCheck(PayCheck payCheck);

        /// <summary>
        /// Update Pay Check
        /// </summary>
        /// <param name="payCheck">Paycheck Id</param>
        /// <returns>Updated Employee PayCheck</returns>
        Task<PayCheck> UpdatePayCheck(Guid checkId);
    }
}