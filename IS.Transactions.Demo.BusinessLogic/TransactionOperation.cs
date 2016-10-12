using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.BusinessLogic
{
    public class TransactionOperation : ITransactionOperation
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
            
        public TransactionOperation(
            ITransactionRepository transactionRepository, 
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public void CreateTransaction(Transaction transactionToAdd)
        {
            _transactionRepository.CreateTransaction(transactionToAdd);
        }

        public Account[] FindAvailableAccounts()
        {
            return _accountRepository.FindAvailableAccounts();
        }

        public Transaction FindTransactionByCode(int code)
        {
            return _transactionRepository.FindTransactionByCode(code);
        }

        public Transaction[] FindTransactions(SearchCriteria criteria)
        {
            if(criteria != null && !string.IsNullOrEmpty(criteria.Term))
            {
                return _transactionRepository.FindTransactions(criteria);
            }

            return new Transaction[] { };
        }

        public void RemoveTransaction(Transaction transactionToRemove)
        {
            _transactionRepository.RemoveTransaction(transactionToRemove);
        }

        public void UpdateTransaction(Transaction transactionToUpdate)
        {
            _transactionRepository.UpdateTransaction(transactionToUpdate);
        }
    }
}
