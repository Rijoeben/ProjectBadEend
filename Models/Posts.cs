using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    public class Posts
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Post_Date { get; private set; }
        public int Likes { get; set; }
        public int User_Id { get; set; }
    }
}
