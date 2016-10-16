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
        
        public ActionResult Index(int? selectedAccountHolder)
        {
            var accountHolders = _client.FindAvailablePeople();
            ViewBag.SelectedAccountHolder = new SelectList(accountHolders, "Code", "FullName", selectedAccountHolder);
            int accountHolderID = selectedAccountHolder.GetValueOrDefault();

            var filters = new Dictionary<string, string>();
            filters.Add("accountHolderID", accountHolderID.ToString());

            var defaultCriteria = new SearchCriteria
            {
                Term = "*",
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
            var availablePeople = _client.FindAvailablePeople();

            var selectListItems = from person in availablePeople
                                  select new SelectListItem
                                  {
                                      Text = string.Format("{0} {1}", person.Name, person.Surname),
                                      Value = person.Code.ToString()
                                  };

            ViewBag.AvailablePeopleList = new SelectList(selectListItems);

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
            var transactionToEdit = _client.FindAccountByCode(code);

            return View(transactionToEdit);
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
