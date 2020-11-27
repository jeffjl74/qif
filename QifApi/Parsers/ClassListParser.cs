using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Parsers
{
    class ClassListParser : IParser
    {
        private ClassListTransaction item = new ClassListTransaction();

        public void Yield(QifDocument document)
        {
            document.AddTransaction(GetType().Name, item);
            item = new ClassListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case ClassListFields.ClassName:
                    item.ClassName = value;
                    break;
                case ClassListFields.Description:
                    item.Description = value;
                    break;
                default:
                    item.ignoredLines.Add(line);
                    break;
            }
        }
    }
}