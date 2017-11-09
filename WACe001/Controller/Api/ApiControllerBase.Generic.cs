using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using WACe001.Controller.Api.Interface;
using WACe001.Repository.Interface;

namespace WACe001.Controller.Api
{

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Add identity (authorization).
	/// </remarks>
	[Authorize]
	public abstract class ApiControllerBase<TDerivedClass>
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IApiController
		where TDerivedClass : class
	{

#region Property

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public IHostingEnvironment HostingEnvironment { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ILogger<TDerivedClass> Logger { get; }

		/// <inheritdoc />
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		public ITravelRepository TravelRepository { get; protected set; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hostingEnvironment">
		/// 
		/// </param>
		/// <param name="logger">
		/// 
		/// </param>
		/// <param name="travelRepository">
		/// 
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add logger.
		/// </remarks>
		protected ApiControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, ITravelRepository travelRepository)
		{
			HostingEnvironment = hostingEnvironment;
			Logger = logger;
			TravelRepository = travelRepository;
		}

#endregion

		// todo|jdevl32: not needed ???
#if true
#else
		public abstract IActionResult Get();

		public abstract string Get(int id);

		//public abstract void Post([FromBody]string value);

		public abstract void Put(int id, [FromBody]string value);

		public abstract void Delete(int id);
#endif

	}
}