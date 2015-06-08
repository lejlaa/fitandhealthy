using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrainingModel> Trainings { get; set; }
        public List<ProgramModel> Programs { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
    }
}