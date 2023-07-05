using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace pos_management_system.controllers
{
    class mapper
    {
        private string string_connections = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\context\\pos_management.mdf;Integrated Security=True";
        private string str_comand = "";
        private string command_type = "anything";
        private SqlDataAdapter da;
        private SqlConnection conn;
        BindingSource bsource = new BindingSource();
        DataSet ds = null;
        SqlCommand cmd;
        public mapper()
        {
            conn = new SqlConnection(string_connections);
            this.conn.Open();
        }
        public mapper select(string from,string [] params_data,string conds) 
        {
            this.str_comand = " SELECT ";
            this.str_comand += String.Join(" , ", params_data);
            if (params_data.Length < 1)
            {
                this.str_comand += " * ";
            }
            this.str_comand += " FROM " + from;
            this.str_comand += " " + conds;
            this.da = new SqlDataAdapter(str_comand, conn);
            this.command_type = "select";
            return this;
        }
        public mapper insert(string into, string [] passed_params,string [] bind_params) 
        {
            this.str_comand = "INSERT INTO " + into;
            if(passed_params.Length>0)this.str_comand+=" ("+String.Join(" , ", passed_params)+") ";
            this.str_comand += " values ";
            if (bind_params.Length>0)this.str_comand += " ( " + String.Join(" , ", bind_params)+" ) ";
            this.cmd = new SqlCommand(this.str_comand, this.conn);
            return this;
        }
        public mapper add_bind_values(string bind_variable,string bind_value) 
        {
            if (this.command_type != "select")
                this.cmd.Parameters.AddWithValue(bind_variable, bind_value);
            else
                this.da.SelectCommand.Parameters.AddWithValue(bind_variable, bind_value);
            return this;
        }
        public int ExecuteNonQuery() 
        {
            try
            {
                this.cmd.ExecuteNonQuery();
                this.conn.Dispose();
                this.conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }
        public mapper delete(string from, string where)
        {
            this.str_comand = "DELETE FROM " + from;
            if(where.Length>0)
            {
                this.str_comand += " WHERE " + where;
            }
            this.cmd = new SqlCommand(this.str_comand, this.conn);
            return this;
        }
        public mapper update(string table,string set,string where)
        {
            this.str_comand = "UPDATE " + table + " SET " + set + " WHERE " + where;
            this.cmd = new SqlCommand(this.str_comand, this.conn);
            return this;
        }
        public BindingSource get()
        {
            
            ds = new DataSet();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.Fill(ds, "Bind");
            bsource.DataSource = ds.Tables["Bind"];
            conn.Close();
            return bsource;
        }
    }
}
