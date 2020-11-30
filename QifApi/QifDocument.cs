using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using QifDoc.Qif.Parsers;
using QifDoc.Qif.Transactions;
using QifDoc.Qif.Transactions.Fields;
using QifDoc.Qif.Writers;

namespace QifDoc.Qif
{
    /// <summary>
    /// Represents a Document Object Model for a QIF file.
    /// </summary>
    public class QifDocument
    {
        /// <summary>
        /// Set 'true' upon encoutering a !Option:AutoSwitch when loading a QIF file.
        /// Set 'false' upon encountering a !Clear:AutoSwitch.
        /// </summary>
        public bool isAutoSwitch = false;

        /// <summary>
        /// Represents a collection of bank transactions.
        /// </summary>
        public List<BasicTransaction> BankTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of cash transactions.
        /// </summary>
        public List<BasicTransaction> CashTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of credit card transactions.
        /// </summary>
        public List<BasicTransaction> CreditCardTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of investment transactions.
        /// </summary>
        public List<InvestmentTransaction> InvestmentTransactions = new List<InvestmentTransaction>();

        /// <summary>
        /// Represents a collection of asset transactions.
        /// </summary>
        public List<BasicTransaction> AssetTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of liability transactions.
        /// </summary>
        public List<BasicTransaction> LiabilityTransactions = new List<BasicTransaction>();

        /// <summary>
        /// Represents a collection of account list transactions.
        /// </summary>
        public List<AccountListTransaction> AccountList = new List<AccountListTransaction>();

        /// <summary>
        /// Represents a collection of category list transactions.
        /// </summary>
        public List<CategoryListTransaction> CategoryListTransactions = new List<CategoryListTransaction>();

        /// <summary>
        /// Represents a collection of class list transactions.
        /// </summary>
        public List<ClassListTransaction> ClassListTransactions = new List<ClassListTransaction>();

        /// <summary>
        /// Represents a collection of memorized transaction list transactions.
        /// </summary>
        public List<MemorizedTransactionListTransaction> MemorizedTransactionListTransactions = new List<MemorizedTransactionListTransaction>();

        /// <summary>
        /// Represents a collection of tags.
        /// </summary>
        public List<TagTransaction> TagTransactions = new List<TagTransaction>();

        /// <summary>
        /// Represents a collection of securities.
        /// </summary>
        public List<PriceRecord> PriceTransactions = new List<PriceRecord>();

        /// <summary>
        /// Represents a collection of securities.
        /// </summary>
        public List<SecurityTransaction> SecurityTransactions = new List<SecurityTransaction>();

        /// <summary>
        /// A collection of accounts with their associated transactions. Activated via !Option:AutoSwitch
        /// </summary>
        public AutoSwitchAccountList AutoSwitchAccountList = new AutoSwitchAccountList();

        /// <summary>
        /// A collection of unrecognized lines
        /// </summary>
        public List<UnhandledTypeTransaction> UnhandledTypeTransactions = new List<UnhandledTypeTransaction>();

        /// <summary>
        /// Saves the QIF document to the <see cref="Stream"/>.
        /// </summary>
        public void Save(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                Save(writer);
            }
        }

        /// <summary>
        /// Exports the QIF document to the <see cref="TextWriter"/>.
        /// </summary>
        public void Save(TextWriter writer)
        {
            TagListWriter.Write(writer, TagTransactions);
            CategoryListWriter.Write(writer, CategoryListTransactions);
            ClassListWriter.Write(writer, ClassListTransactions);
            if (AutoSwitchAccountList.autoSwitchAccounts.Count == 0)
                SecurityListWriter.Write(writer, SecurityTransactions);
            AccountListWriter.Write(writer, AccountList);
            AutoSwitchAccountListWriter.Write(writer, AutoSwitchAccountList, SecurityTransactions);
            BasicTransactionWriter.Write(writer, Headers.Asset, AssetTransactions);
            BasicTransactionWriter.Write(writer, Headers.Bank, BankTransactions);
            BasicTransactionWriter.Write(writer, Headers.Cash, CashTransactions);
            BasicTransactionWriter.Write(writer, Headers.CreditCard, CreditCardTransactions);
            BasicTransactionWriter.Write(writer, Headers.Liability, LiabilityTransactions);
            InvestmentWriter.Write(writer, InvestmentTransactions);
            MemorizedTransactionListWriter.Write(writer, MemorizedTransactionListTransactions);
            PriceListWriter.Write(writer, PriceTransactions);
        }

        /// <summary>
        /// Returns a string representation of the QIF document.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            using (var writer = new StringWriter())
            {
                Save(writer);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Adds a transaction to the appropriate transaction list.
        /// </summary>
        /// <param name="parserName">The GetType().Name of the parser that is adding a transaction.</param>
        /// <param name="transaction">The transaction to add.</param>
        public void AddTransaction(string parserName, object transaction)
        {
            bool isAutoAcct = false;

            // first, see if we are associating transactions with an account via !Option:AutoSwitch
            if (isAutoSwitch)
                isAutoAcct = AutoSwitchAccountList.AddTransaction(parserName, transaction);
            if(!isAutoAcct)
            {
                // this transaction does not associate with a particular account

                if (parserName == typeof(AccountListParser).Name)
                    AccountList.Add((AccountListTransaction)transaction);

                else if (parserName == typeof(AssetParser).Name)
                    AssetTransactions.Add((BasicTransaction)transaction);

                else if (parserName == typeof(BankParser).Name)
                    BankTransactions.Add((BasicTransaction)transaction);

                else if (parserName == typeof(CashParser).Name)
                    CashTransactions.Add((BasicTransaction)transaction);

                else if (parserName == typeof(CategoryListParser).Name)
                    CategoryListTransactions.Add((CategoryListTransaction)transaction);

                else if (parserName == typeof(ClassListParser).Name)
                    ClassListTransactions.Add((ClassListTransaction)transaction);

                else if (parserName == typeof(CreditCardParser).Name)
                    CreditCardTransactions.Add((BasicTransaction)transaction);

                else if (parserName == typeof(InvestmentParser).Name)
                    InvestmentTransactions.Add((InvestmentTransaction)transaction);

                else if (parserName == typeof(LiabilityParser).Name)
                    LiabilityTransactions.Add((BasicTransaction)transaction);

                else if (parserName == typeof(MemorizedTransactionListParser).Name)
                    MemorizedTransactionListTransactions.Add((MemorizedTransactionListTransaction)transaction);
                
                else if (parserName == typeof(PriceParser).Name)
                    PriceTransactions.Add((PriceRecord)transaction);

                else if (parserName == typeof(SecurityParser).Name)
                    SecurityTransactions.Add((SecurityTransaction)transaction);

                else if (parserName == typeof(TagParser).Name)
                    TagTransactions.Add((TagTransaction)transaction);

                else if (parserName == typeof(UnhandledTypeParser).Name)
                    UnhandledTypeTransactions.Add((UnhandledTypeTransaction)transaction);
            }
        }

        /// <summary>
        /// Parses a QIF document from the specified <see cref="String"/>.
        /// </summary>
        /// <param name="text">The text representation of QIF file to parse.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Parse(string text)
        {
            using (var reader = new StringReader(text))
            {
                return Load(reader);
            }
        }

        /// <summary>
        /// Loads a QIF document from the specified <see cref="Stream"/>
        /// </summary>
        /// <param name="stream">The stream pointing to an underlying QIF file to load.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Load(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return Load(reader);
            }
        }

        /// <summary>
        /// Loads a QIF document from the specified <see cref="TextReader"/>
        /// </summary>
        /// <param name="reader">The text reader pointing to an underlying QIF file to load.</param>
        /// <returns>A QifDocument object of transactions imported.</returns>
        public static QifDocument Load(TextReader reader)
        {
            var document = new QifDocument();

            string line;
            IParser parser = null;
            while ((line = reader.ReadLine()) != null)
            {
                switch (line[0])
                {
                    case InformationFields.TransactionType:
                        parser = CreateParser(line);
                        if(parser == null)
                        {
                            // AutoSwitch is a special case. They have no following lines.
                            // So just process them directly.
                            if (line.Equals(Headers.OptionAutoswitch))
                                document.isAutoSwitch = true;
                            else if (line.Equals(Headers.ClearAutoswitch))
                                document.isAutoSwitch = false;
                        }
                        break;
                    case InformationFields.EndOfEntry:
                        Debug.Assert(parser != null, "parser != null");
                        parser.Yield(document);
                        break;
                    default:
                        Debug.Assert(parser != null, "parser != null");
                        parser.ParseLine(line);
                        break;
                }
            }

            return document;
        }

        private static IParser CreateParser(string line)
        {
            switch (line.Trim())
            {
                case Headers.Bank  :
                    return new BankParser();
                case Headers.Cash:
                    return new CashParser();
                case Headers.CreditCard:
                    return new CreditCardParser();
                case Headers.Investment:
                    return new InvestmentParser();
                case Headers.Asset:
                    return new AssetParser();
                case Headers.Liability:
                    return new LiabilityParser();
                case Headers.AccountList:
                    return new AccountListParser();
                case Headers.CategoryList:
                    return new CategoryListParser();
                case Headers.ClassList:
                    return new ClassListParser();
                case Headers.MemorizedTransactionList:
                    return new MemorizedTransactionListParser();
                case Headers.SecurityList:
                    return new SecurityParser();
                case Headers.TagList:
                    return new TagParser();
                case Headers.PriceList:
                    return new PriceParser();

                // these are handled in Load()
                // since they contain no data and act like a toggle switch
                case Headers.ClearAutoswitch:
                case Headers.OptionAutoswitch:
                    return null;

                default:
                    return new UnhandledTypeParser(line);

            }
        }
    }
}
