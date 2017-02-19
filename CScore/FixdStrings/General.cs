using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
    public class General
    {
        /// <summary>
        /// String for "Status" word
        /// </summary>
        /// <returns></returns>
        public static String Status()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الحالة";
                case (Language.EN):
                default: return "Status";
            }
        }
        public static String Youve()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لديك ";

                case (Language.EN):
                default: return "You've ";
            }
        }
        public static String Name()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإسم";
                case (Language.EN):
                default: return "Name";
            }
        }
        public static String Error()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "خطأ";
                case (Language.EN):
                default: return "Error";
            }
        }
        public static String notAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "غير متوفر";
                case (Language.EN):
                default: return "Not Available";
            }
        }
        public static String sent()
{
Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المرسلة";
                case (Language.EN):
                default: return "sent";
            }
}
        public static String CantReachTheServer()

        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
case (Language.AR): return "لا يمكن الوصول الى الخادم!";
                case (Language.EN):
                default: return "Can't Reach The Server!";
                
            }
        }
        

                
public static String recieved()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المستلمة";
                case (Language.EN):
                default: return "recieved";
            }
        }

    }
}
