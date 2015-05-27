using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    class User
    {
        public User()
        {
            this.Roles = new List<Role>();
            this.Programs = new List<Program>();
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwooed { get; set; }
        public bool Banned { get; set;  }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
