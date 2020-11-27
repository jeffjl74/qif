
namespace QifDoc.Qif.Transactions.Fields
{
    /// <summary>
    /// The account information fields used in transactions.
    /// </summary>
    public static class AccountInformationFields
    {
        /// <summary>
        /// Name
        /// </summary>
        public const char Name = 'N';
        /// <summary>
        /// Type of account
        /// </summary>
        public const char AccountType = 'T';
        /// <summary>
        /// Description
        /// </summary>
        public const char Description = 'D';
        /// <summary>
        /// Only for credit card account
        /// </summary>
        public const char CreditLimit = 'L';
        /// <summary>
        /// Statement balance date
        /// </summary>
        public const char StatementBalanceDate = '/';
        /// <summary>
        /// Statement balance
        /// </summary>
        public const char StatementBalance = '$';
    }
}
