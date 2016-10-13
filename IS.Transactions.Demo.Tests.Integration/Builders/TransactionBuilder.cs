using IS.Transactions.Demo.SQL.Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Transactions.Demo.Tests.Integration.Builders
{
    public class TransactionBuilder
    {
        private Account _account;
        private decimal _amount;
        private DateTime _captureDate;
        private string _description;
        private DateTime _transactionDate;

        public TransactionBuilder()
        {
            _captureDate = DateTime.Now;
            _transactionDate = DateTime.Now;
            _description = string.Empty;
        }

        public TransactionBuilder WithAmount(decimal amount)
        {
            _amount = amount;

            return this;
        }

        public TransactionBuilder WithDescription(string description)
        {
            _description = description;

            return this;
        }

        public Transaction Build()
        {
            var transactionToCreate = new Transaction
            {
                Account = _account,
                Amount = _amount,
                CaptureDate = _captureDate,
                Description = _description,
                TransactionDate = _transactionDate
            };

            using (var ctx = new TransactionsDbContext())
            {
                var dbResults = ctx.Transactions
                    .Add(transactionToCreate);

                ctx.SaveChanges();

                return transactionToCreate;
            }
        }
    }
}
