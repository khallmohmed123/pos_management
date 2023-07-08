using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Categories
{
    public partial class Categories : Forms.Layout.Layout
    {
        controllers.mapper mapper;
        controllers.translator trans;
        private controllers.Helper Helper;
        private string tablename;
        public Categories()
        {
            InitializeComponent();
            this.tablename = "[category]";
            Helper = new controllers.Helper();
            notifyIcon1.Icon = SystemIcons.Application;
            trans = new controllers.translator();
            load_lang();
            Helper.load_layout(this);
            load_categories();
            
        }
        public void load_lang()
        {
            label2.Text = trans.get("id");
            label3.Text = trans.get("name");
            button1.Text = trans.get("create_new");
            button3.Text = trans.get("update");
            button2.Text = trans.get("delete");
            button4.Text = trans.get("cancel");
        }
        public override BaseClass.BaseForm get_instance()
        {
            return new Categories();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value.ToString().Length == 0)
            {
                return;
            }
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = id;
            textBox3.Text = name;
            button1.Enabled = false;
            button3.Enabled = true;
            button2.Enabled = true;
        }
        public void load_categories()
        {
            mapper = new controllers.mapper();
            string[] select = new string[] { };
            dataGridView1.DataSource = mapper.select(this.tablename, select, "").get();
            button3.Enabled = false;
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            mapper = new controllers.mapper();
            string[] bind_params = new string[] { "title"};
            string[] bind_values = new string[] { "@title" };
            int affectedRows = mapper.insert(this.tablename, bind_params, bind_values)
            .add_bind_values("@title", name)
            .ExecuteNonQuery();
            if (affectedRows > 0)
            {
                MessageBox.Show(trans.get("success_category_added"));
                notifyIcon1.ShowBalloonTip(3000, "message", trans.get("success_customer_added"), ToolTipIcon.Info);
            }
            load_categories();
            clear_controls();
        }
        private void clear_controls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            button1.Enabled = true;
            button3.Enabled = false;
            button2.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear_controls();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mapper = new controllers.mapper();
            string id = textBox2.Text;
            if (id.Length == 0)
            {
                MessageBox.Show("");
                return;
            } 
            mapper.delete(this.tablename, "id = @id");
            mapper.add_bind_values("@id", id);
            int deleted = mapper.ExecuteNonQuery();
            MessageBox.Show(deleted.ToString());
            load_categories();
            clear_controls();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string name = textBox3.Text;
            mapper = new controllers.mapper();
            string set = "title=@title";
            string where = "id=@id";
            mapper.update(this.tablename, set, where);
            mapper.add_bind_values("@title", name);
            mapper.add_bind_values("@id", id);
            int updated=mapper.ExecuteNonQuery();
            if (updated > 0)
            {
                MessageBox.Show("updated successfully");
            }
            else
            {
                MessageBox.Show("error occurs");
            }
            load_categories();
            clear_controls();
        }
    }
}
