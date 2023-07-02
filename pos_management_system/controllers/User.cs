using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.controllers
{
    class User
    {
        public int id{get;set;}
        public string name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int role_db { get; set; }
    }
}
