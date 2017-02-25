using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class FixedResponses
    {
     

        public static String getResponse(int code)
        {
            CScore.FixdStrings.Language e = FixdStrings.LanguageSetter.getLanguage();
            switch(e)
            {
                case (FixdStrings.Language.AR):
                    switch (code)
                    {
                        case 403:
                            return "مستخدم غير مصرح";
                        case 500:
                            return "خطأ مجهول السبب";
                        case 0:
                            return "خطأ بالنظام";
                        case 1:
                            return "لا يمكن الوصول إلى الخادم, تحقق من اتصالك بالإنترنت";
                        case 2:
                            return "رجاءً قم بإستبدال كلمة السر خاصتك";
                        default:
                            return "خطأ";

                    }
                case (FixdStrings.Language.EN):
                default:
                     switch (code)
                    {
                        case 403:
                            return "User is not autherized";
                        case 500:
                            return "Unknown Error";
                        case 0:
                            return "System ERROR!";
                        case 1:
                            return "Can't reach the Server.Please check your Internet connection";
                        case 2:
                            return "Please Change your Password";
                        default:
                            return "Error";

                    }

            }
           
        }
        
    }
}
