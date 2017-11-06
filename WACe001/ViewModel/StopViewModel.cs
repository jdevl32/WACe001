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
		[Required]
		[StringLength(100, MinimumLength = 1)]
		public string Name { get; }

		/// <inheritdoc />
		[Required]
		public int Order { get; }

		/// <inheritdoc />
		public ICoordinate Coordinate { get; }

		/// <inheritdoc />
		[Required]
		public DateTime Arrival { get; }

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
		/// <param name="coordinate">
		/// 
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		public StopViewModel(string name, int order, DateTime arrival, ICoordinate coordinate)
			:
			this(name, order, arrival) => Coordinate = coordinate;

#endregion

	}

}
