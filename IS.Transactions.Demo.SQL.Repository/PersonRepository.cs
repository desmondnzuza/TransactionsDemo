using IS.Transactions.Demo.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Transactions.Demo.Core.Model;
using POCO = IS.Transactions.Demo.SQL.Repository.POCO;
using IS.Transactions.Demo.SQL.Repository.Helpers;

namespace IS.Transactions.Demo.SQL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public void CreatePerson(Person persondToAdd)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var itemToAdd = persondToAdd.ToDbModelPerson();
                ctx.People.Add(itemToAdd);

                ctx.SaveChanges();
            }
        }

        public Person[] FindAvailablePeople()
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var avaiablePeople = ctx.People.ToArray();

                return avaiablePeople
                      .Select(x => x.ToCoreModelPerson())
                      .ToArray();
            }
        }

        public Person[] FindPeople(SearchCriteria criteria)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                int pageSize = criteria.PageSize;
                int pageNumber = criteria.PageNumber > 1 ? criteria.PageNumber : 1;

                var query = ctx.People
                    .Where(c =>
                          (c.Name.Contains(criteria.Term) ||
                            c.Surname.Contains(criteria.Term) ||
                            criteria.Term == "*"))
                    .OrderByDescending(x => x.Code);

                var dbResults = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelPerson())
                      .ToArray();

            }
        }

        public Person FindPersonByCode(int code)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbPerson = ctx.People
                    .FirstOrDefault(c => c.Code == code);

                if (dbPerson != null)
                {
                    return dbPerson.ToCoreModelPerson();
                }
            }

            return null;
        }

        public void RemovePerson(Person personToRemove)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var personToDelete = ctx.People
                    //.Include(x => x.Products)
                    .FirstOrDefault(c => c.Code == personToRemove.Code);

                if (personToDelete != null)
                {
                    //foreach (var dbProduct in categoryToDelete.Products.ToArray())
                    //    ctx.Entry<SQLPOCO.Product>(dbProduct).State = EntityState.Modified;

                    ctx.People.Remove(personToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdatePerson(Person personToUpdate)
        {
            using (var ctx = new POCO.TransactionsDbContext())
            {
                var dbPerson = personToUpdate.ToDbModelPerson();

                var dbFreshPerson = ctx.People
                       .Single(c => c.Code == dbPerson.Code);

                ctx.Entry(dbFreshPerson).CurrentValues.SetValues(dbPerson);

                ctx.SaveChanges();
            }
        }
    }
}
