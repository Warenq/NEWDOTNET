using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Dbase : DbContext
    { 
        // YOU CAN MAKE AN EASIER NAME FOR EASIER ACCESS
        public virtual DbSet<Cours> LesCours { get; set; }
        public virtual DbSet<Etudiant> LesEtudiants { get; set; }
        public virtual DbSet<Filiere> LesFilieres { get; set; }
        public Dbase() : base("name=Dbase")
        {

        }
    }
}