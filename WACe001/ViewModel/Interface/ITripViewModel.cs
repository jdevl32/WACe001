using System;

namespace WACe001.ViewModel.Interface
{

	/// <summary>
	/// The view model for trips.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// </remarks>
	public interface ITripViewModel
	{

#region Property

		/// <summary>
		/// The name of the trip.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		string Name { get; }

		/// <summary>
		/// The creation timestamp of the trip.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		DateTime CreateTimestamp { get; }

#endregion

	}

}
