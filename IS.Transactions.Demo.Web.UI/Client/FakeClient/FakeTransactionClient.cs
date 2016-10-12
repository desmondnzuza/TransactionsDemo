using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System;
using System.Linq;

namespace IS.Transactions.Demo.Web.UI.Client.FakeClient
{
    public class FakeTransactionClient : ITransactionClient
    {
        private readonly Transaction[] _transactions;

        public FakeTransactionClient()
        {
            _transactions = new Transaction[]
            {
                new Transaction {Code = 1, Amount = 100, CaptureDate = DateTime.Now, Description = "This is account 1", TransactingAccount = null, TransactionDate = DateTime.Now },
                new Transaction {Code = 2, Amount = 3000, CaptureDate = DateTime.Now, Description = "This is account 2", TransactingAccount = null, TransactionDate = DateTime.Now },
                new Transaction {Code = 3, Amount = 120, CaptureDate = DateTime.Now, Description = "This is account 3", TransactingAccount = null, TransactionDate = DateTime.Now },
            };
        }

        public void CreateTransaction(Transaction transactionToAdd)
        {
            throw new NotImplementedException();
        }

        public Account[] FindAvailableAccounts()
        {
            throw new NotImplementedException();
        }

        public Transaction FindTransactionByCode(int code)
        {
            return _transactions.FirstOrDefault(t => t.Code.Equals(code));
        }

        public Transaction[] FindTransactions(SearchCriteria criteria)
        {
            return _transactions;
        }

        public void RemoveTransaction(Transaction transactionToRemove)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(Transaction transactionToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}