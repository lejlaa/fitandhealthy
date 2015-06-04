using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthy;

namespace FitAndHealthyAPI.Controllers
{
    public class ActionsController : ApiController
    {
        public List<FitAndHealthy.Action> Get()
        {
            baseInterface<FitAndHealthy.Action> actions = new baseRepository<FitAndHealthy.Action>(new FandHContext());
            return actions.Get().ToList();
        }

        public FitAndHealthy.Action Get(int id)
        {
            baseInterface<FitAndHealthy.Action> actions = new baseRepository<FitAndHealthy.Action>(new FandHContext());
            return actions.Get(id);
        }

        public HttpResponseMessage Post([FromBody] FitAndHealthy.Action action)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Actions.Add(action);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public  FitAndHealthy.Action Delete(int id)


        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            FitAndHealthy.Action action = ctx.Actions.SingleOrDefault(x => x.Id== id);
            ctx.Actions.Remove(action);

            ctx.SaveChanges();

            return action;

                     
        }
    }
}
