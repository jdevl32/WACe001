using Microsoft.Extensions.Logging;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	public class FakeMailService
		:
		MailServiceBase
	{

#region Instance Initialization

		/// <inheritdoc />
		public FakeMailService(ILogger<IMailService> logger)
			:
			base(logger)
		{
		}

#endregion

		/// <inheritdoc />
		public override void SendMail(string to, string from, string subject, string body)
		{
			Logger.LogDebug($"[to={to}|from={from}|subject={subject}|body={body}]");
		}

	}

}
