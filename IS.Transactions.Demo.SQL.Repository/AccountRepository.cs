using IS.Transactions.Demo.Core.Interface.Repository;
using System;
using System.Linq;
using IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.SQL.Repository.Helpers;

namespace IS.Transactions.Demo.SQL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void CreateAccount(Account accountToAdd)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var itemToAdd = accountToAdd.ToDbModelAccount();
                ctx.Accounts.Add(itemToAdd);

                ctx.SaveChanges();
            }
        }

        public Account FindAccountByCode(int code)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbAccount = ctx.Accounts
                    .FirstOrDefault(c => c.Code == code);

                if (dbAccount != null)
                {
                    return dbAccount.ToCoreModelAccount();
                }
            }

            return null;
        }

        public Account[] FindAccounts(SearchCriteria criteria)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                int pageSize = criteria.PageSize;
                int pageNumber = criteria.PageNumber > 1 ? criteria.PageNumber : 1;
                
                IQueryable<POCO.Account> query = ctx.Accounts
                    /*.Where(c =>
                          (c.Name.Contains(criteria.Term) ||
                            c.Surname.Contains(criteria.Term) ||
                            criteria.Term == "*"))*/
                    .OrderByDescending(x => x.Code);

                var dbResults = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelAccount())
                      .ToArray();

            }
        }

        public Account[] FindAvailableAccounts()
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
               var query = ctx.Accounts;

                return query
                          .Select(x => x.ToCoreModelAccount())
                          .ToArray();
            }

        }

        public void RemoveAccount(Account accountToRemove)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var accountToDelete = ctx.Accounts
                    //.Include(x => x.Products)
                    .FirstOrDefault(c => c.Code == accountToRemove.Code);

                if (accountToDelete != null)
                {
                    //foreach (var dbProduct in categoryToDelete.Products.ToArray())
                    //    ctx.Entry<SQLPOCO.Product>(dbProduct).State = EntityState.Modified;

                    ctx.Accounts.Remove(accountToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbAccount = accountToUpdate.ToDbModelAccount();

                var dbFreshAccount = ctx.Accounts
                       .Single(c => c.Code == dbAccount.Code);

                ctx.Entry(dbFreshAccount).CurrentValues.SetValues(dbAccount);

                ctx.SaveChanges();
            }
        }
    }
}
