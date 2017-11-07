﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WACe001.Entity.Interface
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add database set for coordinates.
	/// </remarks>
	public interface ITravelContext
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// Last modification:
		/// </remarks>
		IConfigurationRoot ConfigurationRoot { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// Last modification:
		/// Rename.
		/// </remarks>
		DbSet<Coordinate> Coordinate { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// Last modification:
		/// Rename.
		/// </remarks>
		DbSet<Stop> Stop { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Can't use interface(s) -- Entity Framework migrations must be reference types.
		/// Last modification:
		/// Rename.
		/// </remarks>
		DbSet<Trip> Trip { get; }

#endregion

	}

}
