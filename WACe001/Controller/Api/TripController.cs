using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WACe001.Entity;
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
        
        // POST: api/Trip
        [HttpPost]
        public override void Post([FromBody]string value)
        {
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
