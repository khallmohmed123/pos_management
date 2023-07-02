using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_management_system
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Customers.Customer());
            MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            //Application.Run(new Forms.users());
            //Application.Run(new Form1());
        }
    }
}
