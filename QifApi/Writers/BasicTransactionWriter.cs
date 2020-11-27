using System.Collections.Generic;
using System.Globalization;
using System.IO;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Writers
{
    static class BasicTransactionWriter
    {
        internal static void Write(TextWriter writer, string type, ICollection<BasicTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(type);

                foreach (var item in list)
                {
                    writer.WriteLine($"{NonInvestmentAccountFields.Date}{item.Date:d}");

                    if (item.AmountU.HasValue)
                        writer.WriteLine($"{NonInvestmentAccountFields.AmountU}{item.AmountU:n}");

                    writer.WriteLine($"{NonInvestmentAccountFields.Amount}{item.Amount:n}");

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(NonInvestmentAccountFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Number))
                    {
                        writer.Write(NonInvestmentAccountFields.Number);
                        writer.WriteLine(item.Number);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.Write(NonInvestmentAccountFields.Payee);
                        writer.WriteLine(item.Payee);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(NonInvestmentAccountFields.Memo);
                        writer.WriteLine(item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.Write(NonInvestmentAccountFields.Category);
                        writer.WriteLine(item.Category);
                    }

                    foreach (string address in item.Address)
                    {
                        writer.Write(NonInvestmentAccountFields.Address);
                        writer.WriteLine(address);
                    }

                    foreach (SplitTransaction split in item.Splits)
                    {
                        writer.WriteLine($"{NonInvestmentAccountFields.SplitCategory}{split.Category}");
                        if (!string.IsNullOrEmpty(split.Memo))
                            writer.WriteLine($"{NonInvestmentAccountFields.SplitMemo}{split.Memo}");
                        if (split.Amount.HasValue)
                            writer.WriteLine($"{NonInvestmentAccountFields.SplitAmount}{split.Amount:n}");
                        if (split.Percentage.HasValue)
                            writer.WriteLine($"{NonInvestmentAccountFields.SplitPercentage}{split.Percentage}");
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}