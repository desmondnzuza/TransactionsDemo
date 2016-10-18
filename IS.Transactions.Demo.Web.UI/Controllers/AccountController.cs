using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IS.Transactions.Demo.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountClient _client;

        public AccountController(IAccountClient client)
        {
            _client = client;
        }
        
        public ActionResult Index(int? selectedAccountHolder, string searchTerm)
        {
            var accountHolders = _client.FindAvailablePeople();
            ViewBag.SelectedAccountHolder = new SelectList(accountHolders, "Code", "FullName", selectedAccountHolder);
            int accountHolderID = selectedAccountHolder.GetValueOrDefault();

            var filters = new Dictionary<string, string>();
            filters.Add("accountHolderID", accountHolderID.ToString());

            ViewBag.CurrentFilter = searchTerm;

            var defaultCriteria = new SearchCriteria
            {
                Term = !string.IsNullOrWhiteSpace(searchTerm) ? searchTerm : "",
                PageNumber = 1,
                PageSize = 100,
                Filters = filters
            };

            var accounts = _client.FindAccounts(defaultCriteria);

            return View(accounts);
        }

        public ActionResult Details(int code)
        {
            var transactionToInspect = _client.FindAccountByCode(code);

            return View(transactionToInspect);
        }

        public ActionResult Create()
        {
            var accountHolders = _client.FindAvailablePeople();
            ViewBag.SelectedAccountHolder = new SelectList(accountHolders, "Code", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Account model, FormCollection collection)
        {
            try
            {
                _client.CreateAccount(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int code)
        {
            var accountToEdit = _client.FindAccountByCode(code);

            ViewBag.AvailableTransactions = new SelectList(accountToEdit.Transactions, "Code", "AccountNumber", null);

            return View(accountToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Account model, FormCollection collection)
        {
            try
            {
                _client.UpdateAccount(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int code)
        {
            var transactionToRemove = _client.FindAccountByCode(code);

            return View(transactionToRemove);
        }

        [HttpPost]
        public ActionResult Delete(Account model, FormCollection collection)
        {
            try
            {
                _client.RemoveAccount(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
