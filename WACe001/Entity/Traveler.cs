using Microsoft.AspNetCore.Identity;
using System;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	public class Traveler
		:
		IdentityUser
		,
		ITraveler
	{

#region Property

		/// <inheritdoc />
		public DateTime FirstTrip { get; set; }

#endregion

#region Instance Initialization

		/// <inheritdoc />
		/// <summary>
		/// Create an empty traveler.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Traveler()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a traveler.
		/// </summary>
		/// <param name="firstTrip">
		/// The timestamp of the traveler's first trip.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public Traveler(DateTime firstTrip)
			:
			this() => FirstTrip = firstTrip;

#endregion

	}

}
