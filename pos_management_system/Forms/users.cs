using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace pos_management_system.Forms
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name=textBox1.Text;
            string username=textBox2.Text;
            string email=textBox3.Text;
            string pass=textBox4.Text;
            string role=textBox5.Text;
            string command = "INSERT INTO [dbo].[User] (name,user_name,email,password,role) values(@name,@username,@email,@password,@role)";
             string string_connections="Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\pos_management.mdf;Integrated Security=True";
             using (SqlConnection conn = new SqlConnection(string_connections))
             {
                 conn.Open();
                 SqlCommand cmd = new SqlCommand(command, conn);
                 cmd.Parameters.AddWithValue("@name", name);
                 cmd.Parameters.AddWithValue("@username", username);
                 cmd.Parameters.AddWithValue("@email", email);
                 cmd.Parameters.AddWithValue("@password", pass);
                 cmd.Parameters.AddWithValue("@role", role);
                 int affectedRows = cmd.ExecuteNonQuery();
             }
        }
    }
}
