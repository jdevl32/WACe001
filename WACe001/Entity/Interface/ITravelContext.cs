using Microsoft.EntityFrameworkCore;

namespace WACe001.Entity.Interface
{

	public interface ITravelContext
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// </remarks>
		DbSet<Stop> Stops { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// </remarks>
		DbSet<Trip> Trips { get; }

#endregion

	}

}
