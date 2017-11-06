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
		/// </remarks>
		ICoordinate Coordinate { get; }

#endregion

	}

}
