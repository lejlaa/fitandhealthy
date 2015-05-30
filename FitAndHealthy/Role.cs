using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class Role
    {
        public Role()
        {
            this.Actions = new List<Action>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
