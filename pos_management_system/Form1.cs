using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system
{
    public partial class Form1 : Form
    {
        private controllers.translator trans;
        private controllers.Helper Helper;
        controllers.mapper mapper;
        public Form1()
        {
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            mapper = new controllers.mapper();
            InitializeComponent();
            load_lang();
            load_layout();
        }
        private void btnen_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "en";
            load_lang();
            load_layout();
        }
        private void btnar_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "ar";
            load_lang();
            load_layout();
        }
        private void load_lang() {
            txtusername.Text = trans.get("username");
            txtpass.Text = trans.get("password");
            btnlogin.Text = trans.get("login");
            btnclose.Text = trans.get("close");
            label1.Text = trans.get("login");
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Helper.Exit_app();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string[] select = new string[] { };
            mapper.select("[User]",select,"WHERE user_name=@email and passsword=@pass");
            mapper.add_bind_values("@email", textBox1.Text);
            mapper.add_bind_values("@pass", textBox2.Text);
            BindingSource ds = mapper.get();
            if (ds.Count == 1)
            {
                DataTable dt =(DataTable)ds.DataSource;
                foreach(DataRow row in dt.Rows){
                    controllers.User.id = int.Parse(row["id"].ToString());
                    controllers.User.name = row["name"].ToString();
                    controllers.User.email = row["email"].ToString();
                    controllers.User.user_name = row["user_name"].ToString();
                    controllers.User.role = trans.get("user_type_" + row["role"].ToString());
                    controllers.User.role_db = int.Parse(row["role"].ToString());
                }
                this.Hide();
                Forms.Home.Home home = new Forms.Home.Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("");
            }
        }
        private void load_layout() {
            Helper.load_layout(this);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }   
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }   
        }
    }
}
