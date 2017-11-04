using Microsoft.AspNetCore.Mvc;
using WACe001.Entity;
using WACe001.Entity.Interface;
using WACe001.Repository.Interface;

namespace WACe001.Controller.Api
{

    [Produces("application/json")]
    [Route("api/Trip")]
    public class TripController
		:
		ApiControllerBase
    {

#region Instance Initialization

		public TripController(ITravelRepository travelRepository)
			:
			base(travelRepository)
		{
		}

#endregion

		/// <summary>
		/// Get the entire set of trips.
		/// GET: api/Trip
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Implement travel repository as data provider.
		/// </remarks>
		[HttpGet]
        public override IActionResult Get() => Ok(TravelRepository.GetTrips());

	    // GET: api/Trip/5
        [HttpGet("{id}", Name = "GetTrip")]
        public override string Get(int id)
        {
            return "value";
        }
        
		/// <summary>
		/// Create a new trip.
		/// POST: api/Trip
		/// </summary>
		/// <param name="trip">
		/// 
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// </remarks>
        [HttpPost]
        public IActionResult Post([FromBody]Trip trip)
		{
			return Ok(true);
		}
        
        // PUT: api/Trip/5
        [HttpPut("{id}")]
        public override void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public override void Delete(int id)
        {
        }

    }

}
