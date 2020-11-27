using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    static class InvestmentWriter
    {
        internal static void Write(TextWriter writer, ICollection<InvestmentTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.Investment);

                foreach (InvestmentTransaction item in list)
                {
                    writer.WriteLine($"{InvestmentAccountFields.Date}{item.Date:d}");

                    if (!string.IsNullOrEmpty(item.Action))
                    {
                        writer.Write(InvestmentAccountFields.Action);
                        writer.WriteLine(item.Action);
                    }

                    if (!string.IsNullOrEmpty(item.TextFirstLine))
                    {
                        writer.Write(InvestmentAccountFields.TextFirstLine);
                        writer.WriteLine(item.TextFirstLine);
                    }

                    if (!string.IsNullOrEmpty(item.Security))
                    {
                        writer.Write(InvestmentAccountFields.Security);
                        writer.WriteLine(item.Security);
                    }

                    if (item.Price.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.Price}{item.Price}");

                    if (item.Quantity.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.Quantity}{item.Quantity:#,##0.##########}");

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(InvestmentAccountFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    if (item.TransactionAmountU.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.TransactionAmountU}{item.TransactionAmountU:n}");

                    if (item.TransactionAmount.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.TransactionAmount}{item.TransactionAmount:n}");

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(InvestmentAccountFields.Memo);
                        writer.WriteLine(item.Memo);
                    }

                    if (item.Commission.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.Commission}{item.Commission:n}");

                    if (!string.IsNullOrEmpty(item.AccountForTransfer))
                    {
                        writer.Write(InvestmentAccountFields.AccountForTransfer);
                        writer.WriteLine(item.AccountForTransfer);
                    }

                    if (item.AmountTransferred.HasValue)
                        writer.WriteLine($"{InvestmentAccountFields.AmountTransferred}{item.AmountTransferred:n}");

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}