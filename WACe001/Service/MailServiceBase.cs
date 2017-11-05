using Microsoft.Extensions.Logging;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	public abstract class MailServiceBase
		:
		IMailService
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ILogger<IMailService> Logger { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		protected MailServiceBase(ILogger<IMailService> logger)
		{
			Logger = logger;
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
