using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Repository
{
    public interface IPersonRepository
    {
        Person[] FindPeople(SearchCriteria criteria);
        Person[] FindAvailablePeople();
        Person FindPersonByCode(int code);
        void CreatePerson(Person persondToAdd);
        void UpdatePerson(Person personToUpdate);
        void RemovePerson(Person personToRemove);
    }
}
