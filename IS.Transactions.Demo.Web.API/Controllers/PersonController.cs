using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IS.Transactions.Demo.Web.API.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonOperation _operation;

        public PersonController(IPersonOperation personOperation)
        {
            _operation = personOperation;
        }

        [HttpPost]
        public Person[] FindPeople([FromBody]SearchCriteria criteria)
        {
            return _operation.FindPeople(criteria);
        }

        [HttpGet]
        public Person FindPersonByCode(int code)
        {
            return _operation.FindPersonByCode(code);
        }

        [HttpPost]
        public void CreatePerson(Person personToCreate)
        {
            _operation.CreatePerson(personToCreate);
        }

        [HttpPost]
        public void UpdatePerson(Person personToUpdate)
        {
            _operation.UpdatePerson(personToUpdate);
        }

        [HttpPost]
        public void RemovePerson(Person personToRemove)
        {
            _operation.RemovePerson(personToRemove);
        }
    }
}