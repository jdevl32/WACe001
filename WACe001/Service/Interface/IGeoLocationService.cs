using System.Threading.Tasks;

namespace WACe001.Service.Interface
{

	public interface IGeoLocationService
		:
		IService
	{

		/// <summary>
		/// Get the coordinates of a location by name.
		/// </summary>
		/// <param name="locationName">
		/// The name of the location.
		/// </param>
		/// <returns>
		/// A geo-location result.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<IGeoLocationResult> GetCoordinatesAsync(string locationName);

	}

}
