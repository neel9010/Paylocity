using Paylocity.Data.Interfaces;
using Paylocity.Data.MockData;
using Paylocity.Domain.Implementations;

namespace Paylocity.Data.Implementations
{
    /// <summary>
    /// <see cref="IEmployeeRepository"/> Implementation
    /// </summary>
    /// <seealso cref="IEmployeeRepository" />
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <inheritdoc />
        public async Task<IReadOnlyList<Employee>> GetAllEmployees()
        {
            // Mock Data
            List<Employee> employeeList = new()
            {
                EmployeeMockData.GetEmployee()
            };

            return employeeList;
        }

        /// <inheritdoc />
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            // Mock Data
            return EmployeeMockData.GetEmployee();
        }
    }
}