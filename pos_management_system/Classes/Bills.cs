using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.Classes
{
    class Bills
    {
        public category category;
        public Items item;
        public double sale;
        public string sale_type;
        public double tax;
        public string tax_type;
        public double discount;
        public double total_price;
        public int quantity;
        public Bills(category category, Items item, double sale, string sale_type, double tax, string tax_type, double discount, double total_price, int quantity)
        {
            this.category = category;
            this.item = item;
            this.sale=sale;
            this.sale_type = sale_type;
            this.tax = tax;
            this.tax_type = tax_type;
            this.discount = discount;
            this.total_price = total_price;
            this.quantity = quantity;
        }
    }
}
