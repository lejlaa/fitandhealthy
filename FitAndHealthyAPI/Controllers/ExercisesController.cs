using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class ExercisesController : ApiController
    {
        public List<Exercise> Get()
        {
            baseInterface<Exercise> exercises = new baseRepository<Exercise>(new FandHContext());
            return exercises.Get().ToList();
        }

        public Exercise Get(int id)
        {
            baseInterface<Exercise> exercises = new baseRepository<Exercise>(new FandHContext());
            return exercises.Get(id);
        }

        public HttpResponseMessage Post([FromBody] Exercise exercise)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Exercises.Add(exercise);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public Exercise Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            Exercise exercise = ctx.Exercises.SingleOrDefault(x => x.Id == id);
            ctx.Exercises.Remove(exercise);

            ctx.SaveChanges();

            return exercise;


        }

    }
}
