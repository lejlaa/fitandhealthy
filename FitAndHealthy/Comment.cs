using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; } 
        public int Rating { get; set; }
        public int RatedByNo { get; set; }

        public User User { get; set; }
        public Diet Diet { get; set; }
        public Program Program { get; set; }
        public Training Training { get; set; }
        public Exercise Exercise { get; set; }
    }
}
