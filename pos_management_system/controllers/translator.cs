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
        Dictionary<string, language> multilang = new Dictionary<string, language>();
        public static string lang = "en";
        public translator()
        {
            multilang.Add("login", new language("تسجيل الدخول", "Login", "авторизоваться", "Connexion"));
            multilang.Add("close", new language("الخروج", "close", "закрывать", "fermer"));
            multilang.Add("username", new language("اسم المستخدم", "User Name", "имя пользователя", "Nom d'utilisateur"));
            multilang.Add("password", new language("كلمه المرور", "Pass Word", "пароль", "Mot de passe"));
            multilang.Add("exit_app", new language("هل تريد فعلا الخروج من هذا التطبيق ؟", "are you need to exit this application ?", "вам нужно выйти из этого приложения ?", "devez-vous quitter cette application ?"));
            multilang.Add("home", new language("الصفحه الرئيسيه", "home", "дом", "maison"));
            multilang.Add("customers", new language("العملاء", "customers", "клиенты", "clients"));
            multilang.Add("all", new language("الكل", "all", "все", "tout"));
            multilang.Add("new", new language("جديد", "new", "новый", "Nouveau"));
            multilang.Add("update", new language("تعديل", "update", "обновлять", "mise à jour"));
            multilang.Add("delete", new language("مسح", "delete", "удалить", "supprimer"));
            multilang.Add("items", new language("منتجات", "items", "предметы", "articles"));
            multilang.Add("bills", new language("فواتير", "bills", "счета", "factures"));
            multilang.Add("users", new language("مستخدمون", "users", "пользователи", "utilisateurs"));
            multilang.Add("language", new language("اللغه", "language", "язык", "langue"));
            multilang.Add("success_customer_added", new language("تم إضافه العميل بنجاح", "add customer successfully", "успешно добавить клиента", "ajouter un client avec succès"));
            multilang.Add("id", new language("الرقم التعريفي", "id", "идентификатор", "identifiant"));
            multilang.Add("create_new", new language("إضافه جديد", "create new", "создавать новое", "créer un nouveau"));
            multilang.Add("cancel", new language("الغاء", "cancel", "отмена", "Annuler"));
            multilang.Add("name", new language("الاسم", "name", "имя", "nom"));
            multilang.Add("email", new language("البريد الاكتروني", "email", "электронная почта", "e-mail"));
            multilang.Add("address", new language("العنوان", "address", "адрес", "adresse"));
            multilang.Add("phone", new language("الهاتف", "phone", "телефон", "téléphone"));
            multilang.Add("customer_info", new language("بيانات العميل", "Customer Info", "Информация о клиенте", "informations concernant le client"));
            multilang.Add("user_type_0", new language("مستخدم", "user", "пользователь", "utilisateur"));
            multilang.Add("user_type_1", new language("مدير", "adminsitrator", "администратор", "administrateur"));
            multilang.Add("search", new language("بحث", "search", "поиск", "recherche"));
            multilang.Add("advanced_search", new language("البحث المتطور", "Advanced Search", "Расширенный поиск", "Recherche Avancée"));
            multilang.Add("categories", new language(" التصنيفات ", "Categories", "Категории", "Catégories"));
            multilang.Add("success_category_added", new language(" تم إضافه الفئه بنجاح ", "add category successfully", "успешно добавить категорию", "ajouter une catégorie avec succès"));
            multilang.Add("sales_price", new language("سعر المبيعات", "sales price", "продажная цена", "prix de vente"));
            multilang.Add("regular_price", new language("سعر عادي", "regular price", "обычная цена", "prix habituel"));
            multilang.Add("category", new language("فئة", "category", "категория", "catégorie"));
            multilang.Add("role", new language("دور", "role", "роль", "rôle"));
            multilang.Add("items_info", new language("معلومات العناصر", "Items Info", "Информация о предметах", "Informations sur les articles"));
        }
        public string get(string value) 
        {
            if(is_key_exists(multilang,value))
            {
                switch (lang)
                {
                    case "en":
                        return multilang[value].en;
                        break;
                    case "ar":
                        return multilang[value].ar;
                        break;
                    case "fr":
                        return multilang[value].fr;
                        break;
                    case "ru":
                        return multilang[value].ru;
                        break;
                }
            }
            return value;
        }
        private bool is_key_exists(Dictionary<string, language> lan,string key){
            return lan.ContainsKey(key);
        }
    }
}
