using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.Recipts
{
    class Bill
    {
        public List<Item_bill> items;
        public Bill() {
            this.items = new List<Item_bill>();
        }


        public void load_items(Dictionary<int, Classes.Bills> Bill)
        {
            foreach (KeyValuePair<int, Classes.Bills> bill in Bill)
            {
                Item_bill item = new Item_bill(
                    bill.Value.item.id, 
                    bill.Value.category.title,
                    bill.Value.item.title,
                    bill.Value.sale,
                    bill.Value.sale_type,
                    bill.Value.tax,
                    bill.Value.tax_type,
                    bill.Value.discount,
                    bill.Value.total_price,
                    bill.Value.quantity
                    );
                items.Add(item);
            }
        }
        public List<Item_bill> get_bill() {
            return items;
        }
    }
}