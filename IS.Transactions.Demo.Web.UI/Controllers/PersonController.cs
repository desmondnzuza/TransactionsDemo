using IS.Transactions.Demo.Core.Interface.Client;
using IS.Transactions.Demo.Core.Model;
using System.Web.Mvc;

namespace IS.Transactions.Demo.Web.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonClient _client;

        public PersonController(IPersonClient client)
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

            var people = _client.FindPeople(defaultCriteria);

            return View(people);
        }


        public ActionResult Details(int code)
        {
            var transactionToInspect = _client.FindPersonByCode(code);

            return View(transactionToInspect);
        }

        public ActionResult Create()
        {
            //TODO: populate items for dropdown

            return View();
        }

        [HttpPost]
        public ActionResult Create(Person model, FormCollection collection)
        {
            try
            {
                _client.CreatePerson(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int code)
        {
            var transactionToEdit = _client.FindPersonByCode(code);

            return View(transactionToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Person model, FormCollection collection)
        {
            try
            {
                _client.UpdatePerson(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int code)
        {
            var personToRemove = _client.FindPersonByCode(code);

            return View(personToRemove);
        }

        [HttpPost]
        public ActionResult Delete(Person model, FormCollection collection)
        {
            try
            {
                _client.RemovePerson(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}