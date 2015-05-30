using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class Program
    {
        public Program()
        {
            this.Trainings = new List<Training>();
            this.Categories = new List<Category>();
            this.Users = new List<User>();
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
        public string VideoLink { get; set; }

        public User Author { get; set; }
        public Diet Diet { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}
