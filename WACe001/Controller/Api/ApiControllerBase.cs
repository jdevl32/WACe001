using Microsoft.AspNetCore.Mvc;
using WACe001.Controller.Api.Interface;
using WACe001.Repository.Interface;

namespace WACe001.Controller.Api
{
	public abstract class ApiControllerBase
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IApiController
	{

#region Property

		protected ITravelRepository TravelRepository { get; }

#endregion

#region Instance Initialization

		protected ApiControllerBase(ITravelRepository travelRepository) => TravelRepository = travelRepository;

#endregion

		public abstract IActionResult Get();

		public abstract string Get(int id);

		public abstract void Post([FromBody]string value);

		public abstract void Put(int id, [FromBody]string value);

		public abstract void Delete(int id);

	}
	
}
