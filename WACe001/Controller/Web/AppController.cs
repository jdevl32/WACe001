using Microsoft.AspNetCore.Mvc;
using WACe001.Service.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Web
{

	public class AppController
		:
		Microsoft.AspNetCore.Mvc.Controller
	{

#region Property

		private IMailService MailService { get; }

#endregion

#region Instance Initialization

		public AppController(IMailService mailService)
		{
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

		[HttpPost]
		public IActionResult Contact(ContactViewModel model)
		{
			MailService.SendMail("someone@somewhere.com", model.Email, model.Name, model.Message);
			return View();
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}

	}

}
