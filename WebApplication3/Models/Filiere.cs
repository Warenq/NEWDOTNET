using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Filiere
    {
        public int id { get; set; }
        public String name { get; set; }
        public List<User> users { get; set; }
    }
}