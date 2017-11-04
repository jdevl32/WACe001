using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WACe001.Repository.Interface;
using WACe001.Service.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	public class AppController
		:
		Microsoft.AspNetCore.Mvc.Controller
	{

#region Property

		private IConfigurationRoot ConfigurationRoot { get; }

		private IMailService MailService { get; }

		private ITravelRepository TravelRepository { get; }

#endregion

#region Instance Initialization

		public AppController(IConfigurationRoot configurationRoot, IMailService mailService, ITravelRepository travelRepository)
		{
			ConfigurationRoot = configurationRoot;
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

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Replace context with repository pattern.
		/// </remarks>
		public IActionResult Index() => View(TravelRepository.GetTrips());

	}

}
