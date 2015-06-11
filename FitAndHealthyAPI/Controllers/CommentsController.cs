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
    public class CommentsController : BaseApiController<Comment>
    {
        public CommentsController(baseInterface<Comment> depo) : base(depo) { }

        public List<CommentModel> Get()
        {
            return fandhDepo.GetAll().ToList().Select(x => fandhFact.Create(x)).ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Comment comment = fandhDepo.Get(id);
                if (comment != null)
                    return Request.CreateResponse(HttpStatusCode.OK, fandhFact.Create(comment));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public HttpResponseMessage Post(CommentModel commentModel)
        {
            try
            {
                Comment comment = fandhFact.Parse(commentModel);
                if (comment == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(comment);
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
                Comment comment = fandhDepo.Get(id);
                if (comment == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                fandhDepo.Insert(comment);
                fandhDepo.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(CommentModel commentModel, int id)
        {
            try
            {
                Comment newComment = fandhFact.Parse(commentModel);
                if (newComment == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data");
                Comment oldComment = fandhDepo.Get(id);
                fandhDepo.Update(oldComment, newComment);                
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
