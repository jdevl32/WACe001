using System;
using System.Collections.Generic;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

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
		/// 
		/// </summary>
		/// <remarks>
		/// Parameterless constructor required by Entity Framework.
		/// </remarks>
		public Trip()
		{
		}

		public Trip(string name, DateTime createTimestamp, string userName, ICollection<Stop> stops)
		{
			Name = name;
			CreateTimestamp = createTimestamp;
			UserName = userName;
			Stops = stops;
		}

		public Trip(int id, string name, DateTime createTimestamp, string userName, ICollection<Stop> stops)
			:
			this(name, createTimestamp, userName, stops)
		{
			Id = id;
		}

#endregion

	}

}
