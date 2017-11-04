using Microsoft.AspNetCore.Mvc;
using WACe001.ViewModel;

namespace WACe001.Controller.Web.Interface
{

	public interface IAppController
	{

		IActionResult About();

		IActionResult Contact();

		// todo: replace with interface ???
		IActionResult Contact(ContactViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// 
		/// </remarks>
		IActionResult Index();

	}

}
