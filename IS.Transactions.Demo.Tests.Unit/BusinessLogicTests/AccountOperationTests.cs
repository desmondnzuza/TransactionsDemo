using IS.Transactions.Demo.BusinessLogic;
using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IS.Transactions.Demo.Tests.Unit.BusinessLogicTests
{
    [TestClass]
    public class AccountOperationTests
    {
        private Account _dummyAccount;
        private SearchCriteria _criteria;
        private Mock<IAccountRepository> _mockedAccountRepository;
        private Mock<IPersonRepository> _mockedPersonRepository;
        private IAccountOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _dummyAccount = new Account();
            _criteria = new SearchCriteria
            {
                Term = "Something",
                From = 1,
                To = 10
            };
            _mockedAccountRepository = new Mock<IAccountRepository>();
            _mockedPersonRepository = new Mock<IPersonRepository>();

            _sut = new AccountOperation(
                _mockedAccountRepository.Object,
                _mockedPersonRepository.Object);
        }

        [TestMethod]
        public void AccountOperationTests_WhenFindingAccountWithAValidRequest_Expect_RepositoryCallToFindAccount_ToBeMade()
        {
            _sut.FindAccounts(_criteria);

            _mockedAccountRepository.Verify(x => x.FindAccounts(_criteria), Times.Once);
        }

        [TestMethod]
        public void AccountOperationTests_WhenFindingAccountsWithAnInValidRequest_Expect_RepositoryCallToFindAccount_ToNotBeMade()
        {
            _criteria = new SearchCriteria
            {
                Term = string.Empty,
                From = 1,
                To = 10
            };
            _sut.FindAccounts(_criteria);

            _mockedAccountRepository.Verify(x => x.FindAccounts(_criteria), Times.Never);
        }

        [TestMethod]
        public void AccountOperationTests_WhenFindingAccountByCode_Expect_RepositoryCallToFindAccountByCode_ToBeMade()
        {
            var code = 123;
            _sut.FindAccountByCode(code);

            _mockedAccountRepository.Verify(x => x.FindAccountByCode(code), Times.Once);
        }

        [TestMethod]
        public void AccountOperationTests_WhenCreatingAccount_Expect_RepositoryCallToCreateAccount_ToBeMade()
        {
            _sut.CreateAccount(_dummyAccount);

            _mockedAccountRepository.Verify(x => x.CreateAccount(_dummyAccount), Times.Once);
        }

        [TestMethod]
        public void AccountOperationTests_WhenUpdatingAccount_Expect_RepositoryCallToUpdateAccount_ToBeMade()
        {
            _sut.UpdateAccount(_dummyAccount);

            _mockedAccountRepository.Verify(x => x.UpdateAccount(_dummyAccount), Times.Once);
        }

        [TestMethod]
        public void AccountOperationTests_WhenRemovingAccount_Expect_RepositoryCallToRemoveAccount_ToBeMade()
        {
            _sut.RemoveAccount(_dummyAccount);

            _mockedAccountRepository.Verify(x => x.RemoveAccount(_dummyAccount), Times.Once);
        }

        [TestMethod]
        public void AccountOperationTests_WhenFindingAvailablePeople_Expect_RepositoryCallToFindAvailablePeople_ToBeMade()
        {
            _sut.FindAvailablePeople();

            _mockedPersonRepository.Verify(x => x.FindAvailablePeople(), Times.Once);
        }
    }
}
