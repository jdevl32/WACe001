using System.Collections.Generic;
using System.Threading.Tasks;
using WACe001.Entity;
using WACe001.Entity.Interface;

namespace WACe001.Repository.Interface
{

	public interface ITravelRepository
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="trip">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		void AddTrip(Trip trip);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// 
		/// </remarks>
		ITrip GetTrip(string name);

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// 
		/// </remarks>
		IEnumerable<ITrip> GetTrips();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// 
		/// </remarks>
		Task<bool> SaveChangesAsync();

	}

}
