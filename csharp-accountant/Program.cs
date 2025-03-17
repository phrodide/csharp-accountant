// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<GeneralJournal.Transaction> test = [];
test.Add(new()
{
    Date = DateTime.Today,
    Description = "Sample Description",
    Amount = 5.00M,
    Account = "11387",
    CrDb = GeneralJournal.CreditDebit.Credit
});

test.Add(new()
{
    Date = DateTime.Today,
    Description = "ACH Sample Description",
    Amount = 5.00M,
    Account = "11223344/11225544",
    CrDb = GeneralJournal.CreditDebit.Debit
});

GeneralJournal.TransactionManager.Save(test);