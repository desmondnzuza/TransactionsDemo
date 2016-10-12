using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IS.Transactions.Demo.Web.API.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ITransactionOperation _operation;

        public TransactionController(ITransactionOperation transactionOperataion)
        {
            _operation = transactionOperataion;
        }

        [HttpPost]
        public Transaction[] FindTransactions([FromBody]SearchCriteria criteria)
        {
            return _operation.FindTransactions(criteria);
        }

        [HttpGet]
        public Transaction FindTransactionByCode(int code)
        {
            return _operation.FindTransactionByCode(code);
        }

        [HttpPost]
        public void CreateTransaction(Transaction transactionToCreate)
        {
            _operation.CreateTransaction(transactionToCreate);
        }

        [HttpPost]
        public void UpdateTransaction(Transaction transactionToUpdate)
        {
            _operation.UpdateTransaction(transactionToUpdate);
        }

        [HttpPost]
        public void RemoveTransaction(Transaction transactionToRemove)
        {
            _operation.RemoveTransaction(transactionToRemove);
        }

        [HttpGet]
        public Account[] FindAvailableAccounts()
        {
            return _operation.FindAvailableAccounts();
        }
    }
}