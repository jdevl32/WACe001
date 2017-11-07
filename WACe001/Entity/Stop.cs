using System;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	/// <summary>
	/// A stop (of a trip).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add object to-string override.
	/// </remarks>
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
		/// Create a new (empty) stop.
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Stop()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a new stop.
		/// </summary>
		/// <param name="name">
		/// The name of the stop.
		/// </param>
		/// <param name="order">
		/// The order in which the stop was made (in relation to the other stops of the trip).
		/// </param>
		/// <param name="coordinate">
		/// The coordinates of the stop location.
		/// </param>
		/// <param name="arrival">
		/// The arrival timestamp of the stop.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Stop(string name, int order, Coordinate coordinate, DateTime arrival)
			:
			this()
		{
			Name = name;
			Order = order;
			Coordinate = coordinate;
			Arrival = arrival;
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a new stop.
		/// </summary>
		/// <param name="id">
		/// The unique id of the stop.
		/// </param>
		/// <param name="name">
		/// The name of the stop.
		/// </param>
		/// <param name="order">
		/// The order in which the stop was made (in relation to the other stops of the trip).
		/// </param>
		/// <param name="coordinate">
		/// The coordinates of the stop location.
		/// </param>
		/// <param name="arrival">
		/// The arrival timestamp of the stop.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Stop(int id, string name, int order, Coordinate coordinate, DateTime arrival)
			:
			this(name, order, coordinate, arrival)
		{
			Id = id;
		}

#endregion

#region Object

		/// <inheritdoc />
		public override string ToString() => $"[{nameof(Id)}={Id}|{nameof(Name)}={Name}|{nameof(Order)}={Order}|{nameof(Coordinate)}={Coordinate}|{nameof(Arrival)}={Arrival}]";

#endregion

	}

}
