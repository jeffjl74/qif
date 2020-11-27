using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    /// <summary>
    /// Write the <see cref="PriceRecord"/> list
    /// </summary>
    internal static class PriceListWriter
    {
        internal static void Write(TextWriter writer, ICollection<PriceRecord> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (PriceRecord item in list)
                {
                    writer.WriteLine(Headers.PriceList);

                    writer.WriteLine(string.Format("\"{0}\",{1},\"{2}\"", item.Symbol, item.Price, item.PriceDate.ToString("d", CultureInfo.CurrentCulture)));

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}
