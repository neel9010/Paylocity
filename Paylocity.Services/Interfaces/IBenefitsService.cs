using Paylocity.Services.Model;

namespace Paylocity.Services.Interfaces
{
    /// <summary>
    /// Service for Employee Benefits
    /// </summary>
    public interface IBenefitsService
    {
        /// <summary>
        /// Employee Enrollment Process
        /// </summary>
        /// <param name="personId">Enrolled Person Id</param>
        /// <returns></returns>
        Task Enroll(Guid personId);

        /// <summary>
        /// View Deduction Costs for employee
        /// </summary>
        /// <param name="personId">Enrolled Person Id</param>
        /// <returns></returns>
        Task<EmployeeDeductions> ViewDeductionCosts(Guid personId);
    }
}