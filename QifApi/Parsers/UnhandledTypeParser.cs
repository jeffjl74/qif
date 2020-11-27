using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    /// <summary>
    /// Collects the lines of an unrecognized transaction. Lines are not parsed.
    /// </summary>
    class UnhandledTypeParser : IParser
    {
        private UnhandledTypeTransaction item = new UnhandledTypeTransaction();

        /// <summary>
        /// Constructor captures the ! line that was not in <see cref="Headers"/>
        /// </summary>
        /// <param name="line"></param>
        public UnhandledTypeParser(string line)
        {
            item.ignoredLines.Add(line);
        }

        /// <summary>
        /// Does not parse, simply adds to ignoredLines
        /// </summary>
        /// <param name="line"></param>
        public void ParseLine(string line)
        {
            item.ignoredLines.Add(line);
        }

        /// <summary>
        /// Adds the current <see cref="UnhandledTypeTransaction"/> to the passed <see cref="QifDocument"/>
        /// </summary>
        /// <param name="document"><see cref="QifDocument"/> to which the transaction is added</param>
        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new UnhandledTypeTransaction();
        }
    }
}