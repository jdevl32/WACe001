using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WACe001.Repository.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Api
{

	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// 
	/// </remarks>
	[Produces("application/json")]
    [Route("api/trip/{tripName}/stop")]
    public class StopController
		:
		ApiControllerBase<StopController>
    {

#region Instance Initialization

	    /// <inheritdoc />
	    public StopController(IHostingEnvironment hostingEnvironment, ILogger<StopController> logger, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, logger, travelRepository)
		{
		}

#endregion

		// todo|jdevl32: implement ???
#if true
#else
		// GET: api/Stop
		[HttpGet]
		public override IActionResult Get()
		{
			return NoContent();
		}

		// GET: api/Stop/5
		[HttpGet("{id}", Name = "GetStop")]
		public override string Get(int id)
		{
			return null;
		}
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tripName">
		/// 
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		/// <remarks>
		/// Last modification:
		/// Specify order clause.
		/// </remarks>
		[HttpGet(Name = "GetStopsByTripName")]
	    public IActionResult Get(string tripName)
	    {
			try
			{
				return Ok
					(
						Mapper.Map<IEnumerable<StopViewModel>>
						(
							TravelRepository.GetTrip(tripName).Stops.OrderBy(stop => stop.Order).ToList()
						)
					);
			} // try
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error retrieving stops:  {ex}");
			} // catch

		    return BadRequest();
	    }

		// POST: api/Stop
		[HttpPost]
        public void Post([FromBody]string value)
        {
			// todo|jdevl32: implement...
        }
        
        // PUT: api/Stop/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }

}
