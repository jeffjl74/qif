using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Parsers
{
    class MemorizedTransactionListParser : IParser
    {
        private MemorizedTransactionListTransaction item = new MemorizedTransactionListTransaction();

        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new MemorizedTransactionListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case MemorizedTransactionListFields.Address:
                    item.Address.Add(value);
                    break;
                case MemorizedTransactionListFields.AmortizationCurrentLoanBalance:
                    item.AmortizationCurrentLoanBalance = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationFirstPaymentDate:
                    item.AmortizationFirstPaymentDate = Common.GetDateTime(value);
                    break;
                case MemorizedTransactionListFields.AmortizationInterestRate:
                    item.AmortizationInterestRate = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationNumberOfPaymentsAlreadyMade:
                    item.AmortizationNumberOfPaymentsAlreadyMade = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationNumberOfPeriodsPerYear:
                    item.AmortizationNumberOfPeriodsPerYear = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationOriginalLoanAmount:
                    item.AmortizationOriginalLoanAmount = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmortizationTotalYearsForLoan:
                    item.AmortizationTotalYearsForLoan = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.Amount:
                    item.Amount = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.AmountU:
                    item.AmountU = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.Category:
                    item.Category = value;
                    break;
                case MemorizedTransactionListFields.Transaction:
                    switch (value)
                    {
                        case MemorizedTransactionListTransactionTypes.Check:
                            item.Type = TransactionType.Check;
                            break;
                        case MemorizedTransactionListTransactionTypes.Deposit:
                            item.Type = TransactionType.Deposit;
                            break;
                        case MemorizedTransactionListTransactionTypes.ElectronicPayee:
                            item.Type = TransactionType.ElectronicPayee;
                            break;
                        case MemorizedTransactionListTransactionTypes.Investment:
                            item.Type = TransactionType.Investment;
                            break;
                        case MemorizedTransactionListTransactionTypes.Payment:
                            item.Type = TransactionType.Payment;
                            break;
                    }
                    break;
                case MemorizedTransactionListFields.ClearedStatus:
                    item.ClearedStatus = value;
                    break;
                case MemorizedTransactionListFields.Memo:
                    item.Memo = value;
                    break;
                case MemorizedTransactionListFields.Payee:
                    item.Payee = value;
                    break;
                case MemorizedTransactionListFields.SplitAmount:
                    //item.SplitAmounts.Add(item.SplitAmounts.Count, Common.GetDecimal(value));
                    if (item.Splits.Count > 0)
                        item.Splits[item.Splits.Count - 1].Amount = Common.GetDecimal(value);
                    break;
                case MemorizedTransactionListFields.SplitCategory:
                    //item.SplitCategories.Add(item.SplitCategories.Count, value);
                    item.Splits.Add(new SplitTransaction { Category = value });
                    break;
                case MemorizedTransactionListFields.SplitMemo:
                    //item.SplitMemos.Add(item.SplitAmounts.Count, value);
                    if (item.Splits.Count > 0)
                        item.Splits[item.Splits.Count - 1].Memo = value;
                    break;
                default:
                    item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}