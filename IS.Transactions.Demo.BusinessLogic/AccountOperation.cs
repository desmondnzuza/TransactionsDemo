using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.BusinessLogic
{
    public class AccountOperation : IAccountOperation
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPersonRepository _personRepository;

        public AccountOperation(
            IAccountRepository accountRepository,
            IPersonRepository personRepository)
        {
            _accountRepository = accountRepository;
            _personRepository = personRepository;
        }

        public void AddAccount(Account accountToAdd)
        {
            _accountRepository.AddAccount(accountToAdd);
        }

        public Account FindAccountByCode(int code)
        {
            return _accountRepository.FindAccountByCode(code);
        }

        public Account[] FindAccounts(SearchCriteria criteria)
        {
            if(criteria != null && !string.IsNullOrWhiteSpace(criteria.Term))
            {
                return _accountRepository.FindAccounts(criteria);
            }

            return new Account[] { };
        }

        public Person[] FindAvailablePeople()
        {
            return _personRepository.FindAvailablePeople();
        }

        public void RemoveAccount(Account accountToRemove)
        {
            _accountRepository.RemoveAccount(accountToRemove);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            _accountRepository.UpdateAccount(accountToUpdate);
        }
    }
}
