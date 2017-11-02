using System;
using WACe001.Model.Interface;

namespace WACe001.Model
{

    public class Stop
		:
		IStop
    {

		public int Id { get; }

		public string Name { get; }

		public int Order { get; }

		public ICoordinate Coordinate { get; }

		public DateTime Arrival { get; }

	}

}
