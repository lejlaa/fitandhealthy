using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitAndHealthyAPI.Controllers
{
    public class CommentsController : ApiController
    {
        public List<Comment> Get()
        {
            baseInterface<Comment> comments = new baseRepository<Comment>(new FandHContext());
            return comments.Get().ToList();
        }

        public Comment Get(int id)
        {
            baseInterface<Comment> comments = new baseRepository<Comment>(new FandHContext());
            return comments.Get(id);
        }
    }
}
