using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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

		private ITravelContext TravelContext { get; }

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
		public TravelRepository(ILogger<ITravelRepository>logger, ITravelContext travelContext)
		{
			Logger = logger;
			TravelContext = travelContext;
		}

#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Implement logging.
		/// </remarks>
	    public IEnumerable<ITrip> GetTrips()
		{
			Logger.LogInformation("Get trips from travel context...");

			return TravelContext.Trips.ToList();
		}

	}

}
