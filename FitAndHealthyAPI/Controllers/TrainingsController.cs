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
    }
}
