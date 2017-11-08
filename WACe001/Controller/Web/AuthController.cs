using Microsoft.AspNetCore.Mvc;

namespace WACe001.Controller.Web
{

	// todo|jdevl32: interface !!!
	public class AuthController
		:
		Microsoft.AspNetCore.Mvc.Controller
	{

		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Trips", "App");
			} // if

			return View();
		}

	}

}
