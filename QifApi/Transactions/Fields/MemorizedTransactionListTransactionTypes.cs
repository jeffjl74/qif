namespace QifDoc.Qif.Transactions.Fields
{
    /// <summary>
    /// The memorized transaction list transaction types.
    /// </summary>
    public static class MemorizedTransactionListTransactionTypes
    {
        /// <summary>
        /// Check transaction
        /// </summary>
        public const string Check = "C";

        /// <summary>
        /// Deposit transaction
        /// </summary>
        public const string Deposit = "D";

        /// <summary>
        /// Payment transaction
        /// </summary>
        public const string Payment = "P";

        /// <summary>
        /// Investment transaction
        /// </summary>
        public const string Investment = "I";

        /// <summary>
        /// Electronic payee transaction
        /// </summary>
        public const string ElectronicPayee = "E";
    }
}