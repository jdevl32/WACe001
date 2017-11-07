using Microsoft.AspNetCore.Mvc;
using WACe001.ViewModel;

namespace WACe001.Controller.Web.Interface
{

	public interface IAppController
	{

		IActionResult About();

		IActionResult Contact();

		// todo|jdevl32: replace with interface ???
		IActionResult Contact(ContactViewModel model);

		/// <summary>
		/// Default action for the controller.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IActionResult Index();

		/// <summary>
		/// Action for authenicated users to view their trips.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IActionResult Trips();
	}

}
