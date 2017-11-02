using System.ComponentModel.DataAnnotations;
using WACe001.Model.Interface;

namespace WACe001.ViewModel
{

	public class ContactViewModel
		:
		IContact
	{

		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[StringLength(4096, MinimumLength = 10)]
		public string Message { get; set; }

	}

}
