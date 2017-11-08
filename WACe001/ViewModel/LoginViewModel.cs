using System.ComponentModel.DataAnnotations;
using WACe001.ViewModel.Interface;

namespace WACe001.ViewModel
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public class LoginViewModel
		:
		ILoginViewModel
	{

#region Property

		/// <inheritdoc />
		/// <remarks>
		/// Setter is required.
		/// Last modification:
		/// </remarks>
		[Required]
		public string Username { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Setter is required.
		/// Last modification:
		/// </remarks>
		[Required]
		public string Password { get; set; }

#endregion

	}

}
