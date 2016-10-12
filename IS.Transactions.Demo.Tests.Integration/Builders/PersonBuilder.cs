using IS.Transactions.Demo.SQL.Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Transactions.Demo.Tests.Integration.Builders
{
    public class PersonBuilder
    {
        private string _name;
        private string _surname;
        private string _idNumber;

        public PersonBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public PersonBuilder WithSurname(string surname)
        {
            _surname = surname;

            return this;
        }
        
        public PersonBuilder WithIdNumber(string idNumber)
        {
            _idNumber = idNumber;

            return this;
        }

        public Person Build()
        {
            var person = new Person
            {
                Name = _name,
                Surname = _surname,
                IdNumber = _idNumber
            };

            using (var ctx = new TransactionsDbContext())
            {
                var dbResults = ctx.People
                    .Add(person);

                ctx.SaveChanges();

                return person;
            }
        }
    }
}
