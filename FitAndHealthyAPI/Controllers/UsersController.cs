using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class UsersController : ApiController
    {
        public List<User> Get()
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());

            List<User> allUsers = users.Get().ToList();

            
            return allUsers;
        }

        public User Get(int id)
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());
            return users.Get(id);
        }
    }
}
