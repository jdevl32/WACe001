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
		/// Add logger.
		/// </remarks>
		public TravelRepository(ILogger<ITravelRepository>logger, TravelContext travelContext)
		{
			Logger = logger;
			TravelContext = travelContext;
		}

#endregion

		/// <inheritdoc />
		public void AddTrip(Trip trip) => TravelContext.Trips.Add(trip);

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
