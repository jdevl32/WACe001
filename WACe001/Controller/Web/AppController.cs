using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WACe001.Controller.Web
{

	public class AppController : Microsoft.AspNetCore.Mvc.Controller
	{

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}

	}

}
