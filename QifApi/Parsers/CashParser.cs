using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    class CashParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, Item);
            Item = new BasicTransaction();
        }
    }
}