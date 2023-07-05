using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.controllers
{
    class language
    {
        public string ar { set; get; }
        public string en { set; get; }
        public string ru { set; get; }
        public string fr { set; get; }
        public language(string ar, string en, string ru, string fr)
        {
            this.ar = ar;
            this.fr = fr;
            this.ru = ru;
            this.en = en;
        }
    }
}
