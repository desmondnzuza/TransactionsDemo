using IS.Transactions.Demo.Core.Interface.Repository;
using CoreModel = IS.Transactions.Demo.Core.Model;
using IS.Transactions.Demo.SQL.Repository;
using IS.Transactions.Demo.SQL.Repository.POCO;
using IS.Transactions.Demo.Tests.Integration.Builders;
using IS.Transactions.Demo.Tests.Integration.Helpers;
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
            /*_person = new PersonBuilder()
                .WithName("www")
                .WithSurname("www")
                .WithIdNumber("45XX2605080XX")
                .Build();

            var result = _sut.FindPersonByCode(_person.Code);

            result.ShouldNotBeNull();
            result.Name.ShouldEqual("www");
            result.Surname.ShouldEqual("www");*/
        }

        [TestMethod]
        public void PersonRepositoryTests_WhenFindingPersonByValidKnownId_Expect_Result()
        {
            var result = _sut.FindPersonByCode(3);

            result.ShouldNotBeNull();
            result.Name.ShouldEqual("NTOMBIKHONA");
            result.Surname.ShouldEqual("MLAMBO");
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
    }
}
