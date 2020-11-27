
namespace Hazzik.Qif.Transactions
{
    /// <summary>
    /// An unrecognized transaction.
    /// </summary>
    /// <remarks>
    /// The data is entirely in the <see cref="TransactionBase"/> ignored lines list.
    /// </remarks>
    public class UnhandledTypeTransaction : TransactionBase
    {
        /// <returns>
        /// A string representing the first unhandled line of the transaction
        /// </returns>
        public override string ToString()
        {
            if (ignoredLines.Count > 0)
                return ignoredLines[0];
            else
                return base.ToString();
        }
    }
}
