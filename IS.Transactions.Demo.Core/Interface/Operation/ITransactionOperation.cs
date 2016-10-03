using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Operation
{
    public interface ITransactionOperation
    {
        Transaction[] FindTransactions(SearchCriteria criteria);
        Account[] FindAvailableAccounts();
        Transaction FindTransactionByCode(int code);
        void AddTransaction(Transaction transactionToAdd);
        void UpdateTransaction(Transaction transactionToUpdate);
        void RemoveTransaction(Transaction transactionToRemove);
    }
}
