using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using WACe001.Repository.Interface;

namespace WACe001.Controller
{

	/// <inheritdoc />
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Refactor (rename, move and rebase).
	/// </remarks>
	public abstract class ControllerBase
		:
		ControllerBase<ControllerBase>
	{

#region Instance Initialization

		/// <inheritdoc />
		protected ControllerBase(IHostingEnvironment hostingEnvironment, ILogger<ControllerBase> logger, ITravelRepository travelRepository)
			:
			base(hostingEnvironment, logger, travelRepository)
		{
		}

#endregion

	}

}
