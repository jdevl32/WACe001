using System.Collections.Generic;
using WACe001.Entity.Interface;

namespace WACe001.Repository.Interface
{

	public interface ITravelRepository
	{

		IEnumerable<ITrip> GetTrips();

	}

}
