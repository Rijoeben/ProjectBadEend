using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend.Models
{
    public class Credentials
    {
        public int ID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get;  set; }
        public string Role { get; set; }
    }
}
