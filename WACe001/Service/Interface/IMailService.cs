﻿namespace WACe001.Service.Interface
{

	public interface IMailService
	{

		void SendMail(string to, string from, string subject, string body);

	}

}
