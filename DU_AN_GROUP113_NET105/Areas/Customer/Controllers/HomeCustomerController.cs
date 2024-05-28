using Microsoft.AspNetCore.Mvc;

namespace DU_AN_GROUP113_NET105.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeCustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();  
        }
    }
}
