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

        }
        public string get(string value) 
        {
            if (lang == "en")
                return d[value].Key;
            return d[value].Value;
        }
    }
}
