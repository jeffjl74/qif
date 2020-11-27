
namespace QifDoc.Qif.Transactions
{
    /// <summary>
    /// The transaction type headers.
    /// </summary>
    public static class Headers
    {
        /// <summary>
        /// Bank account transactions
        /// </summary>
        public const string Bank = "!Type:Bank";
        /// <summary>
        /// Cash account transactions
        /// </summary>
        public const string Cash = "!Type:Cash";
        /// <summary>
        /// Credit card account transactions
        /// </summary>
        public const string CreditCard = "!Type:CCard";
        /// <summary>
        /// Investment account transactions
        /// </summary>
        public const string Investment = "!Type:Invst";
        /// <summary>
        /// Asset account transactions
        /// </summary>
        public const string Asset = "!Type:Oth A";
        /// <summary>
        /// Liability account transactions
        /// </summary>
        public const string Liability = "!Type:Oth L";
        /// <summary>
        /// Account list or which account follows
        /// </summary>
        public const string AccountList = "!Account";
        /// <summary>
        /// Category list
        /// </summary>
        public const string CategoryList = "!Type:Cat";
        /// <summary>
        /// Class list
        /// </summary>
        public const string ClassList = "!Type:Class";
        /// <summary>
        /// Memorized transaction list
        /// </summary>
        public const string MemorizedTransactionList = "!Type:Memorized";
        /// <summary>
        /// Security list
        /// </summary>
        public const string SecurityList = "!Type:Security";
        /// <summary>
        /// Tag list
        /// </summary>
        public const string TagList = "!Type:Tag";
        /// <summary>
        /// Security Prices list
        /// </summary>
        public const string PriceList = "!Type:Prices";
        /// <summary>
        /// Start of the Accounts list
        /// </summary>
        public const string OptionAutoswitch = "!Option:AutoSwitch";
        /// <summary>
        /// End of the Accounts list
        /// </summary>
        public const string ClearAutoswitch = "!Clear:AutoSwitch";
    }
}
