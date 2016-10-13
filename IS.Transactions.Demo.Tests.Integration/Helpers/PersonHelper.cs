using IS.Transactions.Demo.SQL.Repository.POCO;
using System.Linq;

namespace IS.Transactions.Demo.Tests.Integration.Helpers
{
    public static class PersonHelper
    {
        public static void RemovePerson(Person personToRemove)
        {
            if (personToRemove != null && personToRemove.Code > 0)
            {
                using (var ctx = new TransactionsDbContext())
                {
                    var itemToDelete = ctx.People.FirstOrDefault(x => x.Code == personToRemove.Code);

                    if(itemToDelete != null)
                    {
                        ctx.People.Remove(itemToDelete);
                        ctx.SaveChanges();
                    }
                }
            }            
        }
    }
}
