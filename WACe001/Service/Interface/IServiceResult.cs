namespace WACe001.Service.Interface
{

	public interface IServiceResult
	{

		/// <summary>
		/// Success status of the result.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		bool Success { get; }

		/// <summary>
		/// The result message.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string Message { get; }

	}

}
