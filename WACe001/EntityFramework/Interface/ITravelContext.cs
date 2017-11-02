using Microsoft.EntityFrameworkCore;
using WACe001.Model.Interface;

namespace WACe001.EntityFramework.Interface
{

	public interface ITravelContext
	{

		DbSet<IStop> Stops { get; }

		DbSet<ITrip> Trips { get; }

	}

}
