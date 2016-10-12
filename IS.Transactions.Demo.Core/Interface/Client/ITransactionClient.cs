using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Client
{
    public interface ITransactionClient
    {
        Transaction[] FindTransactions(SearchCriteria criteria);
        Account[] FindAvailableAccounts();
        Transaction FindTransactionByCode(int code);
        void CreateTransaction(Transaction transactionToAdd);
        void UpdateTransaction(Transaction transactionToUpdate);
        void RemoveTransaction(Transaction transactionToRemove);
    }
}
