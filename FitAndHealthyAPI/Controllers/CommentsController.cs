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

        public HttpResponseMessage Post([FromBody] Comment comment)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;

            ctx.Comments.Add(comment);
            if (ctx.SaveChanges() != 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
