
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class Diet
    {
        public Diet()
        {
            this.Comments = new List<Comment>();
            this.Programs = new List<Program>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }

        public virtual ICollection <Program> Programs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
