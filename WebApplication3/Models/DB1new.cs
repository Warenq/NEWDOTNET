using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class DB1new : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<ar1> ar1s { get; set; }
    }
}