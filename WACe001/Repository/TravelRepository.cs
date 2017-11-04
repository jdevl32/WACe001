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

		private ITravelContext TravelContext { get; }

#endregion

#region Instance Initialization

		public TravelRepository(ITravelContext travelContext)
		{
			TravelContext = travelContext;
		}

#endregion

	    public IEnumerable<ITrip> GetTrips() => TravelContext.Trips.ToList();

    }

}
