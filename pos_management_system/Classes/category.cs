using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.Classes
{
    class category
    {
        public int id;
        public string title;
        public category(int id=0, string title="") {
            this.id = id;
            this.title = title;
        }
    }
}
