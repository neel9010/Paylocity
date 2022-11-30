namespace Paylocity.Domain.Enums
{
    /// <summary>
    /// Types of valid pay frequencies
    /// </summary>
    public enum PayFrequency
    {
        /// <summary>
        /// Yearly
        /// </summary>
        Yearly = 1,

        /// <summary>
        /// Monthly
        /// </summary>
        Monthly = 12,

        /// <summary>
        /// BiWeekly
        /// </summary>
        BiWeekly = 26,

        /// <summary>
        /// Weekly
        /// </summary>
        Weekly = 52
    }
}