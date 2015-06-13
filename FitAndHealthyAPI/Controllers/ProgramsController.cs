using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthyAPI.Models;

namespace FitAndHealthyAPI.Controllers
{
    public class ProgramsController : BaseApiController<Program>
    {

        public ProgramsController(baseInterface<Program> depo) : base(depo) { }

        public List<ProgramModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Program program = fandhDepo.Get(id);
                if (program != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(program));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public HttpResponseMessage Post(ProgramModel programModel)
        {
            try
            {
                Program program = fandhFact.Parse(programModel);
                if (program == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                
                program.Categories = new List<Category>();
                program.Comments = new List<Comment>();
                program.Trainings = new List<Training>();
                program.Users = new List<User>();

                fandhDepo.Insert(program);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Program program = fandhDepo.Get(id);
                if (program == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(program);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(ProgramModel programModel, int id)
        {
            try
            {
                Program newProgram = fandhFact.Parse(programModel);
                if (newProgram == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Program oldProgram = fandhDepo.Get(id);
                fandhDepo.Update(oldProgram, newProgram);                
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
