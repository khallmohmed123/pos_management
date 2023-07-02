using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Home
{
    public partial class Home : Form
    {
        private controllers.Helper Helper;
        private controllers.translator trans;
        public Home()
        {
            trans = new controllers.translator();
            Helper = new controllers.Helper();
            InitializeComponent();
            load_layout();
            load_lang();
        }
        public void load_lang() 
        {
            homeToolStripMenuItem.Text = trans.get("home");
            customersToolStripMenuItem.Text = trans.get("customers");
            all2ToolStripMenuItem.Text = trans.get("all");
            updateToolStripMenuItem.Text = trans.get("update");
            deleteToolStripMenuItem.Text = trans.get("delete");
            newToolStripMenuItem1.Text = trans.get("new");
            itemsToolStripMenuItem.Text = trans.get("items");
            allToolStripMenuItem.Text=trans.get("all");
            newToolStripMenuItem2.Text=trans.get("new");
            updateToolStripMenuItem1.Text=trans.get("update");
            newToolStripMenuItem3.Text=trans.get("new");
            billsToolStripMenuItem.Text=trans.get("bills");
            allToolStripMenuItem1.Text=trans.get("all");
            updateToolStripMenuItem2.Text=trans.get("update");
            deleteToolStripMenuItem1.Text=trans.get("delete");
            newToolStripMenuItem4.Text=trans.get("new");
            usersToolStripMenuItem.Text=trans.get("users");
            allToolStripMenuItem2.Text=trans.get("all");
            deleteToolStripMenuItem2.Text=trans.get("delete");
            newToolStripMenuItem5.Text=trans.get("new");
            updateToolStripMenuItem3.Text = trans.get("update");
            languageToolStripMenuItem.Text = trans.get("language");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Helper.Exit_app();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            Helper.move(Handle, e);
        }
        private void load_layout()
        {
            Helper.load_layout(this);
        }
        private void عربيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "ar";
            load_lang();
            load_layout();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "en";
            load_lang();
            load_layout();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Helper.maximize(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Helper.minimized(this);
        }

        private void all2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
