using System;
using System.Collections.Generic;

namespace WACe001.Model.Interface
{

	public interface ITrip
	{

		int Id { get; }

		string Name { get; }

		DateTime CreateTimestamp { get; }

		string UserName { get; }

		ICollection<IStop> Stops { get; }

	}

}
