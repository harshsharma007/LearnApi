using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnApi.Models
{
    public class HackerRankData
    {
        public string title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public int num_comments { get; set; }
        public object story_id { get; set; }
        public object story_title { get; set; }
        public object story_url { get; set; }
        public object parent_id { get; set; }
        public int created_at { get; set; }
    }
}