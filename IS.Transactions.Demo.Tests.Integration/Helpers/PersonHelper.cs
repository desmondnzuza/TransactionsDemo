using IS.Transactions.Demo.SQL.Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ctx.People.Remove(personToRemove);
                    ctx.SaveChanges();
                }
            }            
        }
    }
}
