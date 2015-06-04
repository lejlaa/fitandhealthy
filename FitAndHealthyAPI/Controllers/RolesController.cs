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

        public HttpResponseMessage Post([FromBody] Role role)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Roles.Add(role);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
