using System;
using System.Collections.Generic;
using WACe001.Model.Interface;

namespace WACe001.Model
{

    public class Trip
		:
		ITrip
    {

		public int Id { get; }

		public string Name { get; }

		public DateTime CreateTimestamp { get; }

		public string UserName { get; }

		public ICollection<IStop> Stops { get; }

	}

}
