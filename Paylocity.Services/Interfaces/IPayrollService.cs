using Paylocity.Services.Model;

namespace Paylocity.Services.Interfaces
{
    /// <summary>
    /// Service for Running Payroll
    /// </summary>
    public interface IPayrollService
    {
        /// <summary>
        /// Run Payroll
        /// </summary>
        /// <returns>Starts the Payroll Process</returns>
        Task RunPayroll();

        /// <summary>
        /// View Deduction Costs for employee
        /// </summary>
        /// <param name="personId">Enrolled Person Id</param>
        /// <returns></returns>
        Task<EmployeeDeductions> ViewDeductionCosts(Guid personId);
    }
}