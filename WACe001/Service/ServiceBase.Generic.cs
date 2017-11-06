using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WACe001.Service.Interface;

namespace WACe001.Service
{

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TDerivedClass">
	/// 
	/// </typeparam>
	/// <remarks>
	/// Last modified:
	/// </remarks>
	public abstract class ServiceBase<TDerivedClass>
		:
		IService
		where TDerivedClass : class 
	{

#region Property

		/// <inheritdoc />
		public IConfigurationRoot ConfigurationRoot { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		protected ILogger<TDerivedClass> Logger { get; }

#endregion

#region Instance Initialization

		/// <summary>
		/// 
		/// </summary>
		/// <param name="configurationRoot">
		/// The (injected) configuration root.
		/// </param>
		/// <param name="logger">
		/// The (injected) logger.
		/// </param>
		/// <remarks>
		/// 
		/// </remarks>
		protected ServiceBase(IConfigurationRoot configurationRoot, ILogger<TDerivedClass> logger)
		{
			ConfigurationRoot = configurationRoot;
			Logger = logger;
		}

#endregion

	}

}
