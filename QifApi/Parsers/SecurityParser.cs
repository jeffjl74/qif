using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Parsers
{
    /// <summary>
    /// Parses a <see cref="Headers.SecurityList"/> record into a <see cref="SecurityTransaction"/> which is added to the document when <see cref="Yield(QifDocument)"/> is called.
    /// </summary>
    class SecurityParser : IParser
    {
        private SecurityTransaction item = new SecurityTransaction();

        /// <summary>
        /// Adds the current <see cref="SecurityTransaction"/> to the passed <see cref="QifDocument"/>
        /// </summary>
        /// <param name="document"><see cref="QifDocument"/> to which the transaction is added</param>
        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new SecurityTransaction();
        }

        /// <summary>
        /// Parse the passed string into the appropriate <see cref="SecurityTransaction"/> field.
        /// </summary>
        /// <param name="line">Line of text from a QIF file.</param>
        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case SecurityFields.SecurityName:
                    item.SecurityName = value;
                    break;
                case SecurityFields.Symbol:
                    item.Symbol = value;
                    break;
                case SecurityFields.SecurityGoal:
                    item.Goal = value;
                    break;
                case SecurityFields.SecurityType:
                    item.SecurityType = value;
                    break;
                default:
                    item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}