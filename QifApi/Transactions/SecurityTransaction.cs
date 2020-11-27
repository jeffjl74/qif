
namespace Hazzik.Qif.Transactions
{
    /// <summary>
    /// An investment security transaction.
    /// </summary>
    public class SecurityTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the name of the security.
        /// </summary>
        /// <value>The name of the security.</value>
        public string SecurityName { get; set; } = "";

        /// <summary>
        /// Gets or sets the symbol / ticker.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Gets or sets the security type.
        /// </summary>
        /// <value>The security type.</value>
        public string SecurityType { get; set; } = "";

        /// <summary>
        /// Gets or sets the security goal.
        /// </summary>
        /// <value>The security goal.</value>
        public string Goal { get; set; } = "";

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="SecurityTransaction"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="SecurityTransaction"/>.
        /// </returns>
        public override string ToString()
        {
            return SecurityName;
        }
    }
}
