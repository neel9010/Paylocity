namespace Paylocity.Services.Helpers
{
    /// <summary>
    /// Helpers for services
    /// </summary>
    public static class FormatHelpers
    {
        /// <summary>
        /// Format Decimal Amount
        /// </summary>
        /// <param name="amount">Amount to Format</param>
        /// <returns>Formated Decimal Amount to 2 decimal places</returns>
        public static decimal FormatAmount(this decimal amount)
        {
            return decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}