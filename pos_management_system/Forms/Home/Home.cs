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
        private BaseClass.BaseForm active_form;
        public Home()
        {
            active_form = new BaseClass.BaseForm();
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
            itemsToolStripMenuItem.Text = trans.get("items");
            allToolStripMenuItem.Text=trans.get("all");
            billsToolStripMenuItem.Text=trans.get("bills");
            allToolStripMenuItem1.Text=trans.get("all");
            usersToolStripMenuItem.Text=trans.get("users");
            allToolStripMenuItem2.Text=trans.get("all");
            languageToolStripMenuItem.Text = trans.get("language");
            createToolStripMenuItem.Text = trans.get("all");
            categoriesToolStripMenuItem.Text = trans.get("categories");
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
            Customers.Customer customer = new Customers.Customer();
            active_form = customer;
            Helper.AppendChildToFrame(this.panel3,customer);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories.Categories categories = new Categories.Categories();
            active_form = categories;
            Helper.AppendChildToFrame(this.panel3, categories);
        }

        private void عربيToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            controllers.translator.lang = "ar";
            load_lang();
            Helper.AppendChildToFrame(this.panel3, active_form.get_instance());
            load_layout();
        }

        private void englishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            controllers.translator.lang = "en";
            load_lang();
            Helper.AppendChildToFrame(this.panel3, active_form.get_instance());
            load_layout();
        }

        private void ruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "ru";
            load_lang();
            Helper.AppendChildToFrame(this.panel3, active_form.get_instance());
            load_layout();
        }

        private void frToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controllers.translator.lang = "fr";
            load_lang();
            Helper.AppendChildToFrame(this.panel3, active_form.get_instance());
            load_layout();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Helper.maximize(this);
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items.Items Items = new Items.Items();
            active_form = Items;
            Helper.AppendChildToFrame(this.panel3, Items);
        }

        private void allToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Users.Users Users = new Users.Users();
            active_form = Users;
            Helper.AppendChildToFrame(this.panel3, Users);
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bills.Bill Bill = new Bills.Bill();
            active_form = Bill;
            Helper.AppendChildToFrame(this.panel3, Bill);
        }
    }
}
