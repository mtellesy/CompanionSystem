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
    }
}
