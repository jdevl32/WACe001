using System;
using System.ComponentModel.DataAnnotations;
using WACe001.ViewModel.Interface;

namespace WACe001.ViewModel
{

	public class TripViewModel
		:
		ITripViewModel
	{

#region Property

		[Required]
		[StringLength(100, MinimumLength = 1)]
		public string Name { get; }

		public DateTime CreateTimestamp { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public TripViewModel()
		{
			CreateTimestamp = DateTime.UtcNow;
		}

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
		public TripViewModel(string name)
			:
			this()
		{
			Name = name;
		}

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
			this(name)
		{
			CreateTimestamp = createTimestamp;
		}

#endregion

	}

}
