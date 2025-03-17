using System;
using System.Linq;

namespace GeneralJournal
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public CreditDebit CrDb { get; set; }
        public decimal AbsoluteAmount
        {
            get
            {
                if (CrDb == CreditDebit.Informational) return 0;
                return CrDb == CreditDebit.Credit ? Amount : -Amount;
            }
        }
        public string Account { get; set; } = "";
        public string Description { get; set; } = "";

    }

    [System.Serializable]
    public class TransactionOutOfBalanceException : System.Exception
    {
        public TransactionOutOfBalanceException() { }
        public TransactionOutOfBalanceException(string message) : base(message) { }
        public TransactionOutOfBalanceException(string message, System.Exception inner) : base(message, inner) { }
        protected TransactionOutOfBalanceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public enum CreditDebit
    {
        Credit,
        Debit,
        Informational
    }

    public static class TransactionManager
    {
        public static void Save(IEnumerable<Transaction> b)
        {
            //Throw exception if the transaction does not balance. Let the upper function decide what to do if the transaction does not blance.
            decimal total = b.Select(b => b.AbsoluteAmount).Sum();
            if (total != 0)
                throw new TransactionOutOfBalanceException("Transaction does not equal 0. Total: " + total);

            //take the account and locate the folder.
            string TraceNumber = DateTime.Today.ToString("yyyyMMdd") + "-" + Guid.NewGuid().ToString(); // Placeholder until we get a better naming scheme
            int i = 0;
            foreach (var t in b)
            {
                if (!System.IO.Directory.Exists($"{Globals.Configuration.BaseDirectory}{t.Account}"))
                {
                    //create the directory.
                    System.IO.Directory.CreateDirectory($"{Globals.Configuration.BaseDirectory}{t.Account}");
                }
                System.IO.File.WriteAllText($"{Globals.Configuration.BaseDirectory}{t.Account}/{TraceNumber}.{i}.csv", $"{t.Date},{t.Account},{t.Amount},{t.CrDb},{t.Description},{TraceNumber},{i}\n");
                i++;
            }
            //System.IO.File.WriteAllText(Globals.Configuration.BaseDirectory + 
        }
    }
}