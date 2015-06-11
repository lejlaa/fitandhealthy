using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FitAndHealthyAPI.Controllers
{
    public class ConfirmationController : ApiController
    {
        public HttpResponseMessage Get(string Token)
        {
            var ctx = new FandHContext();
            User user = ctx.Users.SingleOrDefault(x => x.ConfirmationToken == Token);

            if (user == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                user.ConfirmedUser = "True";

                ctx.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }
    }
}
