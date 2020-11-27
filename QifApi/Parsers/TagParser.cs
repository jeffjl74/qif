using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Parsers
{
    /// <summary>
    /// Parses a <see cref="Headers.TagList"/> record into a <see cref="TagTransaction"/> which is added to the document when <see cref="Yield(QifDocument)"/> is called.
    /// </summary>
    internal class TagParser : IParser
    {
        private TagTransaction item = new TagTransaction();

        /// <summary>
        /// Adds the current <see cref="TagTransaction"/> to the passed <see cref="QifDocument"/>
        /// </summary>
        /// <param name="document"><see cref="QifDocument"/> to which the transaction is added</param>
        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new TagTransaction();
        }

        /// <summary>
        /// Parse the passed string into the appropriate <see cref="TagTransaction"/> field.
        /// </summary>
        /// <param name="line">Line of text from a QIF file.</param>
        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case TagFields.TagName:
                    item.TagName = value;
                    break;
                case TagFields.Description:
                    item.Description = value;
                    break;
                default:
                    item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}