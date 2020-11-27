
namespace Hazzik.Qif.Transactions.Fields
{
    /// <summary>
    /// The non-investment account fields used in transactions.
    /// </summary>
    public static class NonInvestmentAccountFields
    {
        /// <summary>
        /// Date
        /// </summary>
        public const char Date = 'D';
        /// <summary>
        /// Amount
        /// </summary>
        public const char Amount = 'T';
        /// <summary>
        /// Amount from the U line
        /// </summary>
        public const char AmountU = 'U';
        /// <summary>
        /// Cleared status
        /// </summary>
        public const char ClearedStatus = 'C';
        /// <summary>
        /// Check, reference number, or transaction type
        /// </summary>
        public const char Number = 'N';
        /// <summary>
        /// Payee
        /// </summary>
        public const char Payee = 'P';
        /// <summary>
        /// Memo
        /// </summary>
        public const char Memo = 'M';
        /// <summary>
        /// Up to five lines; the sixth line is an optional message
        /// </summary>
        public const char Address = 'A';
        /// <summary>
        /// Category/Subcategory/Transfer/Class
        /// </summary>
        public const char Category = 'L';
        /// <summary>
        /// Category/Transfer/Class
        /// </summary>
        public const char SplitCategory = 'S';
        /// <summary>
        /// Memo in split
        /// </summary>
        public const char SplitMemo = 'E';
        /// <summary>
        /// Dollar amount of split
        /// </summary>
        public const char SplitAmount = '$';
        /// <summary>
        /// Split percetange
        /// </summary>
        public const char SplitPercentage = '%';
    }
}
