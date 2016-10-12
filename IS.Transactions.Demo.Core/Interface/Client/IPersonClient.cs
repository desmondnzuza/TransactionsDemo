using IS.Transactions.Demo.Core.Model;

namespace IS.Transactions.Demo.Core.Interface.Client
{
    public interface IPersonClient
    {
        Person[] FindPeople(SearchCriteria criteria);
        Person FindPersonByCode(int code);
        void CreatePerson(Person personToAdd);
        void UpdatePerson(Person personToUpdate);
        void RemovePerson(Person personToRemove);
    }
}
