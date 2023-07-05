using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Layout
{
    public partial class Layout : Forms.BaseClass.BaseForm
    {
        private controllers.translator trans;
        public Layout()
        {
            InitializeComponent();
            trans = new controllers.translator();
            this.load_lang_default();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }   
        }
        public void load_lang_default()
        {
            groupBox1.Text = trans.get("advanced_search");
            label1.Text = trans.get("search");
        }

    }
}
