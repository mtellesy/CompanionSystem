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
    }
}
