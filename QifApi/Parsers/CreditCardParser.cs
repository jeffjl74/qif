using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    class CreditCardParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, Item);
            Item = new BasicTransaction();
        }
    }
}