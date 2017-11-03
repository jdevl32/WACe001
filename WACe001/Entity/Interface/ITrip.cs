using System;
using System.Collections.Generic;

namespace WACe001.Entity.Interface
{

	public interface ITrip
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
		DateTime CreateTimestamp { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// </remarks>
		string UserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Must provide a setter -- needed for Entiry Framework.
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// </remarks>
		ICollection<Stop> Stops { get; set; }

#endregion

	}

}
