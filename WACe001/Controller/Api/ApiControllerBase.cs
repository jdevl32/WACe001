﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using WACe001.Repository.Interface;

namespace WACe001.Controller.Api
{

	// todo|jdevl32: cleanup !!!
#if true
	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Re-implement as derived from generic base class.
	/// </remarks>
	public abstract class ApiControllerBase
		:
		ApiControllerBase<ApiControllerBase>
	{

		/// <inheritdoc />
		protected ApiControllerBase(IHostingEnvironment hostingEnvironment, ILogger<ApiControllerBase> logger, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, logger, travelRepository)
		{
		}

	}
#else
	public abstract class ApiControllerBase
:
Microsoft.AspNetCore.Mvc.Controller
,
IApiController
	{

	#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected IHostingEnvironment HostingEnvironment { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ILogger<IApiController> Logger { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ITravelRepository TravelRepository { get; }

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
		protected ApiControllerBase(IHostingEnvironment hostingEnvironment, ILogger<IApiController> logger, ITravelRepository travelRepository)
		{
			HostingEnvironment = hostingEnvironment;
			Logger = logger;
			TravelRepository = travelRepository;
		}

	#endregion

		public abstract IActionResult Get();

		public abstract string Get(int id);

		//public abstract void Post([FromBody]string value);

		public abstract void Put(int id, [FromBody]string value);

		public abstract void Delete(int id);

	}
#endif

}
