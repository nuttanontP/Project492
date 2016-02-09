using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class myfunctionController : ApiController
    {
        public string k(string word)
        {
            return ("'"+word+"'");
        }
    }
}
