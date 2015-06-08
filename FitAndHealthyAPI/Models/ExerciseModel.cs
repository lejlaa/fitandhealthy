using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class ExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
        public string Video { get; set; }
        public string Image { get; set; }
        public DateTimeOffset Duration { get; set; }
        public List<TrainingModel> Trainings { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}