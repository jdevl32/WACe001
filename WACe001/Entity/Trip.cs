using System;
using System.Collections.Generic;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	/// <summary>
	/// A trip (to be logged as travel).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add object to-string override.
	/// </remarks>
	public class Trip
		:
		ITrip
	{

#region Property

		/// <inheritdoc />
		public int Id { get; set; }

		/// <inheritdoc />
		public string Name { get; set; }

		/// <inheritdoc />
		public DateTime CreateTimestamp { get; set; }

		/// <inheritdoc />
		public string UserName { get; set; }

		/// <inheritdoc />
		public ICollection<Stop> Stops { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a new (empty) trip.
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Trip()
		{
		}

		/// <summary>
		/// Create a new trip.
		/// </summary>
		/// <param name="name">
		/// The name of the trip.
		/// </param>
		/// <remarks>
		/// Simple constructor (mainly for testing).
		/// </remarks>
		public Trip(string name)
		{
			Name = name;
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a new trip.
		/// </summary>
		/// <param name="name">
		/// The name of the trip.
		/// </param>
		/// <param name="createTimestamp">
		/// The creation timestamp of the trip.
		/// </param>
		/// <param name="userName">
		/// The name of the user associated with the trip.
		/// </param>
		/// <param name="stops">
		/// The stops of the trip.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Trip(string name, DateTime createTimestamp, string userName, ICollection<Stop> stops)
			:
			this(name)
		{
			CreateTimestamp = createTimestamp;
			UserName = userName;
			Stops = stops;
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a new trip.
		/// </summary>
		/// <param name="id">
		/// The unique id of the trip.
		/// </param>
		/// <param name="name">
		/// The name of the trip.
		/// </param>
		/// <param name="createTimestamp">
		/// The creation timestamp of the trip.
		/// </param>
		/// <param name="userName">
		/// The name of the user associated with the trip.
		/// </param>
		/// <param name="stops">
		/// The stops of the trip.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Trip(int id, string name, DateTime createTimestamp, string userName, ICollection<Stop> stops)
			:
			this(name, createTimestamp, userName, stops)
		{
			Id = id;
		}

#endregion

#region Object

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Verify valid stops.
		/// </remarks>
		public override string ToString()
		{
			var stopCount = string.Empty;

			if (null != Stops)
			{
				stopCount = $"|{nameof(Stops)}.{nameof(Stops.Count)}={Stops.Count}";
			} // if

			return $"[{nameof(Id)}={Id}|{nameof(Name)}={Name}|{nameof(CreateTimestamp)}={CreateTimestamp}|{nameof(UserName)}={UserName}{stopCount}]";
		}

		#endregion

	}

}
