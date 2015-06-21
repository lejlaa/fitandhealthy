using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebMatrix.WebData;
using FitAndHealthy;
using FitAndHealthyAPI;
using System.Linq;

namespace FitAndHealthyAPI.Filters
{
    public class FandHAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) return;

            var authHeader = actionContext.Request.Headers.Authorization; 
            if (authHeader != null) {   
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(authHeader.Parameter))   
                {     
                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    string credentials = encoding.GetString(Convert.FromBase64String(rawCredentials)); 
                    string[] split = credentials.Split(':'); 
                    string username = split[0];
                    string password = split[1];

                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("FandHContext", "Users", "Id", "Username", autoCreateTables: true);
                    }

                    using (var ctx = new FandHContext())
                    {
                        User user = ctx.Users.SingleOrDefault(x => x.ConfirmationToken != null && x.Username == username);
                        if (user.ConfirmedUser == "True")
                        {
                            if (WebSecurity.Login(username, password))
                            {
                                var principal = new GenericPrincipal(new GenericIdentity(username), null);
                                System.Web.HttpContext.Current.User = principal; return;
                            }
                        }
                    }                     
                }
            }
            HandleUnauthorized(actionContext);      
        }

        void HandleUnauthorized(HttpActionContext actionContext) 
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='timeContext' location=''");
        } 
    }
}