using Microsoft.Extensions.Configuration;

namespace WACe001.Service.Interface
{

	/// <summary>
	/// Interface for services.
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Removed "Base" suffix.
	/// </remarks>
	public interface IService
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		IConfigurationRoot ConfigurationRoot { get; }

#endregion

	}

}
