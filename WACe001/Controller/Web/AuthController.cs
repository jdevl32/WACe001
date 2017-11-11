using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WACe001.Controller.Web.Interface;
using WACe001.Entity;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	/// <summary>
	/// The authentication controller.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Rebase with generic base controller.
	/// </remarks>
	public class AuthController
		:
		ControllerBase<AuthController>
		,
		IAuthController
	{

#region Property

		/// <inheritdoc />
		public SignInManager<Traveler> SignInManager { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create a new authorization controller.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="signInManager">
		/// The sign-in manager (for traveler).
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add logger (for rebase).
		/// </remarks>
		public AuthController(ILogger<AuthController> logger, SignInManager<Traveler> signInManager)
			:
			base(logger) => SignInManager = signInManager;

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
