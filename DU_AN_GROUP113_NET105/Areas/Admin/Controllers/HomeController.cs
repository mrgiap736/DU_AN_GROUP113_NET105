using Microsoft.AspNetCore.Mvc;

namespace DU_AN_GROUP113_NET105.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{
		[Area("Admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
