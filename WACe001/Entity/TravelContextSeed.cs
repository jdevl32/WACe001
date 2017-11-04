using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACe001.Entity.Interface;

namespace WACe001.Entity
{

	public class TravelContextSeed
		:
		ITravelContextSeed
	{

#region Property

		// todo|jdevl32: ??? replace with inteface ???
		private TravelContext TravelContext { get; }

#endregion

#region Instance Initialization

		// todo|jdevl32: ??? replace with inteface ???
		public TravelContextSeed(TravelContext travelContext) => TravelContext = travelContext;

#endregion

		public async Task EnsureSeed()
	    {
		    if (!TravelContext.Trips.Any())
		    {
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

					TravelContext.Trips.Add(entity);
					TravelContext.Stops.AddRange(entity.Stops);
			    } // foreach

			    await TravelContext.SaveChangesAsync();
		    } // if
	    }

    }

}
