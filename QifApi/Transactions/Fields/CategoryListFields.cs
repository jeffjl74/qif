
namespace QifDoc.Qif.Transactions.Fields
{
    /// <summary>
    /// The category list fields used in transactions.
    /// </summary>
    public static class CategoryListFields
    {
        /// <summary>
        /// Category name:subcategory name
        /// </summary>
        public const char CategoryName = 'N';
        /// <summary>
        /// Description
        /// </summary>
        public const char Description = 'D';
        /// <summary>
        /// Tax related if included, not tax related if omitted
        /// </summary>
        public const char TaxRelated = 'T';
        /// <summary>
        /// Income category
        /// </summary>
        public const char IncomeCategory = 'I';
        /// <summary>
        /// If category is unspecified, assume expense type
        /// </summary>
        public const char ExpenseCategory = 'E';
        /// <summary>
        /// Only in a Budget Amounts QIF file
        /// </summary>
        public const char BudgetAmount = 'B';
        /// <summary>
        /// Tax schedule information
        /// </summary>
        public const char TaxSchedule = 'R';
    }
}
