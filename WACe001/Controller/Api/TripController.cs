﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
	/// Re-implement with generic base class.
	/// </remarks>
	[Produces("application/json")]
    [Route("api/trip")]
    public class TripController
		:
		ApiControllerBase<TripController>
    {

#region Instance Initialization

		/// <inheritdoc />
		public TripController(IHostingEnvironment hostingEnvironment, ILogger<TripController> logger, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, logger, travelRepository)
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
		/// Remove obsolete override.
		/// </remarks>
		[HttpGet]
        public IActionResult Get()
	    {
			try
			{
				return Ok(Mapper.Map<IEnumerable<TripViewModel>>(TravelRepository.GetTrips()));
			}
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error retrieving trips:  {ex}");
			}

		    return BadRequest();
	    }

		// GET: api/Trip/5
		[HttpGet("{id}", Name = "GetTrip")]
        public string Get(int id)
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
	    /// Modify signature to return async task.
	    /// </remarks>
	    [HttpPost]
        public async Task<IActionResult> Post([FromBody] TripViewModel tripViewModel)
		{
			if (ModelState.IsValid)
			{
				var trip = Mapper.Map<Trip>(tripViewModel);

				TravelRepository.AddTrip(trip);

				if (await TravelRepository.SaveChangesAsync())
				{
					// todo|jdevl32: contant(s)...
					// Use map in case database modified the trip in any way.
					var value = Mapper.Map<TripViewModel>(trip);

					return Created($"/api/trip/{value.Name}", value);
				} // if
			} // if
			else if (HostingEnvironment.IsDevelopment())
			{
				return BadRequest(ModelState);
			} // if

			return BadRequest();
		}
        
        // PUT: api/Trip/5
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
