using System.Collections.Generic;
using System.IO;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Writers
{
    static class AutoSwitchAccountListWriter
    {
        internal static void Write(TextWriter writer, AutoSwitchAccountList list, ICollection<SecurityTransaction> securities)
        {
            if (list != null && list.autoSwitchAccounts.Count > 0)
            {
                // Following the order that Quicken 2013 uses,
                // first is just a list of the accounts themselves
                writer.WriteLine(Headers.OptionAutoswitch);
                writer.WriteLine(Headers.AccountList);
                foreach (AutoSwitchAccount acct in list.autoSwitchAccounts)
                {
                    AccountListWriter.Write(writer, acct.accountListTransaction, false);
                }
                writer.WriteLine(Headers.ClearAutoswitch);

                // then comes investment secuirties
                SecurityListWriter.Write(writer, securities);

                // then, for each account, its transactions
                writer.WriteLine(Headers.OptionAutoswitch);
                foreach (AutoSwitchAccount acct in list.autoSwitchAccounts)
                {
                    if (!string.IsNullOrEmpty(acct.accountListTransaction.Name))
                    {
                        if (acct.HasTransactions())
                        {
                            writer.WriteLine(Headers.AccountList);
                            AccountListWriter.Write(writer, acct.accountListTransaction, true);

                            BasicTransactionWriter.Write(writer, Headers.Asset, acct.AssetTransactions);
                            BasicTransactionWriter.Write(writer, Headers.Bank, acct.BankTransactions);
                            BasicTransactionWriter.Write(writer, Headers.Cash, acct.CashTransactions);
                            BasicTransactionWriter.Write(writer, Headers.CreditCard, acct.CreditCardTransactions);
                            BasicTransactionWriter.Write(writer, Headers.Liability, acct.LiabilityTransactions);
                            InvestmentWriter.Write(writer, acct.InvestmentTransactions);
                        }
                    }
                }
                writer.WriteLine(Headers.ClearAutoswitch);
            }
        }
    }
}
