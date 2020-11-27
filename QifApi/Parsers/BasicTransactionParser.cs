using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Parsers
{
    /// <summary>
    /// Abstract class that parses for the <see cref="NonInvestmentAccountFields"/>
    /// </summary>
    abstract class BasicTransactionParser : IParser
    {
        protected BasicTransaction Item = new BasicTransaction();

        public abstract void Yield(QifDocument document);

        public virtual void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case NonInvestmentAccountFields.Date:
                    Item.Date = Common.GetDateTime(value);
                    break;
                case NonInvestmentAccountFields.Amount:
                    Item.Amount = Common.GetDecimal(value);
                    break;
                case NonInvestmentAccountFields.AmountU:
                    Item.AmountU = Common.GetDecimal(value);
                    break;
                case NonInvestmentAccountFields.ClearedStatus:
                    Item.ClearedStatus = value;
                    break;
                case NonInvestmentAccountFields.Number:
                    Item.Number = value;
                    break;
                case NonInvestmentAccountFields.Payee:
                    Item.Payee = value;
                    break;
                case NonInvestmentAccountFields.Memo:
                    Item.Memo = value;
                    break;
                case NonInvestmentAccountFields.Category:
                    Item.Category = value;
                    break;
                case NonInvestmentAccountFields.Address:
                    Item.Address.Add(value);
                    break;
                case NonInvestmentAccountFields.SplitCategory:
                    Item.Splits.Add(new SplitTransaction { Category = value });
                    break;
                case NonInvestmentAccountFields.SplitMemo:
                    if(Item.Splits.Count > 0)
                        Item.Splits[Item.Splits.Count - 1].Memo = value;
                    break;
                case NonInvestmentAccountFields.SplitAmount:
                    if (Item.Splits.Count > 0)
                        Item.Splits[Item.Splits.Count - 1].Amount = Common.GetDecimal(value);
                    break;
                default:
                    Item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}