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
 //   [FitAndHealthyAPI.Filters.FandHAuthorize]
    public class RolesController : BaseApiController<Role>
    {

        public RolesController(baseInterface<Role> depo) : base(depo) { }

        public List<RoleModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Role role = fandhDepo.Get(id);
                if (role != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(role));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public HttpResponseMessage Post(RoleModel roleModel)
        {
            try
            {
                Role role = fandhFact.Parse(roleModel);
                if (role == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(role);
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
                Role role = fandhDepo.Get(id);
                if (role == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(role);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(RoleModel roleModel, int id)
        {
            try
            {
                Role newRole = fandhFact.Parse(roleModel);
                if (newRole == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Role oldRole = fandhDepo.Get(id);
                fandhDepo.Update(oldRole, newRole);                
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
