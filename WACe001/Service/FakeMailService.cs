using System.Diagnostics;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	public class FakeMailService
		:
		IMailService
	{

		public void SendMail(string to, string @from, string subject, string body)
		{
			Debug.WriteLine($"[to={to}|from={from}|subject={subject}|body={body}]");
		}

	}

}
