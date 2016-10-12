using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Operation
{
    public interface IPersonOperation
    {
        Person[] FindPeople(SearchCriteria criteria);
        Person FindPersonByCode(int code);
        void CreatePerson(Person persondToAdd);
        void UpdatePerson(Person personToUpdate);
        void RemovePerson(Person personToRemove);
    }
}
