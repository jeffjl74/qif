using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    static class MemorizedTransactionListWriter
    {
        internal static void Write(TextWriter writer, ICollection<MemorizedTransactionListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.MemorizedTransactionList);

                foreach (MemorizedTransactionListTransaction item in list)
                {
                    writer.Write(MemorizedTransactionListFields.Transaction);
                    switch (item.Type)
                    {
                        case TransactionType.Check:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Check);
                            break;
                        case TransactionType.Deposit:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Deposit);
                            break;
                        case TransactionType.ElectronicPayee:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.ElectronicPayee);
                            break;
                        case TransactionType.Investment:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Investment);
                            break;
                        case TransactionType.Payment:
                            writer.WriteLine(MemorizedTransactionListTransactionTypes.Payment);
                            break;
                    }

                    if(item.AmountU.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmountU}{item.AmountU:n}");

                    if(item.Amount.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.Amount}{item.Amount:n}");

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(MemorizedTransactionListFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.Write(MemorizedTransactionListFields.Payee);
                        writer.WriteLine(item.Payee);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(MemorizedTransactionListFields.Memo);
                        writer.WriteLine(item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.Write(MemorizedTransactionListFields.Category);
                        writer.WriteLine(item.Category);
                    }

                    foreach (string address in item.Address)
                    {
                        writer.Write(MemorizedTransactionListFields.Address);
                        writer.WriteLine(address);
                    }

                    if (item.AmortizationFirstPaymentDate != DateTime.MinValue)
                    {
                        writer.Write(MemorizedTransactionListFields.AmortizationFirstPaymentDate);
                        writer.WriteLine(item.AmortizationFirstPaymentDate.ToString("d", CultureInfo.CurrentCulture));
                    }

                    if (item.AmortizationTotalYearsForLoan.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationTotalYearsForLoan}{item.AmortizationTotalYearsForLoan}");

                    if (item.AmortizationNumberOfPaymentsAlreadyMade.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade}{item.AmortizationNumberOfPaymentsAlreadyMade}");

                    if (item.AmortizationNumberOfPeriodsPerYear.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear}{item.AmortizationNumberOfPeriodsPerYear}");

                    if (item.AmortizationInterestRate.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationInterestRate}{item.AmortizationInterestRate}");

                    if (item.AmortizationCurrentLoanBalance.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationCurrentLoanBalance}{item.AmortizationCurrentLoanBalance}");

                    if (item.AmortizationOriginalLoanAmount.HasValue)
                        writer.WriteLine($"{MemorizedTransactionListFields.AmortizationOriginalLoanAmount}{item.AmortizationOriginalLoanAmount}");

                    foreach (SplitTransaction split in item.Splits)
                    {
                        writer.WriteLine($"{MemorizedTransactionListFields.SplitCategory}{split.Category}");
                        if (!string.IsNullOrEmpty(split.Memo))
                            writer.WriteLine($"{MemorizedTransactionListFields.SplitMemo}{split.Memo}");
                        if (split.Amount.HasValue)
                            writer.WriteLine($"{MemorizedTransactionListFields.SplitAmount}{split.Amount:n}");
                        if (split.Percentage.HasValue)
                            writer.WriteLine($"{MemorizedTransactionListFields.SplitPercentage}{split.Percentage}");
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);

                }
            }
        }
    }
}