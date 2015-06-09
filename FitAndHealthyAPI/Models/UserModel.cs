using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Banned { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<ProgramModel> Programs { get; set; }
        public List<ProgramModel> UserPrograms { get; set; }
    }
}