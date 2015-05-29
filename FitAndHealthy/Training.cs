using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    class Training
    {
        public Training()
        {
            this.Exercises = new List<Exercise>();
            this.Comments = new List<Comment>();
            this.Categories = new List<Category>();
            this.Programs = new List<Program>();
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description  { get; set; }
        public int Rating { get; set; }
        public String Video { get; set; }
        public int RatedByNo { get; set; }


        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
