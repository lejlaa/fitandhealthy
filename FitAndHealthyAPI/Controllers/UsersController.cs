using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{  
    
    //[FitAndHealthyAPI.Filters.FandHAuthorize]
    public class UsersController : ApiController
    {
        public List<User> Get()
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());

            List<User> allUsers = users.GetAll().ToList();            
            return allUsers;
        }
        public HttpResponseMessage Post([FromBody] User user)
        {
            Random rnd = new Random();
            string strToken = rnd.Next(99999999).ToString();
            var rawToken = Encoding.UTF8.GetBytes(strToken);

            string token = Convert.ToBase64String(rawToken);
            //string token = generateToken();
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;


            user.Roles = new List<Role>();
            user.Banned = "false";
            user.ConfirmationToken = token; ;
            user.ConfirmedUser = " ";

            ctx.Users.Add(user);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    
        public User Get(int id)
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());
            return users.Get(id);
        }

        public User Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            User user = ctx.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            ctx.Users.Remove(user);

            ctx.SaveChanges();

            return user;


        }
    }
}
