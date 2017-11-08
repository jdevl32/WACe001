using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.ViewModel;

namespace WACe001.Controller.Web.Interface
{

	/// <summary>
	/// The authorization controller.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface IAuthController
	{

#region Property

		/// <summary>
		/// The sign-in manager (for traveler).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		SignInManager<Traveler> SignInManager { get; }

#endregion

		/// <summary>
		/// The login action.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IActionResult Login();

		/// <summary>
		/// The login (POST) action.
		/// </summary>
		/// <param name="loginViewModel">
		/// The login view model.
		/// </param>
		/// <param name="returnUrl">
		/// The return URL.
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl);

		/// <summary>
		/// The logout action.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<IActionResult> Logout();

	}

}
