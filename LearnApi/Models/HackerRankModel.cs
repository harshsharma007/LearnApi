﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnApi.Models
{
    public class HackerRankModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<HackerRankData> data { get; set; }
    }
}