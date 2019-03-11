using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("CoursCon")]
    public class CoursController : ApiController
    {
        Dbase db;
        public CoursController() // CONSTRUCTOR
        {
            db = new Dbase();
        }

        [HttpGet, Route("")]  //READ
        public IEnumerable<Cours> All()
        {
            return db.LesCours;
        }

        [HttpGet, Route("Nom")]  //READ
        public IEnumerable<Cours> WithName(String nom)
        {
            return db.LesCours.Where(c => c.nom.Contains(nom));
        }

        [HttpGet, Route("Desc")]  // READ
        public IEnumerable<Cours> WithDesc(String desc)
        {
            return db.LesCours.Where(c => c.description.Contains(desc));
        }

        [HttpPost, Route("Add")]    //CREATE
        public IEnumerable<Cours> Create([FromBody] Cours c)
        {
            if (c.nom != null && c.description != null)
            {
                db.LesCours.Add(c);
                db.SaveChanges();
            }
            return db.LesCours;
        }

        [HttpDelete, Route("remove")]  // DELETE
        public IEnumerable<Cours> Remove([FromBody] Cours c)
        {
            c = db.LesCours.Single(s => s.id == c.id);
            db.LesCours.Remove(c);
            db.SaveChanges();
            return db.LesCours;
        }

        [HttpPut, Route("Update")]  // UPDATE 
        public IEnumerable<Cours> Update([FromBody] Cours c)
        {
            if(c != null) // checking if object is not null
            {
                Cours cr = db.LesCours.Single(s => s.id == c.id); // getting the object & setting the object changer's referece to unchanged
                if (c.nom != null) cr.nom = c.nom; // setting name if not null
                if (c.description != null) cr.description = c.description; // setting last name if not null
                db.SaveChanges(); // saving changes
            }
            return db.LesCours; // return the entire list
        }


    }
}
