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

        public List<Program> Get()
        {
            //return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
            var ctx = new FandHContext();
            List<Program> programs = ctx.Programs.Include("Trainings").Include("Author").Include("Diet").ToList();
            return programs;
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var ctx = new FandHContext();
                Program program = ctx.Programs.Include("Trainings").Include("Author").Include("Diet").Single(a => a.Id ==id);
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
         [FitAndHealthyAPI.Filters.FandHAuthorize]
        public HttpResponseMessage Post(ProgramModel programModel)
        {
            try
            {
                Program program = fandhFact.Parse(programModel);
                //if (program == null)
                //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                
                //program.Categories = new List<Category>();
                //program.Comments = new List<Comment>();
                //program.Trainings = new List<Training>();
                //program.Users = new List<User>();

                //fandhDepo.Insert(program);
                //fandhDepo.Commit();

                var ctx = new FandHContext();


                User usr = ctx.Users.Single(a => a.Id == programModel.AuthorId);
                program.Author = usr;

                ctx.Programs.Add(program);
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

         [FitAndHealthyAPI.Filters.FandHAuthorize]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //var ctx = new FandHContext();
                Program program = fandhDepo.Get(id);//ctx.Programs.Include("Trainings").Single(a => a.Id == id);
               
                if (program == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Delete(program);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
         [FitAndHealthyAPI.Filters.FandHAuthorize]
        public HttpResponseMessage Put(ProgramModel programModel, int id)
        {
            //try
            //{
            //    Program newProgram = fandhFact.Parse(programModel);
            //    if (newProgram == null)
            //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
            //    Program oldProgram = fandhDepo.Get(id);
            //    fandhDepo.Update(oldProgram, newProgram);                
            //    fandhDepo.Commit();
            //    return Request.CreateResponse(HttpStatusCode.OK);
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
            try
            {
                var ctx = new FandHContext();
                Program newProgram = ctx.Programs.Single(a => a.Id == programModel.Id); //fandhFact.Parse(programModel);
               // newProgram = fandhFact.Parse(programModel);
               // ctx.Entry(newProgram).CurrentValues.SetValues(programModel);
                newProgram.Name = programModel.Name;
                newProgram.Description = programModel.Description;
                newProgram.Duration = programModel.Duration;
                newProgram.Rating = programModel.Rating;
                newProgram.RatedByNo = programModel.RatedByNo;
                newProgram.VideoLink = programModel.VideoLink;

                foreach (TrainingModel trModel in programModel.Trainings)
                {
                    Training tr = ctx.Trainings.Single(a => a.Id == trModel.Id);
                    newProgram.Trainings.Add(tr);
                }

                    Diet d = ctx.Diets.Single(a => a.Id == programModel.DietId);
                    newProgram.Diet = d;
                

                ctx.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
