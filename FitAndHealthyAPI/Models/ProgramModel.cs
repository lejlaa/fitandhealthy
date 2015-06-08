using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class ProgramModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
        public string VideoLink { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public string Diet { get; set; }
        public int DietId { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<TrainingModel> Trainings { get; set; }
        public List<UserModel> Users { get; set; }
        public List<CommentModel> Comments { get; set; }

    }
}