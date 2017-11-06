using System;
using WACe001.Entity.Interface;

namespace WACe001.ViewModel.Interface
{
	public interface IStopViewModel
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		string Name { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		int Order { get; }

		// todo|jdevl32: interface or not ???
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Don't use interface(s) -- Entity Framework migrations must be reference types.
		/// </remarks>
		ICoordinate Coordinate { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		DateTime Arrival { get; }

#endregion

	}
}