using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.BusinessLogic
{
    public class PersonOperation : IPersonOperation
    {
        private readonly IPersonRepository _personRepository;
        public PersonOperation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person[] FindPeople(SearchCriteria criteria)
        {
            if(criteria != null && !string.IsNullOrEmpty(criteria.Term))
            {
                return _personRepository.FindPeople(criteria);
            }

            return new Person[] { };
        }

        public Person FindPersonByCode(int code)
        {
            return _personRepository.FindPersonByCode(code);
        }

        public void CreatePerson(Person persondToAdd)
        {
            _personRepository.CreatePerson(persondToAdd);
        }

        public void UpdatePerson(Person personToUpdate)
        {
            _personRepository.UpdatePerson(personToUpdate);
        }

        public void RemovePerson(Person personToRemove)
        {
            _personRepository.RemovePerson(personToRemove);
        }
    }
}
