using IS.Transactions.Demo.BusinessLogic;
using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IS.Transactions.Demo.Tests.Unit.BusinessLogicTests
{
    [TestClass]
    public class TransactionOperationTests
    {
        private Transaction _dummyTransaction;
        private SearchCriteria _criteria;
        private Mock<ITransactionRepository> _mockedTransactionRepository;
        private Mock<IAccountRepository> _mockedAccountRepository;        
        private ITransactionOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _dummyTransaction = new Transaction();
            _criteria = new SearchCriteria
            {
                Term = "Something",
                From = 1,
                To = 10
            };
            _mockedTransactionRepository = new Mock<ITransactionRepository>();
            _mockedAccountRepository = new Mock<IAccountRepository>();

            _sut = new TransactionOperation(
                _mockedTransactionRepository.Object,
                _mockedAccountRepository.Object);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenFindingTransactionWithAValidRequest_Expect_RepositoryCallToFindTransaction_ToBeMade()
        {
            _sut.FindTransactions(_criteria);

            _mockedTransactionRepository.Verify(x => x.FindTransactions(_criteria), Times.Once);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenFindingTransactionsWithAnInValidRequest_Expect_RepositoryCallToFindTransaction_ToNotBeMade()
        {
            _criteria = new SearchCriteria
            {
                Term = string.Empty,
                From = 1,
                To = 10
            };
            _sut.FindTransactions(_criteria);

            _mockedTransactionRepository.Verify(x => x.FindTransactions(_criteria), Times.Never);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenFindingTransactionByCode_Expect_RepositoryCallToFindTransactionByCode_ToBeMade()
        {
            var code = 123;
            _sut.FindTransactionByCode(code);

            _mockedTransactionRepository.Verify(x => x.FindTransactionByCode(code), Times.Once);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenAddingTransaction_Expect_RepositoryCallToAddTransaction_ToBeMade()
        {
            _sut.AddTransaction(_dummyTransaction);

            _mockedTransactionRepository.Verify(x => x.AddTransaction(_dummyTransaction), Times.Once);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenUpdatingTransaction_Expect_RepositoryCallToUpdateTransaction_ToBeMade()
        {
            _sut.UpdateTransaction(_dummyTransaction);

            _mockedTransactionRepository.Verify(x => x.UpdateTransaction(_dummyTransaction), Times.Once);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenRemovingTransaction_Expect_RepositoryCallToRemoveTransaction_ToBeMade()
        {
            _sut.RemoveTransaction(_dummyTransaction);

            _mockedTransactionRepository.Verify(x => x.RemoveTransaction(_dummyTransaction), Times.Once);
        }

        [TestMethod]
        public void TransactionOperationTests_WhenFindingAvailablePeople_Expect_RepositoryCallToFindAvailablePeople_ToBeMade()
        {
            _sut.FindAvailableAccounts();

            _mockedAccountRepository.Verify(x => x.FindAvailableAccounts(), Times.Once);
        }
    }
}
