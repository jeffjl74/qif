using System.Collections.Generic;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    /// <summary>
    /// Write the <see cref="TagTransaction"/> list
    /// </summary>
    internal static class TagListWriter
    {
        internal static void Write(TextWriter writer, ICollection<TagTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.TagList);

                foreach (TagTransaction item in list)
                {
                    if (!string.IsNullOrEmpty(item.TagName))
                    {
                        writer.Write(TagFields.TagName);
                        writer.WriteLine(item.TagName);
                    }

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        writer.Write(TagFields.Description);
                        writer.WriteLine(item.Description);
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}
