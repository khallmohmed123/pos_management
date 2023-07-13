using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Bills
{
    public partial class Bill : Layout.Layout
    {
        controllers.mapper mapper;
        controllers.translator trans;
        private controllers.Helper Helper;
        Dictionary<int, Classes.category> categories = new Dictionary<int, Classes.category>();
        Dictionary<int, Classes.Items> Items = new Dictionary<int, Classes.Items>();
        Dictionary<int, Classes.Bills> Bills = new Dictionary<int, Classes.Bills>();
        public Bill()
        {
            InitializeComponent();
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            load_lang();
            load_categories();
            default_release();
        }
        private void default_release() {
            dataGridView1.Rows.Clear();
            BindingSource bs = new BindingSource();
            //object bind_item = new
            //{
            //    number,
            //    category,
            //    item_name,
            //    quantity,
            //    sale_type,
            //    sale_value,
            //    tax_type,
            //    tax_value,
            //    sale_price,
            //    regulare_price,
            //    price_discount,
            //    total
            //};
            //bs.Add(bind_item);
            dataGridView1.DataSource = bs;
        }
        public override BaseClass.BaseForm get_instance()
        {
            return new Bill();
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor =Color.Black;
            pictureBox2.Cursor = Cursors.Hand;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = SystemColors.Control;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool errors = false;
            if(comboBox1.SelectedIndex<0){
                errorProvider1.SetError(comboBox1,"the categories is required");
                errors = true;
            }
            if (comboBox2.SelectedIndex < 0)
            {
                errorProvider1.SetError(comboBox2, "the Items is required");
                errors = true;
            }
            if (textBox3.Text.Length <= 0)
            {
                errorProvider1.SetError(textBox3, "the quantity is required");
                errors = true;
            }
            data_loaded_prices();
            int index=dataGridView1.Rows.Count;
            //dataGridView1.Rows.Add(index+1,categories[comboBox1.SelectedIndex].title, Items[comboBox2.SelectedIndex].title,textBox3.Text,comboBox3.Text,textBox4.Text,comboBox4.Text,textBox5.Text,textBox7.Text,textBox8.Text,textBox2.Text,textBox6.Text);
            if (textBox4.Text.Length == 0)
                textBox4.Text = "0.0";
            if (textBox5.Text.Length == 0)
                textBox5.Text = "0.0";
            if (textBox2.Text.Length == 0)
                textBox2.Text = "0.0";
            if (textBox6.Text.Length == 0)
                textBox6.Text = "0.0";
            Bills.Add(index, new Classes.Bills(categories[comboBox1.SelectedIndex],Items[comboBox2.SelectedIndex],double.Parse(textBox4.Text),comboBox3.Text,double.Parse(textBox5.Text),comboBox4.Text,double.Parse(textBox2.Text),double.Parse(textBox6.Text),int.Parse(textBox3.Text)));
            reload_data_grid_view();
            clear_controls();
        }
        public void load_lang()
        {
            label3.Text = trans.get("categories");
            label4.Text = trans.get("items");
            label5.Text = trans.get("quantity");
            label6.Text = trans.get("sale");
            button1.Text = trans.get("add");
            button2.Text = trans.get("delete");
            groupBox2.Text = trans.get("bill_info");
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void load_items_categoris()
        {
             
        }
        private void load_categories() 
        {
            mapper = new controllers.mapper();
            string[] select = new string[] { };
            BindingSource BS = mapper.select("[category]", select, "").get();
            int index = 0;
            foreach(DataRowView drv in BS)
            {
               categories.Add(index,new Classes.category(int.Parse(drv[0].ToString()),drv[1].ToString()));
               comboBox1.Items.Add(drv[1].ToString());
               index++;
            }
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Items.Clear();
            comboBox2.Items.Clear();
            int selected_category = 0;
            if (comboBox1.SelectedIndex >= 0)
            {
                selected_category = categories[comboBox1.SelectedIndex].id;
            }
            if(selected_category<=0)
            {
                return;
            }
            controllers.Items items = new controllers.Items();
            BindingSource bs=items.get_items_for_categories(selected_category);
            int index = 0;
            foreach (DataRowView drv in bs)
            {
                Items.Add(index, new Classes.Items(int.Parse(drv[0].ToString()), drv[1].ToString(),double.Parse(drv[2].ToString()),double.Parse(drv[3].ToString())));
                comboBox2.Items.Add(drv[1].ToString());
                index++;
            }

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            data_loaded_prices();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool error = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (comboBox3.SelectedIndex >= 0) 
            {
                error = false;
            }
            if (error)
                errorProvider1.SetError(comboBox3, "you must choose the type of sale");
            else
            {
                errorProvider1.Clear();
                data_loaded_prices();
            }
                
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool error = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if(comboBox4.SelectedIndex >= 0)
                error = false;
            if (error)
                errorProvider1.SetError(comboBox4, "you must choose the type of Tax");
            else
            {
                errorProvider1.Clear();
                data_loaded_prices();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                textBox7.Text = "";
                textBox8.Text = "";
                return;
            }
            Classes.Items item = Items[comboBox2.SelectedIndex];
            textBox7.Text = item.sales_price.ToString();
            textBox8.Text = item.regular_price.ToString();
            data_loaded_prices();
        }
        private void data_loaded_prices() 
        {
            Classes.Items item = Items[comboBox2.SelectedIndex];
            double price = 0.0;
            double discount_price = 0.0;
            double tax_price = 0.0;
            int qnt = 0;
            if (textBox3.Text.Length > 0)
            {
                qnt = int.Parse(textBox3.Text);
                price = qnt * item.sales_price;
            }
            if (textBox4.Text.Length > 0)
            {
                if (comboBox3.SelectedIndex >= 0 && comboBox3.SelectedIndex == 0)
                {
                    discount_price =(price * (double.Parse(textBox4.Text) / 100));
                }
                else if (comboBox3.SelectedIndex >= 0 && comboBox3.SelectedIndex == 1)
                {
                    discount_price = (price-double.Parse(textBox4.Text));
                }
                else
                {
                    MessageBox.Show("error have been habbend in the sales");
                    return;
                }
                textBox2.Text = discount_price.ToString();
            }
            if (textBox5.Text.Length > 0)
            {
                if (comboBox4.SelectedIndex >= 0 && comboBox4.SelectedIndex == 0)
                {
                    tax_price = price * (double.Parse(textBox5.Text) / 100);
                }
                else if (comboBox4.SelectedIndex >= 0 && comboBox4.SelectedIndex == 1)
                {
                    tax_price =double.Parse(textBox5.Text);
                }
                else
                {
                    MessageBox.Show("error have been habbend in the tax");
                    return;
                }
            }
            if (textBox2.Text.Length == 0)
                textBox2.Text = "0.0";
            textBox6.Text = ((price+tax_price)-discount_price).ToString();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear_controls();
        }
        private void clear_controls() {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
            int index = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())-1;
            Classes.category ca = Bills[index].category;
            Classes.Items it = Bills[index].item;
            double sale=Bills[index].sale;
            string sale_type = Bills[index].sale_type;
            double tax = Bills[index].tax;
            string tax_type = Bills[index].tax_type;
            double discount = Bills[index].discount;
            double total_price = Bills[index].total_price;
            foreach (KeyValuePair<int, Classes.category> ca_choose in categories)
            {
                if (ca_choose.Value.id == ca.id)
                {
                    comboBox1.SelectedIndex = ca_choose.Key;
                    break;
                }
            }
            foreach (KeyValuePair<int, Classes.Items> item_a in Items)
            {
                if (it.id == item_a.Value.id)
                {
                    comboBox2.SelectedIndex = item_a.Key;
                    break;
                }
            }
            if(sale>0.0)
            {
                textBox4.Text = sale.ToString();
            }
            if (sale_type.Length > 0)
            {
                switch (sale_type)
                {
                    case "%":
                        comboBox3.SelectedIndex = 0;
                        break;
                    case "$":
                        comboBox3.SelectedIndex = 1;
                        break;
                }
            }

            if (tax > 0.0)
            {
                textBox5.Text = tax.ToString();
            }
            if (tax_type.Length > 0)
            {
                switch (tax_type)
                {
                    case "%":
                        comboBox4.SelectedIndex = 0;
                        break;
                    case "$":
                        comboBox4.SelectedIndex = 1;
                        break;
                }
            }
            textBox2.Text = discount.ToString();
            textBox6.Text = total_price.ToString();
            textBox7.Text = it.sales_price.ToString();
            textBox8.Text = it.regular_price.ToString();
            textBox3.Text = Bills[index].quantity.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bool errors = false;
            if (comboBox1.SelectedIndex < 0)
            {
                errorProvider1.SetError(comboBox1, "the categories is required");
                errors = true;
            }
            if (comboBox2.SelectedIndex < 0)
            {
                errorProvider1.SetError(comboBox2, "the Items is required");
                errors = true;
            }
            if (textBox3.Text.Length <= 0)
            {
                errorProvider1.SetError(textBox3, "the quantity is required");
                errors = true;
            }
            int index = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) - 1;
            data_loaded_prices();
            //BindingSource Bill_item = new BindingSource();
            //DataGridViewRow newDataRow = dataGridView1.Rows[index];
            //newDataRow.Cells[0].Value = index + 1;
            //newDataRow.Cells[1].Value = categories[comboBox1.SelectedIndex].title;
            //newDataRow.Cells[2].Value = Items[comboBox2.SelectedIndex].title;
            //newDataRow.Cells[3].Value = textBox3.Text;
            //newDataRow.Cells[4].Value = comboBox3.Text;
            //newDataRow.Cells[5].Value = textBox4.Text;
            //newDataRow.Cells[6].Value = comboBox4.Text;
            //newDataRow.Cells[7].Value = textBox5.Text;
            //newDataRow.Cells[8].Value = textBox7.Text;
            //newDataRow.Cells[9].Value = textBox8.Text;
            //newDataRow.Cells[10].Value = textBox2.Text;
            //newDataRow.Cells[11].Value = textBox6.Text;
            if (textBox4.Text.Length == 0)
                textBox4.Text = "0.0";
            if (textBox5.Text.Length == 0)
                textBox5.Text = "0.0";
            if (textBox2.Text.Length == 0)
                textBox2.Text = "0.0";
            if (textBox6.Text.Length == 0)
                textBox6.Text = "0.0";
            Bills[index]=new Classes.Bills(
                categories[comboBox1.SelectedIndex],
                Items[comboBox2.SelectedIndex],
                double.Parse(textBox4.Text),
                comboBox3.Text,
                double.Parse(textBox5.Text),
                comboBox4.Text,
                double.Parse(textBox2.Text),
                double.Parse(textBox6.Text),
                int.Parse(textBox3.Text)
                );
            reload_data_grid_view();
            clear_controls();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) - 1;
            Bills.Remove(index);
            dataGridView1.Rows.RemoveAt(index);
            refactor();
        }
        private void refactor() 
        {
           Dictionary<int, Classes.Bills> Bind_Bills = new Dictionary<int, Classes.Bills>();
           BindingSource bs = new BindingSource();
           int index = 0;
           foreach(KeyValuePair<int,Classes.Bills> bill in Bills)
           {
               Bind_Bills.Add(index, new Classes.Bills(bill.Value.category,bill.Value.item,bill.Value.sale,bill.Value.sale_type,bill.Value.tax,bill.Value.tax_type,bill.Value.discount,bill.Value.total_price,bill.Value.quantity));
               object bind_item = new
               {
                   number = index + 1,
                   category = bill.Value.category.title,
                   item_name = bill.Value.item.title,
                   quantity = bill.Value.quantity,
                   sale_type = bill.Value.sale_type,
                   sale_value = bill.Value.sale,
                   tax_type = bill.Value.tax_type,
                   tax_value = bill.Value.tax,
                   sale_price = bill.Value.item.sales_price,
                   regulare_price = bill.Value.item.regular_price,
                   price_discount = bill.Value.discount,
                   total = bill.Value.total_price
               };
               bs.Add(bind_item);
               index++;
           }
           if (index == 0)
           {
            //   bs.Add(bind_item);
           }
           if (index > 0)
           {
               dataGridView1.Rows.Clear();
               dataGridView1.Columns.Clear();
               dataGridView1.DataSource = bs;
               dataGridView1.Update();
               dataGridView1.Refresh();
           }
           Bills.Clear();
           Bills =new Dictionary<int,Classes.Bills>(Bind_Bills);
        }
        private void reload_data_grid_view() {
            int index = 0;
            BindingSource bs = new BindingSource();
            foreach (KeyValuePair<int, Classes.Bills> bill in Bills)
            {
                object bind_item = new
                {
                    number = index + 1,
                    category = bill.Value.category.title,
                    item_name = bill.Value.item.title,
                    quantity = bill.Value.quantity,
                    sale_type = bill.Value.sale_type,
                    sale_value = bill.Value.sale,
                    tax_type = bill.Value.tax_type,
                    tax_value = bill.Value.tax,
                    sale_price = bill.Value.item.sales_price,
                    regulare_price = bill.Value.item.regular_price,
                    price_discount = bill.Value.discount,
                    total = bill.Value.total_price
                };
                bs.Add(bind_item);
                index++;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = bs;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Recipts.CrystalReport1 cr = new Recipts.CrystalReport1();
            //BindingSource bs = new BindingSource();
            //foreach (KeyValuePair<int, Classes.Bills> bill in Bills)
            //{
            //    object bind_item = new
            //    {
            //        id = bill.Value.item.id,
            //        category = bill.Value.category.title,
            //        name = bill.Value.item.title,
            //        count = bill.Value.quantity,
            //        //sale_type = bill.Value.sale_type,
            //        //sale_value = bill.Value.sale,
            //        //tax_type = bill.Value.tax_type,
            //        //tax_value = bill.Value.tax,
            //        price = bill.Value.item.sales_price,
            //        //regulare_price = bill.Value.item.regular_price,
            //        //price_discount = bill.Value.discount,
            //        //total = bill.Value.total_price
            //        total = bill.Value.total_price
            //    };
            //    bs.Add(bind_item);
            //}
            //cr.ReportSource = bs;
            //
            //cr.SetDataSource(bs);
        }
    }
}
