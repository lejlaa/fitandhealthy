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
    }
}
