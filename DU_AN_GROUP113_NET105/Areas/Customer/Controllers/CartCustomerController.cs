using DU_AN_GROUP113_NET105.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DU_AN_GROUP113_NET105.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartCustomerController : Controller
    {
        ProjectContext _context;

        public CartCustomerController(ProjectContext context)
        {
             _context = context;
        }
        // GET: CartCustomerController
        public ActionResult Index()
        {
            string getCartId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(getCartId == null)
            {
                return RedirectToAction("Index","HomeCustomer");
            }
            else
            {
                Guid cartId = Guid.Parse(getCartId);

                var cartDetails = _context.CartDetail.Include(x => x.Product).Where(x => x.CartId == cartId).ToList();
                return View(cartDetails);
            }   
        }

		public ActionResult GetImage(int id)
		{
			var product = _context.Product.Find(id); // Thay Products bằng tên bảng sản phẩm của bạn
			if (product != null)
			{
				// Lấy ảnh sản phẩm từ cơ sở dữ liệu
				byte[] imageBytes = product.Image; // Thay Image bằng tên trường chứa ảnh trong bảng sản phẩm của bạn
				return File(imageBytes, "image/jpeg");
			}
			return null;
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
