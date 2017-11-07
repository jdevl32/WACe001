using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.Entity.Interface;
using WACe001.Repository.Interface;

namespace WACe001.Repository
{

	public class TravelRepository
		:
		ITravelRepository
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Change from private to public.
		/// Change generic type from interface to implementation (of travel repository).
		/// </remarks>
		public ILogger<TravelRepository> Logger { get; }

		/// <summary>
		/// The travel database context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		private TravelContext TravelContext { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger">
		/// 
		/// </param>
		/// <param name="travelContext">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add logger.
		/// </remarks>
		public TravelRepository(ILogger<TravelRepository>logger, TravelContext travelContext)
		{
			Logger = logger;
			TravelContext = travelContext;
		}

#endregion

		public bool AddUniqueCoordinate(Coordinate coordinate)
		{
			Logger.LogInformation($"Add unique coordinate ({coordinate}) to travel context...");

			if (null != TravelContext.Coordinate.Find(coordinate.Latitude, coordinate.Longitude))
			{
				return false;
			} // if

			TravelContext.Coordinate.Add(coordinate);
			return true;
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Implement addition of coordinates.
		/// Add logging message.
		/// </remarks>
		public bool AddStop(string tripName, Stop stop)
		{
			Logger.LogInformation($"Add stop ({stop}) to trip \"{tripName}\" of travel context...");

			var trip = GetTrip(tripName);

			if (null == trip)
			{
				return false;
			} // if

			// todo|jdevl32: additional logic to (correctly) assign stop order ???

			// Add the stop to the trip (create foreign key).
			trip.Stops.Add(stop);

			// todo|jdevl32: cleanup...
			//{
			//	if (null != stop.Coordinate)
			//	{
			//		// Add the coordinate (itself).
			//		TravelContext.Coordinate.Add(stop.Coordinate);
			//	} // if
			//}

			// Add the stop (itself).
			TravelContext.Stop.Add(stop);

			return true;
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Add logging message.
		/// </remarks>
		public void AddTrip(Trip trip)
		{
			Logger.LogInformation($"Add trip ({trip}) to travel context...");

			TravelContext.Trip.Add(trip);
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Include the stop coordinates.
		/// </remarks>
		public ITrip GetTrip(string name)
		{
			Logger.LogInformation($"Get trip \"{name}\" from travel context...");

			// todo|jdevl32: replace with procedure implemented by context ???
			return TravelContext.Trip
				// Include the stops for each trip.
				.Include(trip => trip.Stops)
				// Include the coordinate for each stop.
				.ThenInclude(stop => stop.Coordinate)
				// Where the trip name matches the input.
				.FirstOrDefault(trip => trip.Name.Equals(name));
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Implement logging.
		/// </remarks>
	    public IEnumerable<ITrip> GetTrips()
		{
			Logger.LogInformation("Get trips from travel context...");

			return TravelContext.Trip.ToList();
		}

		/// <inheritdoc />
		public async Task<bool> SaveChangesAsync() => await TravelContext.SaveChangesAsync() > 0;

	}

}
