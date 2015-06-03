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

    }
}
