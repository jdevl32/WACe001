using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using WACe001.Controller.Interface;
using WACe001.Repository.Interface;

namespace WACe001.Controller
{

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// This should be the type of the derived class from this base class (for the logger).
	/// </typeparam>
	/// <remarks>
	/// Last modification:
	/// Refactor (rename, move and rebase).
	/// </remarks>
	public abstract class ControllerBase<TDerivedClass>
		:
		Microsoft.AspNetCore.Mvc.Controller
		,
		IBaseController
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
		public IHostingEnvironment HostingEnvironment { get; }

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
		public ITravelRepository TravelRepository { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected ControllerBase(ILogger<TDerivedClass> logger) => Logger = logger;

		/// <inheritdoc />
		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="travelRepository">
		/// The travel repository.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// </remarks>
		protected ControllerBase(ILogger<TDerivedClass> logger, ITravelRepository travelRepository)
			:
			this(logger) => TravelRepository = travelRepository;

		/// <inheritdoc />
		/// <summary>
		/// Create a controller base.
		/// </summary>
		/// <param name="hostingEnvironment">
		/// The hosting environment.
		/// </param>
		/// <param name="logger">
		/// The logger.
		/// </param>
		/// <param name="travelRepository">
		/// The travel repository.
		/// </param>
		/// <remarks>
		/// Last modification:
		/// Add logger.
		/// </remarks>
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILogger<TDerivedClass> logger, ITravelRepository travelRepository)
			:
			this(logger, travelRepository) => HostingEnvironment = hostingEnvironment;

#endregion

	}
}