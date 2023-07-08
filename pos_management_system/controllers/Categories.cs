using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_management_system.controllers
{
    class Categories
    {
        controllers.mapper mapper;
        private string tablename;
        public Categories() {
            mapper = new mapper();
            this.tablename = "[category]";
        }
        public System.Windows.Forms.BindingSource allCategoris()
        {
            mapper = new controllers.mapper();
            string[] select = new string[] { };
            return mapper.select(this.tablename, select, "").get();
        }
        public System.Windows.Forms.BindingSource get_by_id(int id) {
            mapper = new controllers.mapper();
            string[] select = new string[] { };
            return mapper.select(this.tablename, select, " WHERE id="+id).get();
        }
    }
}
