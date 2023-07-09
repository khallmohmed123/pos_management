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
        public Bill()
        {
            InitializeComponent();
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            load_lang();
            load_categories();
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
                MessageBox.Show("error on select category");
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
                errorProvider1.Clear();
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
                errorProvider1.Clear();
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
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
        }
    }
}
