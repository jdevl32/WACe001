using Microsoft.AspNetCore.Mvc;
using WACe001.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WACe001.Controller.Web
{

	public class AppController : Microsoft.AspNetCore.Mvc.Controller
	{

		// GET: /<controller>/
		public IActionResult About()
		{
			return View();
		}

		// GET: /<controller>/
		public IActionResult Contact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Contact(ContactViewModel model)
		{
			return View();
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}

	}

}
