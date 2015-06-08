using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }

        public string User { get; set; }
        public int UserId { get; set; }
        public string Diet { get; set; }
        public int DietId { get; set; }
        public string Program { get; set; }
        public int ProgramId { get; set; }
        public string Training { get; set; }
        public int TrainingId { get; set; }
        public string Exercise { get; set; }
        public int ExerciseId { get; set; }
    }
}