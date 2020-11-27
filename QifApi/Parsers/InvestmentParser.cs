using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Parsers
{
    /// <summary>
    /// Parses a <see cref="Headers.Investment"/> record into a <see cref="InvestmentTransaction"/> which is added to the document when <see cref="Yield(QifDocument)"/> is called.
    /// </summary>
    class InvestmentParser : IParser
    {
        private InvestmentTransaction item = new InvestmentTransaction();

        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new InvestmentTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case InvestmentAccountFields.Action:
                    item.Action = value;
                    break;
                case InvestmentAccountFields.ClearedStatus:
                    item.ClearedStatus = value;
                    break;
                case InvestmentAccountFields.Commission:
                    item.Commission = Common.GetDecimal(value);
                    break;
                case InvestmentAccountFields.Date:
                    item.Date = Common.GetDateTime(value);
                    break;
                case InvestmentAccountFields.Memo:
                    item.Memo = value;
                    break;
                case InvestmentAccountFields.Price:
                    item.Price = Common.GetDecimal(value);
                    break;
                case InvestmentAccountFields.Quantity:
                    item.Quantity = Common.GetDecimal(value);
                    break;
                case InvestmentAccountFields.Security:
                    item.Security = value;
                    break;
                case InvestmentAccountFields.TextFirstLine:
                    item.TextFirstLine = value;
                    break;
                case InvestmentAccountFields.TransactionAmount:
                    item.TransactionAmount = Common.GetDecimal(value);
                    break;
                case InvestmentAccountFields.TransactionAmountU:
                    item.TransactionAmountU = Common.GetDecimal(value);
                    break;
                case InvestmentAccountFields.AccountForTransfer:
                    item.AccountForTransfer = value;
                    break;
                case InvestmentAccountFields.AmountTransferred:
                    item.AmountTransferred = Common.GetDecimal(value);
                    break;
                default:
                    item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}