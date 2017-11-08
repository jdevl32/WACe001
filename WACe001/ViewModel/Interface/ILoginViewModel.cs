namespace WACe001.ViewModel.Interface
{

	/// <summary>
	/// The login view model.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface ILoginViewModel
	{

#region Property

		/// <summary>
		/// The login username.
		/// </summary>
		/// <remarks>
		/// Setter is required.
		/// Last modification:
		/// </remarks>
		string Username { get; set; }

		/// <summary>
		/// The login password.
		/// </summary>
		/// <remarks>
		/// Setter is required.
		/// Last modification:
		/// </remarks>
		string Password { get; set; }

#endregion

	}

}
