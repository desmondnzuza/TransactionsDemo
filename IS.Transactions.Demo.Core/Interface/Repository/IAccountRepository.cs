using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Repository
{
    public interface IAccountRepository
    {
        Account[] FindAccounts(SearchCriteria criteria);
        Account[] FindAvailableAccounts();
        Account FindAccountByCode(int code);
        void CreateAccount(Account accountToAdd);
        void UpdateAccount(Account accountToUpdate);
        void RemoveAccount(Account accountToRemove);
    }
}
