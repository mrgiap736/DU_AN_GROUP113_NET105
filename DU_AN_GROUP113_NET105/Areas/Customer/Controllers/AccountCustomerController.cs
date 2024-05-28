using DU_AN_GROUP113_NET105.Models.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DU_AN_GROUP113_NET105.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountCustomerController : Controller
    {
        public ProjectContext _context;

        public AccountCustomerController(ProjectContext context)
        {
            _context = context;
        }

        // GET: AccountCustomerController
        public ActionResult Index()
        {
            var checklogin = HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(checklogin))
            {
                return RedirectToAction("LoginRegisterAcc");
            }
            else
            {
                return View();
            }

        }

        // GET: AccountCustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountCustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountCustomerController/Create
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

        // GET: AccountCustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountCustomerController/Edit/5
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

        // GET: AccountCustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountCustomerController/Delete/5
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

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["loginfaild"] = "Please enter username and password !";
                return RedirectToAction("Index", "HomeCustomer");
            }

            var account = _context.Customer.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (account == null)
            {
                TempData["loginfaild"] = "Account information or password is incorrect!";
                return RedirectToAction("Index", "HomeCustomer");
            }
            else
            {
                // Tạo danh sách các claim
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, account.Username), // Sử dụng tên người dùng từ cơ sở dữ liệu
                   new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()) // Sử dụng ID người dùng từ cơ sở dữ liệu
                      // Bạn có thể thêm các claim khác tùy thuộc vào yêu cầu của ứng dụng của bạn
                };

                // Tạo một ClaimsIdentity với các claims và scheme xác thực
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Tạo một ClaimsPrincipal với ClaimsIdentity
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Đăng nhập người dùng
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "HomeCustomer");
            }
        }

        public IActionResult Logout()
        {
            // Xóa thông tin xác thực của người dùng
            HttpContext.SignOutAsync();

            // Redirect đến trang chính hoặc trang đăng nhập
            return RedirectToAction("Index", "HomeCustomer");
        }


        public ActionResult LoginRegisterAcc()
        {
            return View();
        }
    }
}
