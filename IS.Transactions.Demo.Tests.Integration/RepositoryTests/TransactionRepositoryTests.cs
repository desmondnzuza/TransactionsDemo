using IS.Transactions.Demo.Core.Interface.Repository;
using IS.Transactions.Demo.SQL.Repository;
using IS.Transactions.Demo.SQL.Repository.POCO;
using IS.Transactions.Demo.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Should;

namespace IS.Transactions.Demo.Tests.Integration.RepositoryTests
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        private ITransactionRepository _sut;
        private Transaction _transaction;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new TransactionRepository();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TransactionHelper.RemoveTransaction(_transaction);
        }

        [TestMethod]
        public void TransactionRepositoryTests_WhenFindingAvailableTransactions_Expect_Results()
        {
            var results = _sut.FindAvailableTransactions();

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TransactionRepositoryTests_WhenFindingTransactionByValidId_Expect_Result()
        {
            var result = _sut.FindTransactionByCode(41);

            result.ShouldNotBeNull();
        }
    }
}
