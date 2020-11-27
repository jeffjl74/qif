using System.Collections.Generic;
using System.Globalization;
using System.IO;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Writers
{
    static class SecurityListWriter
    {
        internal static void Write(TextWriter writer, ICollection<SecurityTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                foreach (var item in list)
                {
                    writer.WriteLine(Headers.SecurityList);

                    if (!string.IsNullOrEmpty(item.SecurityName))
                    {
                        writer.Write(SecurityFields.SecurityName);
                        writer.WriteLine(item.SecurityName);
                    }

                    if (!string.IsNullOrEmpty(item.Symbol))
                    {
                        writer.Write(SecurityFields.Symbol);
                        writer.WriteLine(item.Symbol);
                    }

                    if (!string.IsNullOrEmpty(item.SecurityType))
                    {
                        writer.Write(SecurityFields.SecurityType);
                        writer.WriteLine(item.SecurityType);
                    }

                    if (!string.IsNullOrEmpty(item.Goal))
                    {
                        writer.Write(SecurityFields.SecurityGoal);
                        writer.WriteLine(item.Goal);
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}