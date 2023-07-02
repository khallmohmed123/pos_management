using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pos_management_system.controllers
{
    class Helper
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private controllers.translator trans;
        public Helper() {
            trans = new controllers.translator();
        }
        public void Exit_app() 
        {
            if (MessageBox.Show(trans.get("exit_app"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void move(IntPtr Handle, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public void load_layout(Form controler) 
        {
            if (controllers.translator.lang == "ar")
            {
                controler.RightToLeft = RightToLeft.Yes;
                controler.RightToLeftLayout = true;
                foreach (Control b in controler.Controls)
                {
                    b.RightToLeft = RightToLeft.Yes;
                }
            }
            else
            {
                controler.RightToLeft = RightToLeft.No;
                controler.RightToLeftLayout = false;
                foreach (Control b in controler.Controls)
                {
                    b.RightToLeft = RightToLeft.No;
                }
            }
        }
        public void maximize(Form form) 
        {
            if (form.WindowState == FormWindowState.Maximized)
                form.WindowState = FormWindowState.Normal;
            else
                form.WindowState = FormWindowState.Maximized;
        }
        public void minimized(Form form) {
            form.WindowState = FormWindowState.Minimized;
        }
    }
}
