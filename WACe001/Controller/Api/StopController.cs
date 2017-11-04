using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WACe001.Controller.Api
{

	[Produces("application/json")]
    [Route("api/Stop")]
    public class StopController : Microsoft.AspNetCore.Mvc.Controller
    {

        // GET: api/Stop
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stop/5
        [HttpGet("{id}", Name = "GetStop")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Stop
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Stop/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }

}
