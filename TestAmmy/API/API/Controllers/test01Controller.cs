using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class test01Controller : ApiController
    {
        // GET: api/test01
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/test01/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/test01
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/test01/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/test01/5
        public void Delete(int id)
        {
        }
    }
}
