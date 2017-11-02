using Microsoft.EntityFrameworkCore;
using WACe001.EntityFramework.Interface;
using WACe001.Model.Interface;

namespace WACe001.EntityFramework
{

    public class TravelContext
		:
		DbContext
		,
		ITravelContext
    {

		public DbSet<IStop> Stops { get; }

		public DbSet<ITrip> Trips { get; }

	}

}
