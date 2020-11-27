
namespace QifDoc.Qif.Transactions.Fields
{
    /// <summary>
    /// The memorized transaction list fields used in transactions.
    /// </summary>
    public static class MemorizedTransactionListFields
    {
        /// <summary>
        /// Transaction
        /// </summary>
        public const char Transaction = 'K';
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
        /// Category or Transfer/Class
        /// </summary>
        public const char Category = 'L';
        /// <summary>
        /// Category/class in split
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
        /// Percentage of split
        /// </summary>
        public const char SplitPercentage = '%';
        /// <summary>
        /// Amortization: First payment date
        /// </summary>
        public const char AmortizationFirstPaymentDate = '1';
        /// <summary>
        /// Amortization: Total years for loan
        /// </summary>
        public const char AmortizationTotalYearsForLoan = '2';
        /// <summary>
        /// Amortization: Number of payments already made
        /// </summary>
        public const char AmortizationNumberOfPaymentsAlreadyMade = '3';
        /// <summary>
        /// Amortization: Number of periods per year
        /// </summary>
        public const char AmortizationNumberOfPeriodsPerYear = '4';
        /// <summary>
        /// Amortization: Interest rate
        /// </summary>
        public const char AmortizationInterestRate = '5';
        /// <summary>
        /// Amortization: Current loan balance
        /// </summary>
        public const char AmortizationCurrentLoanBalance = '6';
        /// <summary>
        /// Amortization: Original loan amount
        /// </summary>
        public const char AmortizationOriginalLoanAmount = '7';
    }
}
