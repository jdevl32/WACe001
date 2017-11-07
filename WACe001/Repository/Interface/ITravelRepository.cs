using System.Collections.Generic;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.Entity.Interface;

namespace WACe001.Repository.Interface
{

	public interface ITravelRepository
	{

		/// <summary>
		/// Add the stop (to the trip) by trip name.
		/// </summary>
		/// <param name="tripName">
		/// The name of the trip.
		/// </param>
		/// <param name="stop">
		/// The stop (for the trip).
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		bool AddStop(string tripName, Stop stop);

		/// <summary>
		/// Add the trip.
		/// </summary>
		/// <param name="trip">
		/// The trip.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		void AddTrip(Trip trip);

		bool AddUniqueCoordinate(Coordinate coordinate);

		/// <summary>
		/// Get the trip by name.
		/// </summary>
		/// <param name="name">
		/// The name of the trip.
		/// </param>
		/// <returns>
		/// The trip.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		ITrip GetTrip(string name);

		/// <summary>
		/// Get the set of trips.
		/// </summary>
		/// <returns>
		/// The set of trips.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<ITrip> GetTrips();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// 
		/// </remarks>
		Task<bool> SaveChangesAsync();

	}

}
