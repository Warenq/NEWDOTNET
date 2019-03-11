using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Filiere
    {
        public int id { get; set; }
        public string libelle { get; set; }
        public virtual IList<Etudiant> etudiants { get; set; }
    }
}