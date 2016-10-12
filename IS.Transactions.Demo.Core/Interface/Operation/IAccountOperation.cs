using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Operation
{
    public interface IAccountOperation
    {
        Account[] FindAccounts(SearchCriteria criteria);
        Person[] FindAvailablePeople();
        Account FindAccountByCode(int code);
        void CreateAccount(Account accountToAdd);
        void UpdateAccount(Account accountToUpdate);
        void RemoveAccount(Account accountToRemove);
    }
}
