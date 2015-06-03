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
    }
}
