
namespace Hazzik.Qif.Transactions
{
    /// <summary>
    /// A tag list transaction.
    /// </summary>
    public class TagTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>The name of the tag.</value>
        public string TagName { get; set; } = "";

        /// <summary>
        /// Gets or sets the description for the tag.
        /// </summary>
        /// <value>The description for the tag.</value>
        public string Description { get; set; } = "";

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="TagTransaction"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="TagTransaction"/>.
        /// </returns>
        public override string ToString()
        {
            return TagName;
        }
    }
}
