using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Parsers
{
    /// <summary>
    /// Parses a <see cref="Headers.TagList"/> record into a <see cref="PriceRecord"/> which is added to the document when <see cref="Yield(QifDocument)"/> is called.
    /// </summary>
    class PriceParser : IParser
    {
        private PriceRecord item = new PriceRecord();

        /// <summary>
        /// Adds the current <see cref="PriceRecord"/> to the passed <see cref="QifDocument"/>
        /// </summary>
        /// <param name="document"><see cref="QifDocument"/> to which the transaction is added</param>
        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new PriceRecord();
        }

        /// <summary>
        /// Parse the passed string into the appropriate <see cref="PriceRecord"/> field.
        /// </summary>
        /// <param name="line">Line of text from a QIF file.</param>
        public void ParseLine(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                item.Symbol = parts[0].Trim('"');
                if(parts[1].Length > 0)
                    item.Price = Common.GetDecimal(parts[1]);
                string dt = parts[2].Trim('"');
                if (dt.Length > 0)
                    item.PriceDate = Common.GetDateTime(dt);
            }
        }
    }
}