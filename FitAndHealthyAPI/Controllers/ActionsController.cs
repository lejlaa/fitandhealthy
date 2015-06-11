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
    public class ActionsController : BaseApiController<FitAndHealthy.Action>
    {
        public ActionsController(baseInterface<FitAndHealthy.Action> depo) : base(depo) { }

        public List<ActionModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                FitAndHealthy.Action action = fandhDepo.Get(id);
                if (action != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(action));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Post(ActionModel actionModel)
        {
            try
            {
                FitAndHealthy.Action action = fandhFact.Parse(actionModel);
                if (action == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(action);
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
                FitAndHealthy.Action action = fandhDepo.Get(id);
                if (action == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(action);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(ActionModel actionModel, int id)
        {
            try
            {
                FitAndHealthy.Action newAction = fandhFact.Parse(actionModel);
                if (newAction == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                FitAndHealthy.Action oldAction = fandhDepo.Get(id);
                fandhDepo.Update(oldAction, newAction);
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
