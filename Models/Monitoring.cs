using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    public class Monitoring
    {
        public int Id { get; private set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int ErrorCode { get; set; }
        // public string Ip {get;set;} "optioneel als het mogelijk is"
    }
}
