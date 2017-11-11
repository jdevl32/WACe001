using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WACe001.Controller.Api.Interface;
using WACe001.Entity;
using WACe001.Repository.Interface;
using WACe001.ViewModel;

namespace WACe001.Controller.Api
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Refactor authorization (from base class).
	/// </remarks>
	[Authorize]
	[Produces("application/json")]
	[Route("api/trip")]
	public class TripController
		:
		ControllerBase<TripController>
		,
		ITripController
	{

#region Instance Initialization

		/// <inheritdoc />
		public TripController(IHostingEnvironment hostingEnvironment, ILogger<TripController> logger, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, logger, travelRepository)
		{
		}

#endregion

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Restrict trips by traveler (authenticated username).
		/// </remarks>
		[HttpGet]
		public IActionResult Get()
		{
			var userName = User.Identity.Name;

			try
			{
				return Ok(Mapper.Map<IEnumerable<TripViewModel>>(TravelRepository.GetTrips(userName)));
			}
			catch (Exception ex)
			{
				Logger.LogError(ex, $"Error retrieving trips by traveler (username) \"{userName}\":  {ex}");
			}

			return BadRequest();
		}

		// GET: api/Trip/5
		[HttpGet("{id}", Name = "GetTrip")]
		public string Get(int id)
		{
			return "value";
		}

		/// <inheritdoc />
		/// <remarks>
		/// Last modification:
		/// Incorporate traveler (authenticated username) for the trip.
		/// </remarks>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TripViewModel tripViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var trip = Mapper.Map<Trip>(tripViewModel);
					trip.UserName = User.Identity.Name;

					TravelRepository.AddTrip(trip);

					if (await TravelRepository.SaveChangesAsync())
					{
						// Use map in case database modified the trip in any way.
						var value = Mapper.Map<TripViewModel>(trip);

						// todo|jdevl32: contant(s)...
						return Created($"/api/trip/{value.Name}", value);
					} // if
				} // if
				else if (HostingEnvironment.IsDevelopment())
				{
					return BadRequest(ModelState);
				} // if
			} // try
			catch (Exception ex)
			{
				Logger.LogError($"Error adding trip ({tripViewModel}):  {ex}");
			} // catch

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
