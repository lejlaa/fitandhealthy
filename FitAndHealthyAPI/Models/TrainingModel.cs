using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class TrainingModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Rating { get; set; }
        public String Video { get; set; }
        public int RatedByNo { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<ProgramModel> Program { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
    }
}