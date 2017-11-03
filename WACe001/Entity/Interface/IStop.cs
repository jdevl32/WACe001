using System;

namespace WACe001.Entity.Interface
{

	public interface IStop
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		int Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		int Order { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// </remarks>
		Coordinate Coordinate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		DateTime Arrival { get; set; }

#endregion

	}

}
