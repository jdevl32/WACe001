using Microsoft.AspNetCore.Hosting;
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

		protected IHostingEnvironment HostingEnvironment { get; }

		protected ITravelRepository TravelRepository { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hostingEnvironment">
		/// 
		/// </param>
		/// <param name="travelRepository">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add hosting environment.
		/// </remarks>
		protected ApiControllerBase(IHostingEnvironment hostingEnvironment, ITravelRepository travelRepository)
		{
			HostingEnvironment = hostingEnvironment;
			TravelRepository = travelRepository;
		}

#endregion

		public abstract IActionResult Get();

		public abstract string Get(int id);

		// todo|jdevl32: probably not needed...
		//public abstract void Post([FromBody]string value);

		public abstract void Put(int id, [FromBody]string value);

		public abstract void Delete(int id);

	}
	
}
