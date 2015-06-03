using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class ProgramController : ApiController
    {
        public List<Program> Get() { 
            baseInterface<Program> programs = new baseRepository<Program>(new FandHContext()); 
            return programs.Get().ToList(); }

        public Program Get(int id) { 
            baseInterface<Program> programs = new baseRepository<Program>(new FandHContext()); 
            return programs.Get(id); }
    }
}
