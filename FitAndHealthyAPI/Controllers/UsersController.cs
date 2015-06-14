using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using WebMatrix.WebData;

namespace FitAndHealthyAPI.Controllers
{

    
    public class UsersController : ApiController
    {
        [FitAndHealthyAPI.Filters.FandHAuthorize]
        public List<User> Get()
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());

            List<User> allUsers = users.GetAll().ToList();
            return allUsers;
        }
        public HttpResponseMessage Post([FromBody] User user)
        {
            Random rnd = new Random();
            string strToken = rnd.Next(99999999).ToString();
            var rawToken = Encoding.UTF8.GetBytes(strToken);

            string token = Convert.ToBase64String(rawToken);
            //string token = generateToken();
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;


            user.Roles = new List<Role>();
            user.Banned = "false";
            user.ConfirmationToken = token; ;
            user.ConfirmedUser = " ";
            
           
            WebSecurity.InitializeDatabaseConnection("FandHContext", "Users", "Id", "Username", autoCreateTables: true);


           // ctx.Users.Add(user);
            WebSecurity.CreateUserAndAccount(user.Username, user.Password, new { Password = "", Banned = "false", ConfirmationToken = token, ConfirmedUser = "false", user.Email }, false);//ctx.SaveChanges() != 0)
           // {

                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("probnimail00@gmail.com");
                mail.Subject = "Email";
                mail.IsBodyHtml = true;

                string body = "localhost:11330/api/confirmation/?Token=" + token;

                //string body = "<html><body> Hello,";
                //body += "<br />Please click the following link to activate your account <a href=\"" + link + "\"> Click on the link </a>";
                //body += "<br /><br />Thanks</body></html>";
                mail.Body = body;
                mail.Priority = MailPriority.High;

                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                sc.Credentials = new System.Net.NetworkCredential("probnimail00@gmail.com", "nwtprojekat");//username doesn't include @gmail.com

                sc.EnableSsl = true;

                sc.Send(mail);
                Console.WriteLine("-- Sending Email --");
                return new HttpResponseMessage(HttpStatusCode.Created);
           // }

            //return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [FitAndHealthyAPI.Filters.FandHAuthorize]
        public User Get(int id)
        {
            baseInterface<User> users = new baseRepository<User>(new FandHContext());
            return users.Get(id);
        }

        [FitAndHealthyAPI.Filters.FandHAuthorize]
        public User Delete(int id)
        {
            var ctx = new FandHContext();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = false;
            User user = ctx.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            ctx.Users.Remove(user);

            ctx.SaveChanges();

            return user;


        }
    }
}
