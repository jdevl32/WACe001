namespace WACe001.Service.Interface
{

	public interface IMailService
		:
		IService
	{

		/// <summary>
		/// Send a mail message.
		/// </summary>
		/// <param name="to">
		/// To whom the message is sent.
		/// </param>
		/// <param name="from">
		/// From whom the message is sent.
		/// </param>
		/// <param name="subject">
		/// The subject of the message.
		/// </param>
		/// <param name="body">
		/// The body of the message.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void SendMail(string to, string from, string subject, string body);

	}

}
