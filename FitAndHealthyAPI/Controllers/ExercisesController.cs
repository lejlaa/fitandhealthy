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
    public class ExercisesController : BaseApiController<Exercise>
    {
        public ExercisesController(baseInterface<Exercise> depo) : base(depo) { }

        public List<ExerciseModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Exercise exercise = fandhDepo.Get(id);
                if (exercise != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(exercise));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public HttpResponseMessage Post(ExerciseModel exerciseModel)
        {
            try
            {
                Exercise exercise = fandhFact.Parse(exerciseModel);
                if (exercise == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(exercise);
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
                Exercise exercise = fandhDepo.Get(id);
                if (exercise == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(exercise);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(ExerciseModel exerciseModel, int id)
        {
            try
            {
                Exercise newExercise = fandhFact.Parse(exerciseModel);
                if (newExercise == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Exercise oldExercise = fandhDepo.Get(id);
                fandhDepo.Update(oldExercise, newExercise);                
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
