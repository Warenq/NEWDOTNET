using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("EtudiantCon")]
    public class EtudiantController : ApiController
    {
        Dbase db;

        public EtudiantController()
        {
            db = new Dbase();
        }
        [HttpGet,Route("")]
        public IEnumerable<Etudiant> All()
        {
            return db.LesEtudiants;
        }

        [HttpPost,Route("GetById")]
        public Etudiant ById([FromBody] Etudiant i)
        {
            return db.LesEtudiants.Single(z => z.id == i.id);
        }
        [HttpGet, Route("Name")] // Renaming Route because of confusion 
        public IEnumerable<Etudiant> SpecificName(String nom)
        {
            return db.LesEtudiants.Where(c => c.nom.Contains(nom));
        }

        [HttpGet, Route("LastName")] // Renaming Route because of confusion 
        public IEnumerable<Etudiant> SpecificLastName(String prenom)
        {
            return db.LesEtudiants.Where(c => c.prenom.Contains(prenom));
        }

        [HttpPost,Route("Create")]
        public IEnumerable<Etudiant> Create([FromBody] Etudiant e)
        {
            if (e != null) db.LesEtudiants.Add(e);
            db.SaveChanges();
            return db.LesEtudiants;
        }

        [HttpDelete,Route("Remove")]
        public IEnumerable<Etudiant> Remove([FromBody] Etudiant e)
        {
            if(e!=null){
                e = db.LesEtudiants.Single(c => c.id == e.id);
                    db.LesEtudiants.Remove(e);
                db.SaveChanges();
                       }
            return db.LesEtudiants;
        }

        [HttpPut,Route("Update")]
        public IEnumerable<Etudiant> Update([FromBody] Etudiant e)
        {
            if (e != null)
            {
                Etudiant p = db.LesEtudiants.Single(c => c.id == e.id);
                    if (e.nom != null) p.nom = e.nom;
                    if (e.prenom != null) p.prenom = e.prenom;
                db.SaveChanges();
            }
            return db.LesEtudiants;
        }
    }
}
