using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("FiliereCon")]
    public class FiliereController : ApiController // CRUD CONTROLLER
    {
        Dbase db;
        public FiliereController()
        {
            db = new Dbase();
        }

        [HttpGet, Route("")] // Read All
        public IEnumerable<Filiere> All()
        {
            return db.LesFilieres.Include(z => z.etudiants);
        }

        [HttpGet,Route("GetAllAsString")] // let's add more to test
        public String AllFilieresAsString()
        {
            String sm = "";
            
            foreach (var v in db.LesFilieres.Include(c => c.etudiants))
            {
                sm += "--";
                sm += v.libelle +" Has :";
                foreach (var e in v.etudiants)
                {
                    sm += "-"+e.nom + " " + e.prenom;
                }

            }
            return sm;
        }

        [HttpGet, Route("Lib")] // Read with Label
        public IEnumerable<Filiere> All_lib(String lib)
        {
            return db.LesFilieres.Where(c => c.libelle.Contains(lib));
        }
        
        [HttpPost, Route("Add")] // CREATE
        public IEnumerable<Filiere> Add([FromBody] Filiere c)
        {
            IList<Etudiant> re = new List<Etudiant>();
            if (c.etudiants != null) { 
            foreach ( var e in c.etudiants) // then we add students inside
            {
                re.Add(db.LesEtudiants.Find(e.id));
            }
             c.etudiants = re;
                                    }
            db.LesFilieres.Add(c);
            db.SaveChanges();
            return db.LesFilieres;
        }

        [HttpDelete, Route("Remove")]  // REMOVE
        public IEnumerable<Filiere> Remove([FromBody] Filiere c)
        {
            if (c != null) { 
                Filiere ss = db.LesFilieres.Single(sqs => sqs.id == c.id);
                db.LesFilieres.Remove(ss);
                db.SaveChanges();
                        }
            return db.LesFilieres;
        }
        
        [HttpPut,Route("Update")] // Updating
        public IEnumerable<Filiere> Update([FromBody] Filiere f) // let's check if this thing is good
        {
            if(f != null)
            {
                Filiere p = db.LesFilieres.Single(q => q.id == f.id);
                if (f.libelle != null) p.libelle = f.libelle;
                if (f.etudiants != null) p.etudiants = f.etudiants;
                db.SaveChanges();
            }
            return db.LesFilieres;
        }

        [HttpPut,Route("AddEtudiant")] 
        public String AddEtudiant([FromBody] Filiere f)
        {
            if(f.etudiants!=null && f!= null) {
            Filiere ff = db.LesFilieres.Include(z => z.etudiants).Single(aa => aa.id == f.id); // google "change tracker" to know why i keep retreiving objects before updating them.
            foreach (var et in f.etudiants) // let's get each student & add him so change tracker keeps track (see what i did there)
                {
                    db.LesEtudiants.Where(c => c.id == et.id).Load(); // fetchings students that are in the request spinneret
                    Etudiant d = db.LesEtudiants.Find(et.id);
                    ff.etudiants.Add(d);
                }
            db.SaveChanges();
            string dm="";
            foreach (var s in ff.etudiants)
                {
                    dm += s.nom+" "+s.prenom;
                }
                return dm;
                            }
            return "Could not Affect Student to the spinneret";
        }


    }
}
