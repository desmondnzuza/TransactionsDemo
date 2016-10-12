using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System;
using System.Linq;

namespace IS.Transactions.Demo.Web.UI.Client.FakeClient
{
    public class FakePersonClient : IPersonClient
    {
        private readonly Person[] _people;

        public FakePersonClient()
        {
            _people = new Person[]
            {
                new Person {Code = 1, Name ="Desmond", Surname = "Nzuza" },
                new Person {Code = 2, Name ="Suzan", Surname = "Blunt" },
                new Person {Code = 3, Name ="Peter", Surname = "Page" },
                new Person {Code = 4, Name ="John", Surname = "Doe" },
                new Person {Code = 5, Name ="Marry", Surname = "Jane" }
            };
        }

        public void CreatePerson(Person personToAdd)
        {
            throw new NotImplementedException();
        }

        public Person[] FindPeople(SearchCriteria criteria)
        {
            return _people;
        }

        public Person FindPersonByCode(int code)
        {
            return _people.FirstOrDefault(p => p.Code.Equals(code));
        }

        public void RemovePerson(Person personToRemove)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person personToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}