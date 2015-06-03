using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthy;

namespace FitAndHealthyAPI.Controllers
{
    public class RolesController : ApiController
    {
        public List<Role> Get()
        {
            baseInterface<Role> roles = new baseRepository<Role>(new FandHContext());
            return roles.Get().ToList();
        }

        public Role Get(int id)
        {
            baseInterface<Role> roles = new baseRepository<Role>(new FandHContext());
            return roles.Get(id);
        }
    }
}
