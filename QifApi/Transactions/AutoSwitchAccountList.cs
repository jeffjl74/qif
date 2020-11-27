using System.Collections.Generic;
using Hazzik.Qif.Parsers;
using Hazzik.Qif.Transactions;

namespace Hazzik.Qif
{
    /// <summary>
    /// Represents a list of <see cref="AutoSwitchAccount"/>s.
    /// </summary>
    public class AutoSwitchAccountList
    {
        /// <summary>
        /// List of AutoSwitchAccount
        /// </summary>
        public IList<AutoSwitchAccount> autoSwitchAccounts = new List<AutoSwitchAccount>();

        /// <summary>
        /// The index of the autoSwitchAccounts list for the account currently accepting transactions.
        /// </summary>
        private int currentAccount = -1;

        /// <summary>
        /// Sets the account to which <see cref="AddTransaction(string,object)"/> will subsequently add transactions.
        /// Adds the account to the account list if absent.
        /// </summary>
        /// <param name="setAcct">The AccountListTransaction of the account to make current or add.</param>
        /// <returns></returns>
        private void SetCurrentAccount(AccountListTransaction setAcct)
        {
            currentAccount = -1;
            for (int i = 0; i < autoSwitchAccounts.Count; i++)
            {
                if (autoSwitchAccounts[i].accountListTransaction.ToString().Equals(setAcct.ToString()))
                {
                    currentAccount = i;
                    break;
                }
            }
            if (currentAccount == -1)
            {
                AutoSwitchAccount qifAccount = new AutoSwitchAccount(setAcct);
                autoSwitchAccounts.Add(qifAccount);
                currentAccount = autoSwitchAccounts.Count - 1;
            }
        }

        /// <summary>
        /// <para>If the transaction is of a type that is linked to an account, adds the transaction to the current account.</para>
        /// <para>This method is typically called to add transactions to the account when !Option:AutoSwitch is active.</para>
        /// </summary>
        /// <remarks>
        /// If the transaction is an <see cref="AccountListTransaction", the account to which transactions will be
        /// added is selected.
        /// </remarks>
        /// <param name="parserName">The name of the parser that generated the transaction.</param>
        /// <param name="transaction">The transaction to be added.</param>
        /// <returns>
        /// 'true' if the tranasaction was added to an account.
        /// 'false' if the transaction is of a type that does not associate to an account.
        /// </returns>
        public bool AddTransaction(string parserName, object transaction)
        {
            bool result = false;

            //if it's an account record, need this outside of the if(currentAccount >= 0) check
            if(parserName == typeof(AccountListParser).Name)
            {
                SetCurrentAccount((AccountListTransaction)transaction);
                result = true;
            }
            else if (currentAccount >= 0)
            {
                result = true; //assume it gets processed, will become false if it's not a tracked acct type

                if (parserName == typeof(BankParser).Name)
                    autoSwitchAccounts[currentAccount].BankTransactions.Add((BasicTransaction)transaction);
                else if (parserName == typeof(CashParser).Name)
                    autoSwitchAccounts[currentAccount].CashTransactions.Add((BasicTransaction)transaction);
                else if (parserName == typeof(CreditCardParser).Name)
                    autoSwitchAccounts[currentAccount].CreditCardTransactions.Add((BasicTransaction)transaction);
                else if (parserName == typeof(AssetParser).Name)
                    autoSwitchAccounts[currentAccount].AssetTransactions.Add((BasicTransaction)transaction);
                else if (parserName == typeof(LiabilityParser).Name)
                    autoSwitchAccounts[currentAccount].LiabilityTransactions.Add((BasicTransaction)transaction);
                else if (parserName == typeof(InvestmentParser).Name)
                    autoSwitchAccounts[currentAccount].InvestmentTransactions.Add((InvestmentTransaction)transaction);
                else
                    result = false; //not an account-specific transaction
            }
            return result;
        }

        /// <returns>The number of accounts</returns>
        public override string ToString()
        {
            return "Count = " + autoSwitchAccounts.Count.ToString();
        }
    }
}
