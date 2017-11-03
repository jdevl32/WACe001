using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WACe001.Model.Interface;

namespace WACe001.EntityFramework.Interface
{

	public interface ITravelContext
	{

#region Property

		DbSet<IStop> Stops { get; }

		DbSet<ITrip> Trips { get; }

#endregion

	}

}
