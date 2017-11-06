using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WACe001.Service.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Api.Interface
{

	public interface IStopController
	{

#region Property

		/// <summary>
		/// The geo-location service (to provide location coordinates).
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IGeoLocationService GeoLocationService { get; }

#endregion

		/// <summary>
		/// Get stops by trip name.
		/// </summary>
		/// <param name="tripName">
		/// The name of the trip.
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IActionResult Get(string tripName);

		/// <summary>
		/// Create a new stop (for a trip) by trip name.
		/// POST: api/trip/{tripName}/stop
		/// </summary>
		/// <param name="tripName">
		/// 
		/// </param>
		/// <param name="stopViewModel">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		Task<IActionResult> Post(string tripName, [FromBody]StopViewModel stopViewModel);

	}

}
