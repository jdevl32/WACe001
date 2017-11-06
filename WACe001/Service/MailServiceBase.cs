using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Re-base to service base.
	/// </remarks>
	public abstract class MailServiceBase
		:
		ServiceBase<MailServiceBase>
		,
		IMailService
	{

#region Property

#endregion

#region Instance Initialization

		/// <inheritdoc />
		protected MailServiceBase(IConfigurationRoot configurationRoot, ILogger<MailServiceBase> logger)
			:
			base(configurationRoot, logger)
		{
		}

#endregion

#region Abstract

		/// <summary>
		/// 
		/// </summary>
		/// <param name="to">
		/// 
		/// </param>
		/// <param name="from">
		/// 
		/// </param>
		/// <param name="subject">
		/// 
		/// </param>
		/// <param name="body">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public abstract void SendMail(string to, string from, string subject, string body);

#endregion

	}

}
