using Microsoft.Extensions.Configuration;

namespace WACe001.Service.Interface
{

	public interface IServiceBase
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
