using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bliss_classes
{
    class Bill
    {
        public List<Item_bill> items;
        public DataTable BIll_Items;
        public Bill() {
           items = new List<Item_bill>();
        }
        public void load_items(Dictionary<int, pos_management_system.Classes.Bills> Bill)
        {
            BIll_Items = new DataTable();
            BIll_Items.Columns.Add("item_id", typeof(int));
            BIll_Items.Columns.Add("category", typeof(string));
            BIll_Items.Columns.Add("name", typeof(string));
            BIll_Items.Columns.Add("sale", typeof(double));
            BIll_Items.Columns.Add("sale_type", typeof(string));
            BIll_Items.Columns.Add("tax", typeof(double));
            BIll_Items.Columns.Add("tax_type", typeof(string));
            BIll_Items.Columns.Add("discount", typeof(double));
            BIll_Items.Columns.Add("total_price", typeof(double));
            BIll_Items.Columns.Add("quantity", typeof(int));
            foreach (KeyValuePair<int, pos_management_system.Classes.Bills> bill in Bill)
            {
                BIll_Items.Rows.Add(
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
                //Item_bill item = new Item_bill(
                //    bill.Value.item.id, 
                //    bill.Value.category.title,
                //    bill.Value.item.title,
                //    bill.Value.sale,
                //    bill.Value.sale_type,
                //    bill.Value.tax,
                //    bill.Value.tax_type,
                //    bill.Value.discount,
                //    bill.Value.total_price,
                //    bill.Value.quantity
                //    );
                //items.Add(item);
            }
        }
        public DataTable get_bill() {
            return BIll_Items;
        }
    }
}