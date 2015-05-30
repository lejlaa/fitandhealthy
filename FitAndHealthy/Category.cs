using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }

        
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
