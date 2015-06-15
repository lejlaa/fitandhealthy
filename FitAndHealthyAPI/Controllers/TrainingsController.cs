using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthy;
using FitAndHealthyAPI.Models;

namespace FitAndHealthyAPI.Controllers
{
    [FitAndHealthyAPI.Filters.FandHAuthorize]
    public class TrainingsController : BaseApiController<Training>
    {
        public TrainingsController(baseInterface<Training> depo) : base(depo) { }

        public List<TrainingModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Training training = fandhDepo.Get(id);
                if (training != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(training));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public HttpResponseMessage Post(TrainingModel trainingModel)
        {
            try
            {
                Training training = fandhFact.Parse(trainingModel);
                if (training == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(training);
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
                Training training = fandhDepo.Get(id);
                if (training == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(training);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(TrainingModel trainingModel, int id)
        {
            try
            {
                Training newTraining = fandhFact.Parse(trainingModel);
                if (newTraining == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Training oldTraining = fandhDepo.Get(id);
                fandhDepo.Update(oldTraining, newTraining);                
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
