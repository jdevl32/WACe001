using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using WACe001.Controller.Web.Interface;
using WACe001.Repository.Interface;
using WACe001.Service.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	public class AppController
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IAppController
	{

#region Property

		private IConfigurationRoot ConfigurationRoot { get; }

		private ILogger<IAppController> Logger { get; }

		private IMailService MailService { get; }

		private ITravelRepository TravelRepository { get; }

#endregion

#region Instance Initialization

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
		public AppController(IConfigurationRoot configurationRoot, ILogger<IAppController> logger, IMailService mailService, ITravelRepository travelRepository)
		{
			ConfigurationRoot = configurationRoot;
			Logger = logger;
			MailService = mailService;
			TravelRepository = travelRepository;
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

		// todo: replace with interface ???
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
		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Implement error logging.
		/// </remarks>
		public IActionResult Index()
		{
			try
			{
				return View(TravelRepository.GetTrips());
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error retrieving trips:  {ex}");
			} // catch

			return Redirect("/error");
		}

	}

}
