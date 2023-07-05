using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace pos_management_system.controllers
{
    class translator
    {
        IDictionary<string, KeyValuePair<string, string>> d = new Dictionary<string, KeyValuePair<string, string>>();
        IDictionary<string, language> multilang = new Dictionary<string, language>();
        public static string lang = "en";
        public translator() {
            d.Add("login", new KeyValuePair<string, string>("login", "تسجيل الدخول"));
            d.Add("close", new KeyValuePair<string, string>("close", "الخروج"));
            d.Add("username", new KeyValuePair<string, string>("User Name", "اسم المستخدم"));
            d.Add("password", new KeyValuePair<string, string>("Pass Word", "كلمه المرور"));
            d.Add("exit_app", new KeyValuePair<string, string>("are you need to exit this application ?", "هل تريد فعلا الخروج من هذا التطبيق ؟"));
            d.Add("home", new KeyValuePair<string, string>("home", "الصفحه الرئيسيه"));
            d.Add("customers", new KeyValuePair<string, string>("customers", "العملاء"));
            d.Add("all", new KeyValuePair<string, string>("all", "الكل"));
            d.Add("new", new KeyValuePair<string, string>("new", "جديد"));
            d.Add("update", new KeyValuePair<string, string>("update", "تعديل"));
            d.Add("delete", new KeyValuePair<string, string>("delete", "مسح"));
            d.Add("items", new KeyValuePair<string, string>("items", "منتجات"));
            d.Add("bills", new KeyValuePair<string, string>("bills", "فواتير"));
            d.Add("users", new KeyValuePair<string, string>("users", "مستخدمون"));
            d.Add("language", new KeyValuePair<string, string>("language", "اللغه"));
            d.Add("success_customer_added", new KeyValuePair<string, string>("add customer successfully", "تم إضافه العميل بنجاح"));
            d.Add("id", new KeyValuePair<string, string>("id", "الرقم التعريفي"));
            d.Add("create_new", new KeyValuePair<string, string>("create new", "إضافه جديد"));
            d.Add("cancel", new KeyValuePair<string, string>("cancel", "الغاء"));
            d.Add("name", new KeyValuePair<string, string>("name", "الاسم"));
            d.Add("email", new KeyValuePair<string, string>("email", "البريد الاكتروني"));
            d.Add("address", new KeyValuePair<string, string>("address", "العنوان"));
            d.Add("phone", new KeyValuePair<string, string>("phone", "الهاتف"));
            d.Add("customer_info", new KeyValuePair<string, string>("Customer Info", "بيانات العميل"));
            d.Add("user_type_0", new KeyValuePair<string, string>("user", "مستخدم"));
            d.Add("user_type_1", new KeyValuePair<string, string>("adminsitrator", "مدير"));
            d.Add("search", new KeyValuePair<string, string>("search", "بحث"));
            d.Add("advanced_search", new KeyValuePair<string, string>("Advanced Search", "البحث المتطور"));
            d.Add("categories", new KeyValuePair<string, string>("Categories", " التصنيفات "));

            multilang.Add("login",new language("تسجيل الدخول","Login","asaqw","Logine"));
            multilang.Add("close", new language("الخروج","close","asaqw","Logine"));
            multilang.Add("username",new language("اسم المستخدم","User Name","asaqw","Logine"));
            multilang.Add("password",new language("كلمه المرور","Pass Word","asaqw","Logine"));
            multilang.Add("exit_app", new language("هل تريد فعلا الخروج من هذا التطبيق ؟", "are you need to exit this application ?", "asaqw", "Logine"));
            multilang.Add("home",new language("الصفحه الرئيسيه","home","asaqw","Logine"));
            multilang.Add("customers",new language("العملاء","customers","asaqw","Logine"));
            multilang.Add("all", new language("الكل","all","asaqw","Logine"));
            multilang.Add("new",new language("جديد","new","asaqw","Logine"));
            multilang.Add("update",new language("تعديل","update","asaqw","Logine"));
            multilang.Add("delete",new language("مسح","delete","asaqw","Logine"));
            multilang.Add("items",new language("منتجات","items","asaqw","Logine"));
            multilang.Add("bills",new language("فواتير","bills","asaqw","Logine"));
            multilang.Add("users",new language("مستخدمون","users","asaqw","Logine"));
            multilang.Add("language",new language("اللغه","language","asaqw","Logine"));
            multilang.Add("success_customer_added",new language("تم إضافه العميل بنجاح","add customer successfully","asaqw","Logine"));
            multilang.Add("id", new language("الرقم التعريفي", "id", "asaqw", "Logine"));
            multilang.Add("create_new", new language("إضافه جديد", "create new", "asaqw", "Logine"));
            multilang.Add("cancel", new language("الغاء", "cancel", "asaqw", "Logine"));
            multilang.Add("name",new language("الاسم", "name", "asaqw", "Logine"));
            multilang.Add("email", new language("البريد الاكتروني", "email", "asaqw", "Logine"));
            multilang.Add("address",new language("العنوان", "address", "asaqw", "Logine"));
            multilang.Add("phone", new language( "الهاتف", "phone", "asaqw", "Logine"));
            multilang.Add("customer_info",new language(  "بيانات العميل", "Customer Info", "asaqw", "Logine"));
            multilang.Add("user_type_0", new language("مستخدم", "user", "asaqw", "Logine"));
            multilang.Add("user_type_1",new language("مدير", "adminsitrator", "asaqw", "Logine"));
            multilang.Add("search",new language( "بحث", "search", "asaqw", "Logine"));
            multilang.Add("advanced_search",new language("البحث المتطور", "Advanced Search", "asaqw", "Logine"));
            multilang.Add("categories",new language( " التصنيفات ", "Categories", "asaqw", "Logine"));
        }
        public string get(string value) 
        {
            if (lang == "en")
                return d[value].Key;
            return d[value].Value;
        }
    }
}
