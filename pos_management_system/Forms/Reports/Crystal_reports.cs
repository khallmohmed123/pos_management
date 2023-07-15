using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system.Forms.Reports
{
    public partial class Crystal_reports : Form
    {
        public DataTable bill { set; get; }
        public Crystal_reports(DataTable bill)
        {
            InitializeComponent();
            this.bill = bill;
        }

        private void Crystal_reports_Load(object sender, EventArgs e)
        {
            Recipts.gENERATOR cr = new Recipts.gENERATOR();
            cr.Database.Tables["Bill"].SetDataSource(this.bill);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
