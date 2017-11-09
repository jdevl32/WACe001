using System.Collections.Generic;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.Entity.Interface;

namespace WACe001.Repository.Interface
{

	/// <summary>
	/// The travel repository.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Implement get trips by (traveler) username.
	/// </remarks>
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
		/// Get the set of trips by (traveler) username.
		/// </summary>
		/// <returns>
		/// The set of trips for the traveler.
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		IEnumerable<ITrip> GetTrips(string userName);

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
