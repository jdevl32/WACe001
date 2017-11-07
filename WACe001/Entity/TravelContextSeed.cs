using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	/// <summary>
	/// The seeder for the travel database context.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Add logger.
	/// </remarks>
	public class TravelContextSeed
		:
		ITravelContextSeed
	{

#region Property

		/// <summary>
		/// The logger for the travel database context.
		/// </summary>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public ILogger<TravelContextSeed> Logger { get; }

		// todo|jdevl32: ??? replace with inteface ???
		/// <inheritdoc />
		public TravelContext TravelContext { get; }

#endregion

#region Instance Initialization

		// todo|jdevl32: ??? replace with inteface ???
		/// <summary>
		/// Create the seeder for the travel database context.
		/// </summary>
		/// <param name="travelContext">
		/// The travel database context.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		public TravelContextSeed(ILogger<TravelContextSeed> logger, TravelContext travelContext)
		{
			Logger = logger;
			TravelContext = travelContext;
		}

#endregion

		/// <inheritdoc />
		public async Task EnsureSeed()
		{
			if (TravelContext.Trip.Any())
			{
				return;
			} // if

			Logger.LogInformation("Seeding the travel database context...");

			var now = DateTime.UtcNow;
			const string tripNames = "AB";
			const string stopNames = "ABCDEF";
			var stop = 0;

			foreach (var tripName in tripNames)
			{
				var entity = new Trip
				(
					$"Seed [{tripName}] Trip"
					,
					now
					,
					// todo|jdevl32: fill username...
					""
					,
					// todo|jdevl32: ??? replace with inteface ???
					new List<Stop>
					{
						new Stop($"Seed [{stopNames[stop++]}] Stop", stop, new Coordinate(5 + 10 * stop, 5 + 10 * stop), now.AddYears(stop - 10))
						,
						new Stop($"Seed [{stopNames[stop++]}] Stop", stop, new Coordinate(5 + 10 * stop, 5 + 10 * stop), now.AddYears(stop - 10))
						,
						new Stop($"Seed [{stopNames[stop++]}] Stop", stop, new Coordinate(5 + 10 * stop, 5 + 10 * stop), now.AddYears(stop - 10))
					}
				);

				TravelContext.Trip.Add(entity);
				TravelContext.Stop.AddRange(entity.Stops);
			} // foreach

			await TravelContext.SaveChangesAsync();
		}

	}

}
