using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Writers
{
    static class CategoryListWriter
    {
        internal static void Write(TextWriter writer, ICollection<CategoryListTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(Headers.CategoryList);

                foreach (var item in list)
                {
                    if (item.BudgetAmount.HasValue)
                    {
                        writer.Write(CategoryListFields.BudgetAmount);
                        writer.WriteLine(item.BudgetAmount.Value.ToString(CultureInfo.CurrentCulture));
                    }

                    if (!string.IsNullOrEmpty(item.CategoryName))
                    {
                        writer.Write(CategoryListFields.CategoryName);
                        writer.WriteLine(item.CategoryName);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.Write(CategoryListFields.Description);
                        writer.WriteLine(item.Description);
                    }

                    if(item.TaxRelated)
                        writer.WriteLine(CategoryListFields.TaxRelated);

                    if (!string.IsNullOrEmpty(item.TaxSchedule))
                    {
                        writer.Write(CategoryListFields.TaxSchedule);
                        writer.WriteLine(item.TaxSchedule);
                    }

                    if (item.IncomeCategory)
                        writer.WriteLine(CategoryListFields.IncomeCategory);

                    if (item.ExpenseCategory)
                        writer.WriteLine(CategoryListFields.ExpenseCategory);

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}