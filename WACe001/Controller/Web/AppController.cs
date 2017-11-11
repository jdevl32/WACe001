using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WACe001.Controller.Web.Interface;
using WACe001.Repository.Interface;
using WACe001.Service.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	/// <summary>
	/// The app controller.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Rebase with generic base controller.
	/// </remarks>
	public class AppController
		:
		ControllerBase<AppController>
		,
		IAppController
	{

#region Property

		/// <summary>
		/// The configuration root.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		private IConfigurationRoot ConfigurationRoot { get; }

		/// <summary>
		/// The mail service.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		private IMailService MailService { get; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="configurationRoot">
		/// 
		/// </param>
		/// <param name="logger">
		/// 
		/// </param>
		/// <param name="mailService">
		/// 
		/// </param>
		/// <param name="travelRepository">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add logger.
		/// </remarks>
		public AppController(IConfigurationRoot configurationRoot, ILogger<AppController> logger, IMailService mailService, ITravelRepository travelRepository)
			:
			base(logger, travelRepository)
		{
			ConfigurationRoot = configurationRoot;
			MailService = mailService;
		}

#endregion

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

		// todo|jdevl32: replace with interface ???
		[HttpPost]
		public IActionResult Contact(ContactViewModel model)
		{
			if (model.Email.Contains("spam"))
			{
				ModelState.AddModelError("", "Somebody's been bad!");
			} // if

			if (ModelState.IsValid)
			{
				MailService.SendMail(ConfigurationRoot["Contact:Email:To"], model.Email, model.Name, model.Message);
				ModelState.Clear();

				ViewBag.UserMessage = "Message Sent!";
			} // if

			return View();
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Move functionality to trips action.
		/// </remarks>
		public IActionResult Index()
		{
			return View();
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Delegate functionality to the angular controller.
		/// </remarks>
		[Authorize]
		public IActionResult Trips()
		{
			return View();
		}

	}

}
