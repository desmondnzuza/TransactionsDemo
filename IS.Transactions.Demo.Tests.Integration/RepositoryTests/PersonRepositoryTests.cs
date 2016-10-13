using IS.Transactions.Demo.Core.Interface.Repository;
using CoreModel = IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.SQL.Repository;
using IS.Transactions.Demo.SQL.Repository.POCO;
using IS.Transactions.Demo.Tests.Integration.Builders;
using IS.Transactions.Demo.Tests.Integration.Helpers;
using IS.Transactions.Demo.SQL.Repository.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace IS.Transactions.Demo.Tests.Integration.RepositoryTests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private IPersonRepository _sut;
        private Person _person;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new PersonRepository();
        }

        [TestCleanup]
        public void CleanUp()
        {
            PersonHelper.RemovePerson(_person);
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenFindingAvailablePeople_Expect_Results()
        {
            var results = _sut.FindAvailablePeople();

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenFindingPersonByValidId_Expect_Result()
        {
            var guid = System.Guid.NewGuid();

            _person = new PersonBuilder()
                .WithName("nm_" + guid)
                .WithSurname("sn_" + guid)
                .WithIdNumber("id_" + guid)
                .Build();

            var result = _sut.FindPersonByCode(_person.Code);

            result.ShouldNotBeNull();
            result.Name.ShouldEqual("nm_" + guid);
            result.Surname.ShouldEqual("sn_" + guid);
            result.IdNumber.ShouldEqual("id_" + guid);
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenFindingPersonWithValidCriteria_Expect_Results()
        {
            var criteria = new CoreModel.SearchCriteria
            {
                Term = "NTOMBIKHONA",
                PageNumber = 1,
                PageSize = 10
            };

            var results = _sut.FindPeople(criteria);

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenCreatingPerson_Expect_NoErrors()
        {
            var guid = string.Format("c_{0}",  System.Guid.NewGuid());
            var person = new CoreModel.Person
            {
                Name = guid,
                Surname = guid,
                IdNumber = guid,
            };

            _sut.CreatePerson(person);
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenUpdatingPerson_Expect_NoErrors()
        {
            var guid = string.Format("u_{0}", System.Guid.NewGuid());
            _person = new PersonBuilder()
                .WithName(guid)
                .WithSurname(guid)
                .WithIdNumber(guid)
                .Build();

            var updateGuid = string.Format("u_{0}", System.Guid.NewGuid());
            var personToUpdate = _person.ToCoreModelPerson();
            personToUpdate.Name = updateGuid;

            _sut.UpdatePerson(personToUpdate);
        }

    }
}
