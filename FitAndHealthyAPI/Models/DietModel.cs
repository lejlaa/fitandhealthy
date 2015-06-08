using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitAndHealthyAPI.Models
{
    public class DietModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
        public List<ProgramModel> Programs { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}