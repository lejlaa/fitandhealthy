using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitAndHealthyAPI.Models;
using System.Threading;
using FitAndHealthy;

namespace FitAndHealthyAPI.Services
{
    public class fandhIdentity : IfandhIdentity
    {
        public UserModel currentUser
        {
            get
            {
                if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated) return null;
                //string username = Thread.CurrentPrincipal.Identity.Name;
                string username = System.Web.HttpContext.Current.User.Identity.Name;

                if (username == null || username == "") username = HttpContext.Current.User.Identity.Name;

                var person = (new baseRepository<User>(new FandHContext())).GetAll().Where(x => x.Username == username).FirstOrDefault();
                if (person == null)
                    return null;
                else
                    return new UserModel
                    {
                        Id = person.Id,
                        Username = person.Username,
                        Banned = person.Banned,
                        Password = person.Password,
                        ConfirmedUser = person.ConfirmedUser,
                        Email = person.Email
                    };
            }
        }
    }
}