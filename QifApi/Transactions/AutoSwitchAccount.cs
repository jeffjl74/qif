using System.Collections.Generic;
using QifDoc.Qif.Transactions;

namespace QifDoc.Qif
{
    /// <summary>
    /// This class contains a single <see cref="AccountListTransaction"/> plus lists for each transaction type
    /// that can be tied to an account via !Option:AutoSwitch.
    /// </summary>
    public class AutoSwitchAccount
    {
        /// <summary>
        /// Represents the account to which the transaction lists apply.
        /// </summary>
        public AccountListTransaction accountListTransaction;

        /// <summary>
        /// Represents a collection of bank transactions.
        /// </summary>
        public List<BasicTransaction> BankTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of cash transactions.
        /// </summary>
        public List<BasicTransaction> CashTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of credit card transactions.
        /// </summary>
        public List<BasicTransaction> CreditCardTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of investment transactions.
        /// </summary>
        public List<InvestmentTransaction> InvestmentTransactions = new List<InvestmentTransaction>();

        /// <summary>
        /// Represents a collection of asset transactions.
        /// </summary>
        public List<BasicTransaction> AssetTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of liability transactions.
        /// </summary>
        public List<BasicTransaction> LiabilityTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Constructor sets the account to which transactions are associated.
        /// </summary>
        /// <param name="acct">Account to which the following transactions are added</param>
        public AutoSwitchAccount(AccountListTransaction acct)
        {
            accountListTransaction = acct;
        }

        /// <returns>
        /// True if the account has any transactions.
        /// False if the account has zero transactions.
        /// </returns>
        public bool HasTransactions()
        {
            return BankTransactions.Count > 0
                || CashTransactions.Count > 0
                || CreditCardTransactions.Count > 0
                || InvestmentTransactions.Count > 0
                || AssetTransactions.Count > 0
                || LiabilityTransactions.Count > 0
                ;
        }

        /// <returns>The name of the account</returns>
        public override string ToString()
        {
            return accountListTransaction.ToString();
        }
    }
}
