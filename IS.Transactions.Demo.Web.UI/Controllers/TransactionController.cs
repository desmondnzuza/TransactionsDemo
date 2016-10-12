using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System.Web.Mvc;

namespace IS.Transactions.Demo.Web.UI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionClient _client;

        public TransactionController(ITransactionClient client)
        {
            _client = client;
        }

        public ActionResult Index()
        {
            var defaultCriteria = new SearchCriteria
            {
                Term = "*",
                PageNumber = 1,
                PageSize = 100
            };

            var transactions = _client.FindTransactions(defaultCriteria);

            return View(transactions);
        }

        public ActionResult Details(int code)
        {
            var transactionToInspect = _client.FindTransactionByCode(code);

            return View(transactionToInspect);
        }

        public ActionResult Create()
        {
            //TODO: populate items for dropdown

            return View();
        }

        [HttpPost]
        public ActionResult Create(Transaction model, FormCollection collection)
        {
            try
            {
                _client.CreateTransaction(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int code)
        {
            var transactionToEdit = _client.FindTransactionByCode(code);

            return View(transactionToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Transaction model, FormCollection collection)
        {
            try
            {
                _client.UpdateTransaction(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int code)
        {
            var transactionToRemove = _client.FindTransactionByCode(code);

            return View(transactionToRemove);
        }

        [HttpPost]
        public ActionResult Delete(Transaction model, FormCollection collection)
        {
            try
            {
                _client.RemoveTransaction(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
