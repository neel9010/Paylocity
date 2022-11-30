using Paylocity.Data.Interfaces;
using Paylocity.Domain.Implementations;

namespace Paylocity.Data.Implementations
{
    /// <summary>
    /// <see cref="IPayCheckRepository"/> Implementation
    /// </summary>
    /// <seealso cref="IPayCheckRepository" />
    public class PayCheckRepository : IPayCheckRepository
    {
        /// <inheritdoc />
        public Task<PayCheck> CreateCheck(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<PayCheck> UpdateCheck(Guid checkId)
        {
            throw new NotImplementedException();
        }
    }
}