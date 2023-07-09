using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Users
{
    public partial class Users : Layout.Layout
    {
        controllers.mapper mapper;
        controllers.translator trans;
        private controllers.Helper Helper;
        private string tablename = "[User]";
        public Users()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Application;
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            load_lang();
            Helper.load_layout(this);
            load_users();
        }
        public override BaseClass.BaseForm get_instance()
        {
            return new Users();
        }
        private void load_lang() 
        {
            label2.Text = trans.get("id");
            label3.Text = trans.get("name");
            label4.Text = trans.get("email");
            label5.Text = trans.get("username");
            label6.Text = trans.get("role");
            label7.Text = trans.get("password");
            button1.Text = trans.get("create_new");
            button3.Text = trans.get("update");
            button4.Text = trans.get("cancel");
            button2.Text = trans.get("delete");
        }
        private void load_users() 
        {
            mapper = new controllers.mapper();
            string[] select = new string[] { };
            BindingSource user = mapper.select(this.tablename, select, "").get();
            BindingSource new_user=new BindingSource();
            foreach (DataRowView t in user)
            {
                string role="";
                if (int.Parse(t[4].ToString()) == 1)
                    role = trans.get("user_type_1");
                else
                    role = trans.get("user_type_0");
                object bind_user =new{
                    id = int.Parse(t[0].ToString()),
                    name=t[1].ToString(),
                    email=t[2].ToString(),
                    user_name=t[3].ToString(),
                    role = role,
                    password=t[5].ToString()
                };
                new_user.Add(bind_user);
            }
            dataGridView1.DataSource = new_user;
            dataGridView1.Columns[0].HeaderText = trans.get("id");
            dataGridView1.Columns[1].HeaderText = trans.get("name");
            dataGridView1.Columns[2].HeaderText = trans.get("email");
            dataGridView1.Columns[3].HeaderText = trans.get("username");
            dataGridView1.Columns[4].HeaderText = trans.get("role");
            dataGridView1.Columns[5].HeaderText = trans.get("password");
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string email = textBox4.Text;
            string user_name = textBox5.Text;
            int role=0;
            if (comboBox1.SelectedIndex >= 0)
                role=comboBox1.SelectedIndex;
            else
                MessageBox.Show("you should select the role");
            string password = textBox7.Text;
            mapper = new controllers.mapper();
            string[] bind_params = new string[] { "name", "email", "user_name", "role", "passsword" };
            string[] bind_values = new string[] { "@name", "@email", "@user_name", "@role", "@passsword" };
            int affectedRows = mapper.insert(this.tablename, bind_params, bind_values, true)
            .add_bind_values("@name", name)
            .add_bind_values("@email", email)
            .add_bind_values("@user_name", user_name)
            .add_bind_values("@role", role.ToString())
            .add_bind_values("@passsword", password)
            .ExecuteNonQuery();
            if (affectedRows <= 0)
            {
                MessageBox.Show("doesn't inserted");
                return;
            }
            notifyIcon1.ShowBalloonTip(3000, "message", trans.get("success_customer_added"), ToolTipIcon.Info);
            clear_controls();
            load_users();
        }
        private void clear_controls() 
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string email = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string user_name = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string role = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string password = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = id;
            textBox3.Text = name;
            textBox4.Text = email;
            textBox5.Text = user_name;
            textBox7.Text = password;
            if (role == trans.get("user_type_1"))
            {
                comboBox1.SelectedIndex = 1;
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
            button3.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mapper = new controllers.mapper();
            if (id.Length == 0)
            {
                MessageBox.Show("");
                return;
            }
            mapper.delete(tablename, "id = @id");
            mapper.add_bind_values("@id", id);
            int deleted = mapper.ExecuteNonQuery();
            if(deleted<=0)
            {
                MessageBox.Show("error on delete");
            }
            notifyIcon1.ShowBalloonTip(3000, "message", trans.get("success_customer_added"), ToolTipIcon.Info);
            load_users();
            clear_controls();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            mapper = new controllers.mapper();
            string id = textBox2.Text;
            string name = textBox3.Text;
            string email = textBox4.Text;
            string user_name = textBox5.Text;
            int role = 0;
            if (comboBox1.SelectedIndex >= 0)
                role = comboBox1.SelectedIndex;
            else
            {
                MessageBox.Show("you should select the role");
                return;
            }
            string password = textBox7.Text;
            string set = "name=@name,email=@email,user_name=@user_name,role=@role";
            string where = "id=@id";
            mapper.update(this.tablename, set, where);
            mapper.add_bind_values("@name", name);
            mapper.add_bind_values("@email", email);
            mapper.add_bind_values("@user_name", user_name);
            mapper.add_bind_values("@role", role.ToString());
            mapper.add_bind_values("@id", id);
            mapper.ExecuteNonQuery();
            notifyIcon1.ShowBalloonTip(3000, "message", trans.get("success_customer_added"), ToolTipIcon.Info);
            load_users();
            clear_controls();
        }
    }
}
