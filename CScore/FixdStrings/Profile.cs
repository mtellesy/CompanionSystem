using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Profile
    {
        public static String ProfileLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الصفحة الشخصية";

                case (Language.EN):
                default: return "Profile";
            }
        }

        public static String UserNameinAR()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإسم بالعربية";

                case (Language.EN):
                default: return "User name in Arabic";
            }
        }
        public static String UserNameinEN()
        { 
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإسم بالإنجليزية";

                case (Language.EN):
                default: return "User name in English";
            }
        }
        public static String UserEmail()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "البريد الإلكتروني";

                case (Language.EN):
                default: return "Email";
            }
        }
        public static String UserPhone()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "رقم الهاتف";

                case (Language.EN):
                default: return "Phone Number";
            }
        }
        public static String UserDepartment()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "القسم";

                case (Language.EN):
                default: return "Department";
            }
        }

        public static String UserUnits()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الوحدات المنجزة";

                case (Language.EN):
                default: return "Units completed";
            }
        }

        public static String UserGPA()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المعدل العام";

                case (Language.EN):
                default: return "GPA";
            }
        }

        public static String UserNotices()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عدد الإنذارات";

                case (Language.EN):
                default: return "Number of notices";
            }
        }
        public static String currentSemester()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الفصل الحالي";

                case (Language.EN):
                default: return "Current semeter";
            }
        }
        public static String personalTab()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "شخصي";

                case (Language.EN):
                default: return "personal";
            }
        }
        public static String academicTab()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "أكاديمي";

                case (Language.EN):
                default: return "academic";
            }
        }
    }
}
