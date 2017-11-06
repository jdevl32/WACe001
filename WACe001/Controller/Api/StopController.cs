using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACe001.Entity;
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
		/// Get stops by trip name.
		/// </summary>
		/// <param name="tripName">
		/// The name of the trip.
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

		/// <summary>
		/// Create a new stop (for a trip) by trip name.
		/// POST: api/trip/{tripName}/stop
		/// </summary>
		/// <param name="tripName">
		/// 
		/// </param>
		/// <param name="stopViewModel">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		[HttpPost]
        public async Task<IActionResult> Post(string tripName, [FromBody]StopViewModel stopViewModel)
		{
			if (ModelState.IsValid)
			{
				var stop = Mapper.Map<Stop>(stopViewModel);

				// todo|jdevl32: implement geo-location service (for stop coordinates) !!!

				TravelRepository.AddStop(tripName, stop);

				if (await TravelRepository.SaveChangesAsync())
				{
					// Use map in case database modified the stop in any way.
					var value = Mapper.Map<StopViewModel>(stop);

					// todo|jdevl32: contant(s)...
					return Created($"/api/trip/{tripName}/stop/{value.Name}", value);
				} // if
			} // if
			else if (HostingEnvironment.IsDevelopment())
			{
				return BadRequest(stopViewModel);
			} // else if

			return BadRequest();
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
