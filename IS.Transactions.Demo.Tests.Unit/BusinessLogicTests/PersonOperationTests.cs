using IS.Transactions.Demo.BusinessLogic;
using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IS.Transactions.Demo.Tests.Unit.BusinessLogicTests
{
    [TestClass]
    public class PersonOperationTests
    {
        private Person _dummyPerson;        
        private SearchCriteria _criteria;
        private Mock<IPersonRepository> _mockedPersonRepository;
        private IPersonOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _dummyPerson = new Person();
            _criteria = new SearchCriteria
            {
                Term = "Something",
                From = 1,
                To = 10
            };
            _mockedPersonRepository = new Mock<IPersonRepository>();            

            _sut = new PersonOperation(_mockedPersonRepository.Object);
        }

        [TestMethod]
        public void PersonOperationTests_WhenFindingPeopleWithAValidRequest_Expect_RepositoryCallToFindPerson_ToBeMade()
        {
            _sut.FindPeople(_criteria);

            _mockedPersonRepository.Verify(x => x.FindPeople(_criteria), Times.Once);
        }

        [TestMethod]
        public void PersonOperationTests_WhenFindingPeopleWithAnInValidRequest_Expect_RepositoryCallToFindPerson_ToNotBeMade()
        {
            _criteria = new SearchCriteria
            {
                Term = string.Empty,
                From = 1,
                To = 10
            };
            _sut.FindPeople(_criteria);

            _mockedPersonRepository.Verify(x => x.FindPeople(_criteria), Times.Never);
        }

        [TestMethod]
        public void PersonOperationTests_WhenFindingPersonByCode_Expect_RepositoryCallToFindPersonByCode_ToBeMade()
        {
            var code = 123;
            _sut.FindPersonByCode(code);

            _mockedPersonRepository.Verify(x => x.FindPersonByCode(code), Times.Once);
        }

        [TestMethod]
        public void PersonOperationTests_WhenCreatingPerson_Expect_RepositoryCallToCreatePerson_ToBeMade()
        {
            _sut.CreatePerson(_dummyPerson);

            _mockedPersonRepository.Verify(x => x.CreatePerson(_dummyPerson), Times.Once);
        }

        [TestMethod]
        public void PersonOperationTests_WhenUpdatingPerson_Expect_RepositoryCallToUpdatePerson_ToBeMade()
        {
            _sut.UpdatePerson(_dummyPerson);

            _mockedPersonRepository.Verify(x => x.UpdatePerson(_dummyPerson), Times.Once);
        }

        [TestMethod]
        public void PersonOperationTests_WhenRemovingPerson_Expect_RepositoryCallToRemovePerson_ToBeMade()
        {
            _sut.RemovePerson(_dummyPerson);

            _mockedPersonRepository.Verify(x => x.RemovePerson(_dummyPerson), Times.Once);
        }
    }
}
