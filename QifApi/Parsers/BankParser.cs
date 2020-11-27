using QifDoc.Qif.Transactions;

namespace QifDoc.Qif.Parsers
{
    class BankParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, Item);
            Item = new BasicTransaction();
        }
    }
}