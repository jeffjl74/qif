using QifDoc.Qif.Transactions;

namespace QifDoc.Qif.Parsers
{
    class AssetParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, Item);
            Item = new BasicTransaction();
        }
    }
}