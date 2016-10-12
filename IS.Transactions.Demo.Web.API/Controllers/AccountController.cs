using IS.Transactions.Demo.Core.Interface.Operation;
using IS.Transactions.Demo.Core.Model;
using System.Web.Http;

namespace IS.Transactions.Demo.Web.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountOperation _operation;

        public AccountController(IAccountOperation accountOperation)
        {
            _operation = accountOperation;
        }

        [HttpPost]
        public Account[] FindAccounts([FromBody]SearchCriteria criteria)
        {
            return _operation.FindAccounts(criteria);
        }

        [HttpGet]
        public Account FindAccountByCode(int code)
        {
            return _operation.FindAccountByCode(code);
        }

        [HttpPost]
        public void CreateAccount(Account accountToCreate)
        {
            _operation.CreateAccount(accountToCreate);
        }

        [HttpPost]
        public void UpdateAccount(Account accountToUpdate)
        {
            _operation.UpdateAccount(accountToUpdate);
        }

        [HttpPost]
        public void RemoveAccount(Account accountToRemove)
        {
            _operation.RemoveAccount(accountToRemove);
        }

        [HttpGet]
        public Person[] FindAvailablePeople()
        {
            return _operation.FindAvailablePeople();
        }
    }
}
