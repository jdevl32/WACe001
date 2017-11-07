using System;
using System.ComponentModel.DataAnnotations;
using WACe001.ViewModel.Interface;

namespace WACe001.ViewModel
{

	/// <inheritdoc />
	/// <remarks>
	/// Last modification:
	/// Add object to-string override.
	/// </remarks>
	public class TripViewModel
		:
		ITripViewModel
	{

#region Property

		/// <inheritdoc />
		/// <remarks>
		/// Setter is required.
		/// Last modified:
		/// Implement setter.
		/// </remarks>
		[Required]
		[StringLength(100, MinimumLength = 1)]
		public string Name { get; set; }

		/// <inheritdoc />
		/// <remarks>
		/// Setter is required.
		/// Last modified:
		/// Implement setter.
		/// </remarks>
		public DateTime CreateTimestamp { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public TripViewModel() => CreateTimestamp = DateTime.UtcNow;

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public TripViewModel(string name):this() => Name = name;

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name">
		/// 
		/// </param>
		/// <param name="createTimestamp">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public TripViewModel(string name, DateTime createTimestamp)
			:
			this(name) => CreateTimestamp = createTimestamp;

#endregion

#region Object

		/// <inheritdoc />
		public override string ToString() => $"[{nameof(Name)}={Name}|{nameof(CreateTimestamp)}={CreateTimestamp}]";

#endregion

	}

}
