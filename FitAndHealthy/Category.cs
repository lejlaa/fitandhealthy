using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    class Category
    {
        public Category()
        {
            this.Subcategories = new List<Category>();
        }
        public int Id { get; set; }
        public String Name { get; set; }

        
        public virtual ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
