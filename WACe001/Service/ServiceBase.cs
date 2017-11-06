using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WACe001.Service
{

	public abstract class ServiceBase
		:
		ServiceBase<ServiceBase>
	{

#region Instance Initialization

		/// <inheritdoc />
		protected ServiceBase(IConfigurationRoot configurationRoot, ILogger<ServiceBase> logger)
			:
			base(configurationRoot, logger)
		{
		}

#endregion

	}

}
