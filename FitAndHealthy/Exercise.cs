using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    class Exercise
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
        public String Video { get; set; }

        public String Image { get; set; }

        public DateTimeOffset Duration { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

    }
}
