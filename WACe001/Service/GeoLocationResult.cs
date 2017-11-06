using WACe001.Entity.Interface;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	public class GeoLocationResult
		:
		IGeoLocationResult
	{

#region Property

		/// <inheritdoc />
		public bool Success { get; set; }

		/// <inheritdoc />
		public string Message { get; set; }

		/// <inheritdoc />
		public ICoordinate Coordinate { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a geo-location result.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public GeoLocationResult() => Success = false;

		/// <inheritdoc />
		/// <summary>
		/// Create a geo-location result.
		/// </summary>
		/// <param name="message">
		/// The result message.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public GeoLocationResult(string message)
			:
			this() => Message = message;

#endregion

	}

}
