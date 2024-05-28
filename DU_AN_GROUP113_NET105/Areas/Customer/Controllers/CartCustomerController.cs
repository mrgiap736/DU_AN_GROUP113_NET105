using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DU_AN_GROUP113_NET105.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartCustomerController : Controller
    {
        // GET: CartCustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartCustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartCustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartCustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartCustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartCustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartCustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartCustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
