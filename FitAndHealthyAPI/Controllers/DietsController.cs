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
    public class DietsController : BaseApiController<Diet>
    {
        public DietsController(baseInterface<Diet> depo) : base(depo) { }

        public List<DietModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Diet diet = fandhDepo.Get(id);
                if (diet != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(diet));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Post(DietModel dietModel)
        {
            try
            {
                Diet diet = fandhFact.Parse(dietModel);
                if (diet == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(diet);
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
                Diet diet = fandhDepo.Get(id);
                if (diet == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Delete(diet);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        public HttpResponseMessage Put(DietModel dietModel, int id)
        {
            try
            {
                Diet newDiet = fandhFact.Parse(dietModel);
                if (newDiet == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Diet oldDiet = fandhDepo.Get(id);
                fandhDepo.Update(oldDiet, newDiet);                
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
