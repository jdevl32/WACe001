using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WACe001.Entity.Interface
{

	/// <summary>
	/// The travel database context seeder.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add user manager (of traveler).
	/// </remarks>
	public interface ITravelContextSeed
	{

#region Property

		/// <summary>
		/// The travel database context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// Re-declare in interface.
		/// </remarks>
		TravelContext TravelContext { get; }

		/// <summary>
		/// The (traveler) user manager.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		UserManager<Traveler> UserManager { get; }

#endregion

		/// <summary>
		/// Seed the database.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Rename.
		/// </remarks>
		Task Seed();

	}

}
