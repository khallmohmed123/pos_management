using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace pos_management_system.Forms.Customers
{
    public partial class Customer : Forms.Layout.Layout
    {
        controllers.mapper mapper;
        controllers.translator trans;
        private controllers.Helper Helper;
        public Customer()
        {
            controllers.translator.lang ="ar";
            Helper = new controllers.Helper();
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Application;
            trans = new controllers.translator();
            load_customers();
            load_lang();
            Helper.load_layout(this);
        }
        public void load_customers() {
            mapper = new controllers.mapper();
            string[] select = new string[]{};
            dataGridView1.DataSource = mapper.select("[Customers]", select, "").get();
            button3.Enabled = false;
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string email = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string address = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string phone = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = id;
            textBox3.Text = name;
            textBox4.Text = email;
            textBox5.Text = address;
            textBox6.Text = phone;
            button1.Enabled = false;
            button3.Enabled = true;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            mapper = new controllers.mapper();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
            string[] select = new string[] { };
            dataGridView1.DataSource = mapper.select("[Customers]", select, " WHERE name like '%" + textBox1.Text + "%' OR email like '%" + textBox1.Text + "%' OR address like '%" + textBox1.Text + "%' OR phone like '%" + textBox1.Text + "%' ").get();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear_controls();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mapper = new controllers.mapper();
            string name=textBox3.Text;
            string email=textBox4.Text; 
            string address=textBox5.Text;
            string phone=textBox6.Text;
            string[] bind_params = new string[] {"name","email","address","phone" };
            string[] bind_values = new string[] { "@name", "@email", "@address", "@phone" };
            int affectedRows = mapper.insert("[dbo].[Customers]", bind_params, bind_values)
            .add_bind_values("@name",name)
            .add_bind_values("@email",email)
            .add_bind_values("@address",address)
            .add_bind_values("@phone",phone)
            .ExecuteNonQuery();
            if (affectedRows > 0)
            {
                MessageBox.Show(trans.get("success_customer_added"));
                notifyIcon1.ShowBalloonTip(3000, "message", trans.get("success_customer_added"), ToolTipIcon.Info);
            }
            load_customers();
            clear_controls();
        }
        private void clear_controls() {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            button1.Enabled = true;
            button3.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string id=textBox2.Text;
            string name = textBox3.Text;
            string email = textBox4.Text;
            string address = textBox5.Text;
            string phone = textBox6.Text;
            mapper = new controllers.mapper();
            string set="name=@name,email=@email,address=@address,phone=@phone";
            string where="id=@id";
            mapper.update("[Customers]", set,where);
            mapper.add_bind_values("@name",name);
            mapper.add_bind_values("@email", email);
            mapper.add_bind_values("@address", address);
            mapper.add_bind_values("@phone", phone);
            mapper.add_bind_values("@id", id);
            mapper.ExecuteNonQuery();
            load_customers();
            clear_controls();
        }
        public void load_lang()
        {
            label2.Text = trans.get("id");
            label3.Text = trans.get("name");
            label4.Text = trans.get("email");
            label5.Text = trans.get("address");
            label6.Text = trans.get("phone");
            button1.Text = trans.get("create_new");
            button3.Text = trans.get("update");
            button4.Text = trans.get("cancel");
            groupBox2.Text = trans.get("customer_info");
        }
    }
}
