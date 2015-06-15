using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitAndHealthyAPI.Services;
using WebMatrix.WebData;
using System.Threading;
using System.Web;


namespace FitAndHealthyAPI.Controllers
{
    [FitAndHealthyAPI.Filters.FandHAuthorize]
    public class AuthController : ApiController
    {
        IfandhIdentity ident = new fandhIdentity();

        public HttpResponseMessage Get(int id = 0)
        {
            if (id == 1)
            {
                if (!WebSecurity.Initialized) 
                    WebSecurity.InitializeDatabaseConnection("FandHContext", "Users", "Id", "Username", autoCreateTables: true);
                WebSecurity.Logout();

                System.Web.HttpContext.Current.User = null;

                HttpContext.Current.User = null;
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                if (ident.currentUser == null)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, ident.currentUser);
            }
        }
    }
}
