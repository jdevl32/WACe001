using Microsoft.AspNetCore.Mvc;

namespace WACe001.Controller.Api.Interface
{

	public interface IApiController
	{

		IActionResult Get();

		string Get(int id);

		// todo|jdevl32: probably not needed...
		//void Post([FromBody]string value);

		void Put(int id, [FromBody]string value);

		void Delete(int id);

	}

}
