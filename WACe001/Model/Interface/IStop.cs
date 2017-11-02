using System;

namespace WACe001.Model.Interface
{

	public interface IStop
	{

		int Id { get; }

		string Name { get; }

		int Order { get; }

		ICoordinate Coordinate { get; }

		DateTime Arrival { get; }

	}

}
