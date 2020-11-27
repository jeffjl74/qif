using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
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