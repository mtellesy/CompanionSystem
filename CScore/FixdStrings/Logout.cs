using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Logout
    {
        public static String LogutLabel()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل الخروج";
                case (Language.EN):
                default: return "Logout";
            }
        }
        public static String LogutMessageTitle()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل الخروج";
                case (Language.EN):
                default: return "User Logout";
            }
        }

        public static String LogutMessageContent()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "هل أنت متأكد؟";
                case (Language.EN):
                default: return "Logout?";
            }
        }
    }
}
