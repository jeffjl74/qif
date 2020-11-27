
using System;

namespace QifDoc.Qif.Transactions
{
    /// <summary>
    /// A <see cref="Headers.PriceList"/> record
    /// </summary>
    public class PriceRecord : TransactionBase
    {
        /// <summary>
        /// Gets or sets the date of the price.
        /// </summary>
        /// <value>The date of the price.</value>
        public DateTime PriceDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the price of the security.
        /// </summary>
        /// <value>The price of the security.</value>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Gets or sets the symbol of the security.
        /// </summary>
        /// <value>The symbol of the security.</value>
        public string Symbol { get; set; } = "";

        /// <returns>
        /// A <see cref="T:System.String"/> that represents the <see cref="PriceRecord"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}={1:c} on {2:dMMMyyyy}", Symbol, Price, PriceDate);
        }
    }
}
