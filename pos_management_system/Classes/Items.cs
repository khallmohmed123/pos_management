using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.Classes
{
    class Items
    {
        public int id{set;get;}
        public string title{set;get;}
        public double sales_price { set; get; }
        public double regular_price { set; get; }
        public Items(int id,string title,double sales_price,double regular_price) {
            this.id = id;
            this.title = title;
            this.sales_price = sales_price;
            this.regular_price = regular_price;
        }
    }
}
