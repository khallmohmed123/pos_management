using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.Recipts
{
    class Item_bill
    {
        public string category {get;set;}
        public string item { get; set; }
        public double sale { get; set; }
        public string sale_type { get; set; }
        public double tax { get; set; }
        public string tax_type { get; set; }
        public double discount { get; set; }
        public double total { get; set; }
        public int count { get; set; }
        public Item_bill(
        int id,    
        string category, 
        string item, 
        double sale, 
        string sale_type, 
        double tax, 
        string tax_type, 
        double discount, 
        double total_price, 
        int quantity
            )
        {
            this.category = category;
            this.item = item;
            this.sale=sale;
            this.sale_type = sale_type;
            this.tax = tax;
            this.tax_type = tax_type;
            this.discount = discount;
            this.total = total_price;
            this.count = quantity;
        }
    }
}
