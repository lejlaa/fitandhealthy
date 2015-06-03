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
    }
}
