using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    public class Users
    {
        public int Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; private set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public bool verified { get; set; }

    }
}
