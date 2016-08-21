using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminGold.Controllers
{
    public class mypromotionController : ApiController
    {
        // GET: api/mypromotion
        public IList<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/mypromotion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/mypromotion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/mypromotion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/mypromotion/5
        public void Delete(int id)
        {
        }
    }
}
