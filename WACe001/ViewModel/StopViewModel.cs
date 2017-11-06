using System;
using System.ComponentModel.DataAnnotations;
using WACe001.Entity.Interface;
using WACe001.ViewModel.Interface;

namespace WACe001.ViewModel
{

	public class StopViewModel
		:
		IStopViewModel
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
		[Required]
		public int Order { get; set; }

		/// <inheritdoc />
		public ICoordinate Coordinate { get; }

		/// <inheritdoc />
		/// <remarks>
		/// Setter is required.
		/// Last modified:
		/// Implement setter.
		/// </remarks>
		[Required]
		public DateTime Arrival { get; set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public StopViewModel()
		{
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
		public StopViewModel(string name) : this() => Name = name;

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name">
		/// 
		/// </param>
		/// <param name="order">
		/// 
		/// </param>
		/// <param name="arrival">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public StopViewModel(string name, int order, DateTime arrival)
			:
			this(name)
		{
			Order = order;
			Arrival = arrival;
		}

		/// <inheritdoc />
		/// <summary>
		/// Create a stop view model using all available properties.
		/// </summary>
		/// <param name="name">
		/// The name of the stop.
		/// </param>
		/// <param name="order">
		/// The order in which the stop was made (relavant to all other stops).
		/// </param>
		/// <param name="arrival">
		/// The arrival timestamp of the stop.
		/// </param>
		/// <param name="coordinate">
		/// The coordinates of the stop.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public StopViewModel(string name, int order, DateTime arrival, ICoordinate coordinate)
			:
			this(name, order, arrival) => Coordinate = coordinate;

#endregion

	}

}
