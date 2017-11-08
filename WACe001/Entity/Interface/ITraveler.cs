using System;

namespace WACe001.Entity.Interface
{

	/// <summary>
	/// The traveler (identity user).
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface ITraveler
	{

#region Property

		/// <summary>
		/// The timestamp of the traveler's first trip.
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// Last modification:
		/// </remarks>
		DateTime FirstTrip { get; set; }

#endregion

	}

}
