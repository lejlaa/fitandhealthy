using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class ProgramsController : ApiController
    {
        public List<Program> Get()
        {
            baseInterface<Program> programs = new baseRepository<Program>(new FandHContext());
            return programs.Get().ToList();
        }

        public Program Get(int id)
        {
            baseInterface<Program> programs = new baseRepository<Program>(new FandHContext());
            return programs.Get(id);
        }

        public HttpResponseMessage Post([FromBody] Program program)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Programs.Add(program);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public Program Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            Program program = ctx.Programs.SingleOrDefault(x => x.Id == id);
            ctx.Programs.Remove(program);

            ctx.SaveChanges();

            return program;


        }
    }
}
