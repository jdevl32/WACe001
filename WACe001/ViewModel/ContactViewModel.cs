using WACe001.Interface;

namespace WACe001.ViewModel
{

	public class ContactViewModel
		:
		IContact
	{

		public string Name { get; set; }

		public string Email { get; set; }

		public string Message { get; set; }

	}

}
