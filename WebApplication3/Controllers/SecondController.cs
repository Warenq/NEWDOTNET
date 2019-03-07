using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    [RoutePrefix("kk")]
    public class SecondController : ApiController
    {
        DB1new c;
        public SecondController(){
            c = new DB1new();
        }
        
        [HttpGet,Route("")]
        public IEnumerable<User> GetAllUsers(){
                return c.Users;
                                                }

        [HttpGet,Route("SearchUserName")]
        public IEnumerable<User> SearchUsers(String t){
            return c.Users.Where(c => c.name.Contains(t));
        }

        [HttpPost,Route("Add")]
        public IEnumerable<User> CreateUser([FromBody] User u){
            c.Users.Add(u);
            c.SaveChanges();
            return c.Users;
        }

        [HttpDelete,Route("Delete")]
        public IEnumerable<User> DeleteUser([FromBody] User u){
            User d = c.Users.Single(c => c.id == u.id);
            if(d != null){
                c.Users.Remove(d);
            }
            c.SaveChanges();
            return c.Users;
        }

        [HttpPut,Route("Update")]
        public IEnumerable<User> UpdateUser([FromBody] User u){
            IList<User> l = new List<User>();
            l.Add(u);
            if(c.Users.Single(us => us.id == u.id) != null){ // IF USER EXISTS

            User um = c.Users.Single(us => us.id == u.id);
            l.Add(um); // BEFORE MODIFICATION

            if(u.name != null){ // MODIFYING NAME
                    um.name = u.name;
                                }
            if(u.prenom != null){  // MODYING PRENOM
                    um.prenom = u.prenom;
                                }

            l.Add(um); // AFTER MODIFICATION
            c.SaveChanges();// RETURNING THE LIST CONTAINING THE BEFORE & AFTER
                                                         }

            return l;
        }
    
    }
}
