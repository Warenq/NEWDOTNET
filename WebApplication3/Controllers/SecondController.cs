using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    [RoutePrefix("kk")]
    public class SecondController : ApiController
    {
        // GET api/values
        [HttpGet,Route("")]
        public IEnumerable<string> defaultm()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet, Route("{id}")]
        public String defaultmwithID(int id)
        {
            return "Second Controller"+id;
        }
        


    }
}
