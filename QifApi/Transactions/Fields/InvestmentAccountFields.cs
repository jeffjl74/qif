
namespace QifDoc.Qif.Transactions.Fields
{
    /// <summary>
    /// The investment account fields used in transactions.
    /// </summary>
    public static class InvestmentAccountFields
    {
        /// <summary>
        /// Date
        /// </summary>
        public const char Date = 'D';
        /// <summary>
        /// Action
        /// </summary>
        public const char Action = 'N';
        /// <summary>
        /// Security
        /// </summary>
        public const char Security = 'Y';
        /// <summary>
        /// Price
        /// </summary>
        public const char Price = 'I';
        /// <summary>
        /// Number of shares or split ratio
        /// </summary>
        public const char Quantity = 'Q';
        /// <summary>
        /// Transaction amount
        /// </summary>
        public const char TransactionAmount = 'T';
        /// <summary>
        /// Transaction amount from the U line
        /// </summary>
        public const char TransactionAmountU = 'U';
        /// <summary>
        /// Cleared status
        /// </summary>
        public const char ClearedStatus = 'C';
        /// <summary>
        /// Text in the first line for transfers and reminders
        /// </summary>
        public const char TextFirstLine = 'P';
        /// <summary>
        /// Memo
        /// </summary>
        public const char Memo = 'M';
        /// <summary>
        /// Commission
        /// </summary>
        public const char Commission = 'O';
        /// <summary>
        /// Account for the transfer
        /// </summary>
        public const char AccountForTransfer = 'L';
        /// <summary>
        /// Amount transferred
        /// </summary>
        public const char AmountTransferred = '$';
    }
}
