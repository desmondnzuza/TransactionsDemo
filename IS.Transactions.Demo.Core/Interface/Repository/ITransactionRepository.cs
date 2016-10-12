using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Repository
{
    public interface ITransactionRepository
    {
        Transaction[] FindTransactions(SearchCriteria criteria);
        Transaction[] FindAvailableTransactions();
        Transaction FindTransactionByCode(int code);
        void CreateTransaction(Transaction transactionToAdd);
        void UpdateTransaction(Transaction transactionToUpdate);
        void RemoveTransaction(Transaction transactionToRemove);
    }
}
