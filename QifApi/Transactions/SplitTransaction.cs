
namespace QifDoc.Qif.Transactions
{
    /// <summary>
    /// A class to associate the Category, Memo, Amount, and Percentage lines of a split transaction
    /// </summary>
    public class SplitTransaction : TransactionBase
    {
        /// <summary>
        /// Category for the split
        /// </summary>
        public string Category { get; set; } = "";

        /// <summary>
        /// Memo for the split.
        /// </summary>
        public string Memo { get; set; } = "";

        /// <summary>
        /// Amount of the split
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Percentage of the split, if percentages are used
        /// </summary>
        public decimal? Percentage { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="TagTransaction"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="TagTransaction"/>.
        /// </returns>
        public override string ToString()
        {
            return Category;
        }
    }
}
