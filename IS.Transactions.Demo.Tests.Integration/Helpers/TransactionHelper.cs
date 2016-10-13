using IS.Transactions.Demo.SQL.Repository.POCO;
using System.Linq;

namespace IS.Transactions.Demo.Tests.Integration.Helpers
{
    public static class TransactionHelper
    {
        public static void RemoveTransaction(Transaction transactionToRemove)
        {
            if (transactionToRemove != null && transactionToRemove.Code > 0)
            {
                using (var ctx = new TransactionsDbContext())
                {
                    var itemToDelete = ctx.Transactions.FirstOrDefault(x => x.Code == transactionToRemove.Code);

                    if (itemToDelete != null)
                    {
                        ctx.Transactions.Remove(itemToDelete);
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}
