using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Items
{
    public partial class Items : Forms.Layout.Layout
    {
        controllers.mapper mapper;
        controllers.translator trans;
        private controllers.Helper Helper;
        private Dictionary<int, Classes.category> datacategories = new Dictionary<int, Classes.category>();
        public Items()
        {
            InitializeComponent();
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            load_lang();
            Helper.load_layout(this);
            load_item();
        }
        public void load_item()
        {
            controllers.Categories cateory_mapper = new controllers.Categories();
            BindingSource categories_bind = cateory_mapper.allCategoris();
            int loop = 0;
            foreach (DataRowView cate in categories_bind)
            {
                datacategories.Add(loop,new Classes.category(int.Parse(cate.Row[0].ToString()),cate.Row[1].ToString()));
                comboBox1.Items.Add(cate.Row[1].ToString());
                loop++;
            }
            string sql = @"SELECT item.id id, item.title title,item.sales_price 'sales price',item.regular_price 'regular price',category.title as category  FROM [Item] item
                            INNER JOIN [item_category] 
                                ON
                            [item_category].[item_id]=item.[id]
                            INNER JOIN [category] category
                                ON 
                            [item_category].[category_id]=category.[id]";
            mapper = new controllers.mapper();
            BindingSource items_with_categories= mapper.custom_select(sql).get();
            dataGridView1.DataSource = items_with_categories;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }
        public void load_lang()
        {
            label2.Text = trans.get("id");
            label3.Text = trans.get("name");
            label4.Text = trans.get("sales_price");
            label5.Text = trans.get("regular_price");
            label6.Text = trans.get("category");
            button1.Text = trans.get("create_new");
            button3.Text = trans.get("update");
            button2.Text = trans.get("delete");
            button4.Text = trans.get("cancel");
            groupBox2.Text = trans.get("items_info");
        }
        public override BaseClass.BaseForm get_instance()
        {
            return new Items();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string name = textBox3.Text;
            double sales_price = double.Parse(textBox4.Text);
            double regular_price = double.Parse(textBox5.Text);
            Classes.category selected_category=new Classes.category();
            if(comboBox1.SelectedIndex>=0)
                selected_category=datacategories[comboBox1.SelectedIndex];
            controllers.Items items_contolers = new controllers.Items();
            int ret_id=items_contolers.add_Item(name, sales_price, regular_price, selected_category);
            MessageBox.Show(ret_id.ToString());
            clear_controls();
            load_item();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string sales_price = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string regular_price = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            controllers.Items items = new controllers.Items();
            Classes.category category = items.get_category(int.Parse(id));
            foreach(KeyValuePair<int, Classes.category> entry in this.datacategories)
            {
                if(entry.Value.id==category.id)
                {
                    comboBox1.SelectedIndex = entry.Key;
                }
            }
            textBox2.Text = id;
            textBox3.Text = name;
            textBox4.Text = sales_price;
            textBox5.Text = regular_price;
            button2.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
           int id =int.Parse(textBox2.Text);
           string name=textBox3.Text;
           double sales_price = double.Parse(textBox4.Text);
           double regular_price = double.Parse(textBox5.Text);
           Classes.category selected_category = new Classes.category();
           if (comboBox1.SelectedIndex >= 0)
               selected_category = datacategories[comboBox1.SelectedIndex];
           controllers.Items Items = new controllers.Items();
           bool updated=Items.update_item(id,name,sales_price,regular_price,selected_category);
           if (updated)
           {
               MessageBox.Show("updated successfully");
           }
           clear_controls();
           load_item();
        }
        private void clear_controls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Items.Clear();
            datacategories = new Dictionary<int, Classes.category>();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);
            Classes.category selected_category = new Classes.category();
            if (comboBox1.SelectedIndex >= 0)
                selected_category = datacategories[comboBox1.SelectedIndex];
            controllers.Items Items = new controllers.Items();
            if(Items.delete_item(id, selected_category))
            {
                MessageBox.Show("deleted successfully");
                clear_controls();
                load_item();
            }
        }
    }
}
