﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class LoController : ApiController
    {
        // GET: api/Lo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lo/5
        public string Get(int id)
        {
            return "LO"+id;
        }

        // POST: api/Lo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Lo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lo/5
        public void Delete(int id)
        {
        }
    }
}
