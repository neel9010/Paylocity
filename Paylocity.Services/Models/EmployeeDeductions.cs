namespace Paylocity.Services.Model
{
    public class EmployeeDeductions
    {
        public decimal Compensation { get; set; }
        public IReadOnlyDictionary<Guid, decimal> DeductionInformation { get; set; } = new Dictionary<Guid, decimal>();
        public decimal TotalDeductions { get; set; }
    }
}