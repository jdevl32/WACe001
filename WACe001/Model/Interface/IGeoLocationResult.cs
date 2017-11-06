using WACe001.Entity.Interface;

namespace WACe001.Model.Interface
{

	public interface IGeoLocationResult
	{

#region Property

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

		/// <summary>
		/// The coordinates of the location.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ICoordinate Coordinate { get; }

#endregion

	}

}
