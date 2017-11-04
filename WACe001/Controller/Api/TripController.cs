using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WACe001.Repository.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Api
{

    [Produces("application/json")]
    [Route("api/Trip")]
    public class TripController
		:
		ApiControllerBase
    {

#region Instance Initialization

		/// <inheritdoc />
		public TripController(IHostingEnvironment hostingEnvironment, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, travelRepository)
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
	    /// <param name="tripViewModel">
	    /// 
	    /// </param>
	    /// <returns>
	    /// 
	    /// </returns>
	    /// <remarks>
	    /// Last modification:
	    /// Verify model state.
	    /// Change trip parameter type from entity to view model.
	    /// </remarks>
	    [HttpPost]
        public IActionResult Post([FromBody] TripViewModel tripViewModel)
		{
			if (ModelState.IsValid)
			{
				// todo|jdevl32: contant(s)...
				return Created($"/api/trip/{tripViewModel.Name}", tripViewModel);
			} // if

			if (HostingEnvironment.IsDevelopment())
			{
				return BadRequest(ModelState);
			} // if

			return BadRequest();
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
