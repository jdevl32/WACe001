using Microsoft.AspNetCore.Hosting;
using WACe001.Repository.Interface;

namespace WACe001.Controller.Interface
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Last modification:
	/// Refactor (rename, move and rebase).
	/// </remarks>
	public interface IBaseController
	{

#region Property

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		IHostingEnvironment HostingEnvironment { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		ITravelRepository TravelRepository { get; }

#endregion

		// todo|jdevl32: not needed ???
#if true
#else
		IActionResult Get();

		string Get(int id);

		//void Post([FromBody]string value);

		void Put(int id, [FromBody]string value);

		void Delete(int id);
#endif

	}

}
