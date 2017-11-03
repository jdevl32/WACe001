using System;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

    public class Stop
		:
		IStop
    {

#region Property

		/// <inheritdoc />
		public int Id { get; set; }

		/// <inheritdoc />
		public string Name { get; set; }

		/// <inheritdoc />
		public int Order { get; set; }

		/// <inheritdoc />
		public Coordinate Coordinate { get; set; }

		/// <inheritdoc />
		public DateTime Arrival { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Stop()
		{
		}

		public Stop(int id, string name, int order, Coordinate coordinate, DateTime arrival)
		{
			Id = id;
			Name = name;
			Order = order;
			Coordinate = coordinate;
			Arrival = arrival;
		}

#endregion

	}

}
