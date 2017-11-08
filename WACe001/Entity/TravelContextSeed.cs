using Microsoft.AspNetCore.Identity;
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
	/// Add (traveler) user manager.
	/// Add seeding of traveler.
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

		/// <inheritdoc />
		public UserManager<Traveler> UserManager { get; }

#endregion

#region Instance Initialization

		// todo|jdevl32: ??? replace with inteface ???
		/// <summary>
		/// Create the seeder for the travel database context.
		/// </summary>
		/// <param name="logger">
		/// The logger for the travel database context.
		/// </param>
		/// <param name="travelContext">
		/// The travel database context.
		/// </param>
		/// <param name="userManager">
		/// The (traveler) user manager.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add the (traveler) user manager.
		/// </remarks>
		public TravelContextSeed(ILogger<TravelContextSeed> logger, TravelContext travelContext, UserManager<Traveler> userManager)
		{
			Logger = logger;
			TravelContext = travelContext;
			UserManager = userManager;
		}

#endregion

		/// <inheritdoc />
		/// <remarks>
		/// Implement seeding of traveler.
		/// </remarks>
		public async Task Seed()
		{
			Logger.LogInformation("Seed the travel database context...");

			const string userName = "tbone";

			await SeedTraveler(userName);
			await SeedTrip(userName);
		}

		/// <summary>
		/// Seed the traveler by username.
		/// </summary>
		/// <param name="userName">
		/// The username of the traveler.
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		private async Task SeedTraveler(string userName)
		{
			var email = $"{userName}@seinfeld.tv";

			Logger.LogInformation($"Seed traveler \"{userName}\" ({email})...");

			if (null == await UserManager.FindByEmailAsync(email))
			{
				await UserManager.CreateAsync(new Traveler {Email = email, UserName = userName}, "7L.Costanza");
			} // if
		}

		/// <summary>
		/// Seed trips and stops for traveler by username.
		/// </summary>
		/// <param name="userName">
		/// The username of the traveler.
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		private async Task SeedTrip(string userName)
		{
			Logger.LogInformation($"Seed trips (and stops) for traveler \"{userName}\"...");

			if (TravelContext.Trip.Any())
			{
				return;
			} // if

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
					userName
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
