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
    public class CategoriesController : BaseApiController<Category>
    {
        public CategoriesController(baseInterface<Category> depo) : base(depo) { }

        public List<CategoryModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Category category = fandhDepo.Get(id);
                if (category == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Delete(category);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(CategoryModel categoryModel, int id)
        {
            try
            {
                Category newCategory = fandhFact.Parse(categoryModel);
                if (newCategory == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Category oldCategory = fandhDepo.Get(id);
                fandhDepo.Update(oldCategory, newCategory);                
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
