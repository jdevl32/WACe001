﻿using Microsoft.EntityFrameworkCore;
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

		private ILogger<ITravelRepository> Logger { get; }

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
		public TravelRepository(ILogger<ITravelRepository>logger, TravelContext travelContext)
		{
			Logger = logger;
			TravelContext = travelContext;
		}

#endregion

		/// <inheritdoc />
		public bool AddStop(string tripName, Stop stop)
		{
			var trip = GetTrip(tripName);

			if (null == trip)
			{
				return false;
			} // if

			// todo|jdevl32: additional logic to (correctly) assign stop order ???

			// add the stop to trip (create foreign key)
			trip.Stops.Add(stop);

			// add the stop (itself)
			TravelContext.Stops.Add(stop);

			return true;
		}

		/// <inheritdoc />
		public void AddTrip(Trip trip) => TravelContext.Trips.Add(trip);

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public ITrip GetTrip(string name)
		{
			Logger.LogInformation($"Get trip [{name}] from travel context...");

			// todo|jdevl32: replace with procedure implemented by context ???
			return TravelContext.Trips.Include(trip => trip.Stops).FirstOrDefault(trip => trip.Name.Equals(name));
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Implement logging.
		/// </remarks>
	    public IEnumerable<ITrip> GetTrips()
		{
			Logger.LogInformation("Get trips from travel context...");

			return TravelContext.Trips.ToList();
		}

		/// <inheritdoc />
		public async Task<bool> SaveChangesAsync() => await TravelContext.SaveChangesAsync() > 0;

	}

}
