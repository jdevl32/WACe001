using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WACe001.Service
{

	public class FakeMailService
		:
		MailServiceBase
	{

#region Instance Initialization

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add configuration root (due to re-implementation of base).
		/// Re-base logger type.
		/// </remarks>
		public FakeMailService(IConfigurationRoot configurationRoot, ILogger<FakeMailService> logger)
			:
			base(configurationRoot, logger)
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
