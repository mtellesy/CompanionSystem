using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Users
    {
        public static String UserDoesNotExist()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المستخدم غير موجود";

                case (Language.EN):
                default: return "User does not exist";
            }
        }

        public static String PleaseTypeUsername()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "رجاءً, قم بكتابة إسم المستخدم";

                case (Language.EN):
                default: return "Please, type the user name";
            }
        }
    }
}
