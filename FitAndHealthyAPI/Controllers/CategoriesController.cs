using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;  
using FitAndHealthyAPI.Models;
using FitAndHealthyAPI.Filters;

namespace FitAndHealthyAPI.Controllers
{
    public class CategoriesController : BaseApiController<Category>
    {
        public List<CategoryModel> Get()
        {
            IQueryable<Category> categories = fandhDepo.GetAll();
            return categories.ToList().Select(x => fandhFact.Create(x)).ToList();
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                Category category = fandhDepo.Get(id);
                if (category != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(category));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Post(CategoryModel categoryModel)
        {
            try
            {
                Category category = fandhFact.Parse(categoryModel);
                if (category == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(category);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [DisableCors()]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Category category = fandhDepo.Get(id);
                if (category == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(category);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        /*
        public HttpResponseMessage Put(ProjectModel projectModel)
        {
            try
            {
                Project project = timeFact.Parse(projectModel);
                if (project == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                timeDepo.Update(project, project.Id);
                timeDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }*/
    }
}
