﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy
{
    class Comment
    {
        public int Id { get; set; }
        public string Comment { get; set; } 
        public int Rating { get; set; }
        public int RatedByNo { get; set; }
    }
}
