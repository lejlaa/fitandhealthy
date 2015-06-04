using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class DietsController : ApiController

    {
        public List<Diet> Get()
        {
            baseInterface<Diet> diets = new baseRepository<Diet>(new FandHContext());
            return diets.Get().ToList();
        }

        public Diet Get(int id)
        {
            baseInterface<Diet> diets = new baseRepository<Diet>(new FandHContext());
            return diets.Get(id);
        }

        public HttpResponseMessage Post([FromBody] Diet diet)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Diets.Add(diet);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public Diet Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            Diet diet = ctx.Diets.SingleOrDefault(x => x.Id == id);
            ctx.Diets.Remove(diet);

            ctx.SaveChanges();

            return diet;


        }
    }
}
