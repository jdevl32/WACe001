using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WACe001.Controller.Web.Interface;
using WACe001.Entity;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	public class AuthController
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IAuthController
	{

#region Property

		/// <inheritdoc />
		public SignInManager<Traveler> SignInManager { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a new authorization controller.
		/// </summary>
		/// <param name="signInManager">
		/// The sign-in manager (for traveler).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public AuthController(SignInManager<Traveler> signInManager) => SignInManager = signInManager;

#endregion

		/// <inheritdoc />
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Trips", "App");
			} // if

			return View();
		}

		/// <inheritdoc />
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if ((await SignInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, false)).Succeeded)
				{
					if (string.IsNullOrWhiteSpace(returnUrl))
					{
						return RedirectToAction("Trips", "App");
					} // if

					return Redirect(returnUrl);
				} // if
				
				// todo|jdevl32: constant(s)...
				ModelState.AddModelError(string.Empty, "Invalid username or password.");
			} // if

			return View();
		}

		/// <inheritdoc />
		public async Task<IActionResult> Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				await SignInManager.SignOutAsync();
			} // if

			return RedirectToAction("Index", "App");
		}

	}

}
