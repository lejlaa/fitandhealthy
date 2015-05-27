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
        }
        public int Id { get; set; }

        public String Name { get; set; }
        public int Rating { get; set; }
        public String Description { get; set; }
        public String Video { get; set; }
        public int RatedByNo { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Program> Programs { get; set; }



        
    }
}
