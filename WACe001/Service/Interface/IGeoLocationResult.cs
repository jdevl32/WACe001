using WACe001.Entity.Interface;

namespace WACe001.Service.Interface
{

	public interface IGeoLocationResult
		:
		IServiceResult
	{

#region Property

		/// <summary>
		/// The coordinates of the location.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Add setter -- required for geo-location service.
		/// </remarks>
		ICoordinate Coordinate { get; set; }

#endregion

	}

}
