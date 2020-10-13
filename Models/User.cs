using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveStreamer.Models
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string[] groups { get; set; }

    }
}
