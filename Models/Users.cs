using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string _Password { get; set; }
        public string _Role { get; set; }
        public string token { get; set; }

    }
}
