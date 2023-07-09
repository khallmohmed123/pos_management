using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.controllers
{
    class Items
    {
        int id;
        string name;
        double sales_price;
        double regular_price;
        Classes.category category;
        controllers.mapper mapper;
        string tableName = "[Item]";
        string item_category_table = "[item_category]";
        public Items() { 
        }
        public int add_Item(string name, double sales_price, double regular_price, Classes.category category)
        {
            mapper = new controllers.mapper();
            int inserted = 0;
            string[] bind_params = new string[] { "title", "sales_price", "regular_price"};
            string[] bind_values = new string[] { "@title", "@sales_price", "@regular_price" };
            int affectedRows = mapper.insert(this.tableName, bind_params, bind_values,true)
            .add_bind_values("@title", name)
            .add_bind_values("@sales_price", sales_price.ToString())
            .add_bind_values("@regular_price", regular_price.ToString())
            .ExecuteNonQuery();
            if (affectedRows <= 0)
            {
                return affectedRows;
            }

            int category_id=category.id;
            if (category_id > 0)
            {
                mapper = new controllers.mapper();
                string[] bind_params_2 = new string[] { "item_id", "category_id"};
                string[] bind_values_2 = new string[] { "@item_id", "@category_id"};
                int affectedRows_2 = mapper.insert(this.item_category_table, bind_params_2, bind_values_2)
                .add_bind_values("@item_id", affectedRows.ToString())
                .add_bind_values("@category_id", category_id.ToString())
                .ExecuteNonQuery();
                if (affectedRows_2 > 0)
                    inserted = 1;
            }
            return inserted;
        }
        public Classes.category get_category(int id) {
            this.category = new Classes.category();
            mapper = new mapper();
            string[] select = new string[] { };
            string sql = @"SELECT [category].[id] id , [category].[title] name  FROM [item_category] 
            INNER JOIN [category]
            ON [item_category].[category_id]=[category].[id]
            AND [item_category].[item_id]=" + id;
            mapper.custom_select(sql);
            BindingSource categories_bind = mapper.get();
            foreach (DataRowView cate in categories_bind)
            {
                category = new Classes.category(int.Parse(cate[0].ToString()), cate[1].ToString());
            }
            return this.category;
        }
        public bool update_item(int id, string name, double sales_price, double regular_price, Classes.category category)
        {
            bool updated = false;
            mapper = new mapper();
            string set = "category_id=@category_id";
            string where = "item_id=@item_id";
            mapper.update(this.item_category_table, set, where);
            mapper.add_bind_values("@category_id", category.id.ToString());
            mapper.add_bind_values("@item_id", id.ToString());
            int updated_category = mapper.ExecuteNonQuery();
            mapper = new mapper();
            string set_item = "title=@title,sales_price=@sales_price,regular_price=@regular_price";
            string where_item = "Id=@Id";
            mapper.update(this.tableName, set_item, where_item);
            mapper.add_bind_values("@Id", id.ToString());
            mapper.add_bind_values("@title", name);
            mapper.add_bind_values("@sales_price", sales_price.ToString());
            mapper.add_bind_values("@regular_price", regular_price.ToString());
            int updated_item = mapper.ExecuteNonQuery();
            if (updated_category <= 0 || updated_item <= 0)
            {
                MessageBox.Show("update error");
                return updated;
            }
            updated = true;
            return updated;
        }
        public bool delete_item(int id, Classes.category category)
        {
            bool deleted = false;
            mapper = new controllers.mapper();
            mapper.delete(this.tableName, "id = @id");
            mapper.add_bind_values("@id", id.ToString());
            int deleted_stat = mapper.ExecuteNonQuery();
            mapper = new controllers.mapper();
            mapper.delete(this.item_category_table, "item_id = @item_id AND category_id=@category_id");
            mapper.add_bind_values("@item_id", id.ToString());
            mapper.add_bind_values("@category_id", category.id.ToString());
            int deleted_stat_2 = mapper.ExecuteNonQuery();
            if(deleted_stat<=0 || deleted_stat_2 <=0)
            {
                MessageBox.Show("error in delete");
                return false;
            }
            deleted = true;
            return deleted;
        }
        public BindingSource get_items_for_categories(int id) 
        {
            mapper = new controllers.mapper();
            BindingSource bd=new BindingSource();
            string sql = @"SELECT [Item].[Id] 'id' , [Item].[title] 'title',[Item].[sales_price] 'sales price',[Item].[regular_price] 'regular price' FROM [Item] 
            INNER JOIN [item_category]
            ON [item_category].[item_id]=[Item].[id]
            INNER JOIN [category]
            ON [item_category].[category_id]=[category].[id]
            AND [item_category].[category_id]=" + id;
            mapper.custom_select(sql);
            bd = mapper.get();
            return bd;
        }
    }
}
