using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IS.Transactions.Demo.Web.UI.Client.FakeClient
{
    public class FakeAccountClient : IAccountClient
    {
        private readonly List<Account> _accounts;

        public FakeAccountClient()
        {
            _accounts = new List<Account>
            {
                new Account {Code = 1, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "123456", OutstandingBalance = 0 },
                new Account {Code = 2, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "1232111", OutstandingBalance = 40 },
                new Account {Code = 3, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "123477756", OutstandingBalance = 30 },
                new Account {Code = 4, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "777", OutstandingBalance = 20 },
                new Account {Code = 5, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "werwerw23", OutstandingBalance = 200 },
                new Account {Code = 6, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "2342324", OutstandingBalance = -75 },
                new Account {Code = 7, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "2313212", OutstandingBalance = 5 },
                new Account {Code = 8, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "231312", OutstandingBalance = 23 },
                new Account {Code = 9, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "123444", OutstandingBalance = -8765 },
                new Account {Code = 10, AccountHolder = new Person {Code = 1, Name = "John", Surname = "Doe" }, AccountNumber = "7766", OutstandingBalance = 988 },
            };
        }

        public void CreateAccount(Account accountToAdd)
        {
            _accounts.Add(accountToAdd);
        }

        public Account FindAccountByCode(int code)
        {
            return _accounts.FirstOrDefault(a => a.Code.Equals(code));
        }

        public Account[] FindAccounts(SearchCriteria criteria)
        {
            return _accounts.ToArray();
        }

        public Person[] FindAvailablePeople()
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(Account accountToRemove)
        {
            if(_accounts.Contains(accountToRemove))
            {
                _accounts.Remove(accountToRemove);
            }
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var itemToUpdate = _accounts.FirstOrDefault(a => a.Code.Equals(accountToUpdate.Code));

            if(itemToUpdate != null)
            {
                itemToUpdate.AccountHolder = accountToUpdate.AccountHolder;
                itemToUpdate.AccountNumber = accountToUpdate.AccountNumber;
                itemToUpdate.OutstandingBalance = accountToUpdate.OutstandingBalance;
            }
        }
    }
}