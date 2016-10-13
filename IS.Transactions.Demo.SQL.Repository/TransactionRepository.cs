using IS.Transactions.Demo.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.SQL.Repository.Helpers;

namespace IS.Transactions.Demo.SQL.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public void CreateTransaction(Transaction transactionToAdd)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var itemToAdd = transactionToAdd.ToDbModelTransaction();
                ctx.Transactions.Add(itemToAdd);

                ctx.SaveChanges();
            }
        }

        public Transaction[] FindAvailableTransactions()
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var availableTransactions = ctx.Transactions.ToArray();

                return availableTransactions
                      .Select(x => x.ToCoreModelTransaction())
                      .ToArray();
            }
        }

        public Transaction FindTransactionByCode(int code)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbTransaction = ctx.Transactions
                    .FirstOrDefault(c => c.Code == code);

                if (dbTransaction != null)
                {
                    return dbTransaction.ToCoreModelTransaction();
                }
            }

            return null;
        }

        public Transaction[] FindTransactions(SearchCriteria criteria)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                int pageSize = criteria.PageSize;
                int pageNumber = criteria.PageNumber > 1 ? criteria.PageNumber : 1;

                var query = ctx.Transactions
                    /*.Where(c =>
                          (c.Name.Contains(criteria.Term) ||
                            c.Surname.Contains(criteria.Term) ||
                            criteria.Term == "*"))*/
                    .OrderByDescending(x => x.Code);

                var dbResults = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelTransaction())
                      .ToArray();

            }
        }

        public void RemoveTransaction(Transaction transactionToRemove)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var transactionToDelete = ctx.Transactions
                    //.Include(x => x.Products)
                    .FirstOrDefault(c => c.Code == transactionToRemove.Code);

                if (transactionToDelete != null)
                {
                    //foreach (var dbProduct in categoryToDelete.Products.ToArray())
                    //    ctx.Entry<SQLPOCO.Product>(dbProduct).State = EntityState.Modified;

                    ctx.Transactions.Remove(transactionToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateTransaction(Transaction transactionToUpdate)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbTransaction = transactionToUpdate.ToDbModelTransaction();

                var dbFreshTransaction = ctx.Accounts
                       .Single(c => c.Code == dbTransaction.Code);

                ctx.Entry(dbFreshTransaction).CurrentValues.SetValues(dbTransaction);

                ctx.SaveChanges();
            }
        }
    }
}
