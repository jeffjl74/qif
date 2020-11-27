using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hazzik.Qif.Transactions
{
    /// <summary>
    /// A basic transaction. It is used to describe non-investment transactions.
    /// </summary>
    public class BasicTransaction : TransactionBase
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the U line amount.
        /// </summary>
        /// <value>The U line amount.</value>
        public decimal? AmountU { get; set; }

        /// <summary>
        /// Gets or sets the cleared status.
        /// </summary>
        /// <value>The cleared status.</value>
        public string ClearedStatus { get; set; } = "";

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get; set; } = "";

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>The payee.</value>
        public string Payee { get; set; } = "";

        /// <summary>
        /// Gets or sets the memo.
        /// </summary>
        /// <value>The memo.</value>
        public string Memo { get; set; } = "";

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; } = "";

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public IList<string> Address { get; } = new List<string>();

        public IList<SplitTransaction> Splits { get; } = new List<SplitTransaction>();

        /// <summary>
        /// Gets or sets the split categories.
        /// </summary>
        /// <value>The split categories.</value>
        //public IDictionary<int, string> SplitCategories { get; } = new Dictionary<int, string>();

        /// <summary>
        /// Gets or sets the split memos.
        /// </summary>
        /// <value>The split memos.</value>
        //public IDictionary<int, string> SplitMemos { get; } = new Dictionary<int, string>();

        /// <summary>
        /// Gets or sets the split amounts.
        /// </summary>
        /// <value>The split amounts.</value>
        //public IDictionary<int, decimal> SplitAmounts { get; } = new Dictionary<int, decimal>();

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(Resources.Culture, Resources.BasicTransactionDisplay, Date.ToString("d", CultureInfo.CurrentCulture), Payee, Amount);
        }
    }
}