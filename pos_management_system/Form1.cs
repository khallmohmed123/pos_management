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
        public Form1()
        {
            trans = new controllers.translator();
            Helper = new controllers.Helper();
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
            this.Hide();
            Forms.Home.Home home = new Forms.Home.Home();
            home.Show();
        }
        private void load_layout() {
            Helper.load_layout(this);
        }
    }
}
