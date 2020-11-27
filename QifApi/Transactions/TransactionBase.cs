using System.Collections.Generic;

namespace QifDoc.Qif.Transactions
{
    /// <summary>
    /// The base transaction from which all transactions must derive.
    /// </summary>
    public class TransactionBase
    {
        /// <summary>
        /// Collection of lines that occur in a record between the !<Header name>:<Export type> and the ^
        /// but are not recognized or parsed into transaction fields.
        /// </summary>
        public IList<string> ignoredLines = new List<string>();
    }
}
