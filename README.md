# QIF
A library for creating and consuming *.qif files. The library complies with documented Quicken Interchange Format (QIF) file specification. It is a completely managed, open source QIF API.

This library enables you to import or export *.qif files. It also allows you to create or modify transactions and represent them easily in code as entities. This library can enable your application to completely handle any aspect of a QIF file. You can create transactions in an easy to understand model and export it to the versatile Quicken export file format. Or you can easily import your QIF file and have access to all transactions in the file.

This fork includes the following changes:
* Support !Option:AutoSwitch - attaches transactions to an account when the file contains multiple accounts
* Support !Type:Security - investment securities
* Support !Type:Prices - investment security prices
* Support !Type:Tag - transaction tags
* Uses C# 6.0 language features - especially decimal? to avoid writing fields that were not set, and $ in place of string.Format()
* Rearranged Save() line order to match the order of Quicken 2013 exports (and the order in the QIF file format documentation)
* Collects unrecognized lines into accessable List<string> rather than ignoring them or throwing exceptions
* Better handling of splits with missing field line(s)

Mixing AutoSwiched accounts with non-switched accounts could result in a file that other programs might have issues with.


# C# / .NET Example
```csharp
// This returns a QifDocument object. The QifDocument represents all transactions found in the QIF file.
QifDocument qif = QifDocument.Load(File.OpenRead(@"c:\quicken.qif"));

// example access to transactions that are not AutoSwitched
// i.e either a file with a single account
// or transactions that are never associated to an account, like categories
foreach (CategoryListTransaction c in qif.CategoryListTransactions)
{
    Console.WriteLine($"Category:{c.CategoryName} Description:{c.Description}");
}

// add a new category to the QifDocument
CategoryListTransaction category = new CategoryListTransaction
    { CategoryName = "Test Category", Description = "Testing" };
qif.CategoryListTransactions.Add(category);

// example access to AutoSwiched accounts and transactions
foreach (AutoSwitchAccount a in qif.AutoSwitchAccountList.autoSwitchAccounts)
{
    Console.WriteLine($"Account:{a.accountListTransaction.Name}");
    foreach (BasicTransaction b in a.BankTransactions)
    {
        Console.WriteLine($"Date:{b.Date} Payee:{b.Payee} Amount:{b.Amount}");
    }
}

// add a new transaction to an existing AutoSwitch account
InvestmentTransaction transaction = new InvestmentTransaction
{
    Security = "AAPL",
    Action = "Buy",
    Quantity = 100,
    Price = 115.17M,
    TransactionAmount = 11517,
    Date = DateTime.Parse("11/24/2020")
};
qif.AutoSwitchAccountList.autoSwitchAccounts[0].InvestmentTransactions.Add(transaction);


// Write the QifDocument to a file.
qif.Save(File.Open(@"c:\quicken-mod.qif", FileMode.Create));
```

All transactions present in the DOM are written according to the QIF file format specification. Dates and numbers should be written according to globalization standards.

# Available on [NuGet](http://www.nuget.org/packages/hazzik.qif)
```PowerShell
Install-Package Hazzik.Qif
```
