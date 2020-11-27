using System.Collections.Generic;
using System.IO;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;

namespace QifDoc.Qif.Writers
{
    static class ClassListWriter
    {
        internal static void Write(TextWriter writer, ICollection<ClassListTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.ClassList);

                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.ClassName))
                    {
                        writer.Write(ClassListFields.ClassName);
                        writer.WriteLine(item.ClassName);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.Write(ClassListFields.Description);
                        writer.WriteLine(item.Description);
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}
