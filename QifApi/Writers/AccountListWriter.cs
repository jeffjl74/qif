using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    /// <summary>
    /// Provides methods to write one or more <see cref="AccountListTransaction"/>
    /// </summary>
    internal static class AccountListWriter
    {
        internal static void Write(TextWriter writer, ICollection<AccountListTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.AccountList);

                foreach (AccountListTransaction item in list)
                {
                    Write(writer, item, false);
                }
            }
        }

        /// <summary>
        /// Write a single <see cref="AccountListTransaction"/>
        /// </summary>
        /// <param name="writer">Desitnation Stream</param>
        /// <param name="item">AccountListTransaction to write</param>
        /// <param name="autoSwitched">True to only write the account name and type</param>
        internal static void Write(TextWriter writer, AccountListTransaction item, bool autoSwitched)
        {
            if (!string.IsNullOrEmpty(item.Name))
            {
                writer.Write(AccountInformationFields.Name);
                writer.WriteLine(item.Name);
            }

            if (!string.IsNullOrEmpty(item.Type))
            {
                writer.Write(AccountInformationFields.AccountType);
                writer.WriteLine(item.Type);
            }

            if (!autoSwitched)
            {
                if (item.CreditLimit.HasValue)
                    writer.WriteLine($"{AccountInformationFields.CreditLimit}{item.CreditLimit:n}");

                if (!string.IsNullOrEmpty(item.Description))
                {
                    writer.Write(AccountInformationFields.Description);
                    writer.WriteLine(item.Description);
                }

                if (item.StatementBalance.HasValue)
                {
                    writer.Write(AccountInformationFields.StatementBalance);
                    writer.WriteLine(item.StatementBalance.Value.ToString(CultureInfo.CurrentCulture));
                }

                if (item.StatementBalanceDate != DateTime.MinValue)
                {
                    writer.Write(AccountInformationFields.StatementBalanceDate);
                    writer.WriteLine(item.StatementBalanceDate.ToString("d", CultureInfo.CurrentCulture));
                }
            }

            writer.WriteLine(InformationFields.EndOfEntry);
        }
    }
}