
namespace Hazzik.Qif.Transactions.Fields
{
    /// <summary>
    /// The category list fields used in transactions.
    /// </summary>
    public static class SecurityFields
    {
        /// <summary>
        /// Security name / description
        /// </summary>
        public const char SecurityName = 'N';
        /// <summary>
        /// Symbol / ticker
        /// </summary>
        public const char Symbol = 'S';
        /// <summary>
        /// Security Type (Bond, CD, Mutual Fund, Stock, Option)
        /// </summary>
        public const char SecurityType = 'T';
        /// <summary>
        /// Security Goal (College Fund, High Risk, Income, Low Risk)
        /// </summary>
        public const char SecurityGoal = 'G';
    }
}
