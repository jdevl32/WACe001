using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WACe001.ViewModel;

namespace WACe001.Controller.Api.Interface
{

	public interface ITripController
	{

		/// <summary>
		/// Get the entire set of trips.
		/// GET: api/Trip
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IActionResult Get();

		/// <summary>
		/// Create a new trip.
		/// POST: api/Trip
		/// </summary>
		/// <param name="tripViewModel">
		/// 
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Modify signature to return action result async.
		/// </remarks>
		Task<IActionResult> Post([FromBody] TripViewModel tripViewModel);

	}

}
