namespace WACe001.Service.Interface
{

	public interface IServiceResult
	{

#region Property

		/// <summary>
		/// Success status of the result.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add setter -- required for geo-location service.
		/// </remarks>
		bool Success { get; set; }

		/// <summary>
		/// The result message.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add setter -- required for geo-location service.
		/// </remarks>
		string Message { get; set; }

#endregion

	}

}
