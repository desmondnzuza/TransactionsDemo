using CoreModel = IS.Transactions.Demo.Core.Model;
using DbModel = IS.Transactions.Demo.SQL.Repository.POCO;
using System.Linq;

namespace IS.Transactions.Demo.SQL.Repository.Helpers
{
    public static class ModelExtenstion
    {
        public static DbModel.Account ToDbModelAccount(this CoreModel.Account account)
        {
            var transactions = account.Transactions
                      .Select(x => new DbModel.Transaction
                      {
                          Amount = x.Amount,
                          CaptureDate = x.CaptureDate,
                          Code = x.Code,
                          Description = x.Description,
                          TransactionDate = x.TransactionDate
                      })
                      .ToArray();

            return new DbModel.Account
            {
                Code = account.Code,
                PersonCode = (account.AccountHolder != null) ? account.AccountHolder.Code : 1,
                AccountNumber = account.AccountNumber,
                OutstandingBalance = account.OutstandingBalance,
                Transactions = transactions
            };
        }

        public static CoreModel.Account ToCoreModelAccount(this DbModel.Account account)
        {
            var transactions = account.Transactions
                      .Select(x => new CoreModel.Transaction
                      {
                          Amount = x.Amount,
                          CaptureDate = x.CaptureDate,
                          Code = x.Code,
                          Description = x.Description,
                          TransactionDate = x.TransactionDate
                      })
                      .ToArray();

            return new CoreModel.Account
            {
                Code = account.Code,
                AccountHolder = account.Person.ToCoreModelPerson(),
                AccountNumber = account.AccountNumber,
                OutstandingBalance = account.OutstandingBalance,
                Transactions = transactions
            };
        }

        public static DbModel.Person ToDbModelPerson(this CoreModel.Person person)
        {
            return new DbModel.Person
            {
                Code = person.Code,
                Name = person.Name,
                Surname = person.Surname,
                IdNumber = person.IdNumber
            };
        }

        public static CoreModel.Person ToCoreModelPerson(this DbModel.Person person)
        {
            return new CoreModel.Person
            {
                Code = person.Code,
                Name = person.Name,
                Surname = person.Surname,
                IdNumber = person.IdNumber
            };
        }

        public static DbModel.Transaction ToDbModelTransaction(this CoreModel.Transaction transaction)
        {
            return new DbModel.Transaction
            {
                Code = transaction.Code,
                AccountCode = transaction.TransactingAccount != null ? transaction.TransactingAccount.Code : 0,
                TransactionDate = transaction.TransactionDate,
                CaptureDate = transaction.CaptureDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }

        public static CoreModel.Transaction ToCoreModelTransaction(this DbModel.Transaction transaction)
        {
            return new CoreModel.Transaction
            {
                Code = transaction.Code,
                TransactingAccount = transaction.Account.ToCoreModelAccount(),
                CaptureDate = transaction.CaptureDate,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Description = transaction.Description
            };
        }
    }
}
