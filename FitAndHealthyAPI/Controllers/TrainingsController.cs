using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthy;

namespace FitAndHealthyAPI.Controllers
{
    public class TrainingsController : ApiController
    {
        public List<Training> Get()
        {
            baseInterface<Training> trainings = new baseRepository<Training>(new FandHContext());
            return trainings.Get().ToList();
        }

        public Training Get(int id)
        {
            baseInterface<Training> trainings = new baseRepository<Training>(new FandHContext());
            return trainings.Get(id);
        }

        public HttpResponseMessage Post([FromBody] Training training)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Trainings.Add(training);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public Training Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            Training training = ctx.Trainings.SingleOrDefault(x => x.Id == id);
            ctx.Trainings.Remove(training);

            ctx.SaveChanges();

            return training;


        }
    }
}
