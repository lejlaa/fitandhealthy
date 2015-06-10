using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        public List<Category> Get()
        {
            baseInterface<Category> categories = new baseRepository<Category>(new FandHContext());
            return categories.Get().ToList();
        }

        public Category Get(int id)
        {
            baseInterface<Category> categories = new baseRepository<Category>(new FandHContext());
            return categories.Get(id);
        }

        public HttpResponseMessage Post([FromBody] Category category)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Categories.Add(category);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public Category Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
           Category categorie = ctx.Categories.SingleOrDefault(x => x.Id == id);
            ctx.Categories.Remove(categorie);

            ctx.SaveChanges();

            return categorie;


        }

    }
}
