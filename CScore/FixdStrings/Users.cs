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
                default: return "User doesn't exist";
            }
        }

        public static String PleaseTypeUsername()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "قم بكتابة إسم المستخدم";

                case (Language.EN):
                default: return "Type the user name";
            }
        }
        public static String UserOrPasswordNotCurrect()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "رقم مستخدم او كلمة المرور غير صحيحة";

                case (Language.EN):
                default: return "User id or Password is not Currect";
            }
        }
    }
}
