using Paylocity.Domain.Implementations;

namespace Paylocity.Data.Interfaces
{
    /// <summary>
    /// Repository for interacting with employees
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get All Employees in Compnay
        /// </summary>
        /// <returns>List of all employees</returns>
        Task<IReadOnlyList<Employee>> GetAllEmployees();

        /// <summary>
        /// Get Sigle Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee based on employee id</returns>
        Task<Employee> GetEmployeeById(Guid id);
    }
}