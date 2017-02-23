using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
    public class Buttons
    {
        /// <summary>
        /// String for "OK" word
        /// </summary>
        /// <returns></returns>
        public static String OK()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "موافق";
                case (Language.EN):
                default: return "OK";
            }
        }
        /// <summary>
        /// String for "YES" word
        /// </summary>
        /// <returns></returns>
        public static String YES()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "نعم";
                case (Language.EN):
                default: return "YES";
            }
        }
        /// <summary>
        /// String for "YES" word
        /// </summary>
        /// <returns></returns>
        public static String NO()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لا";
                case (Language.EN):
                default: return "NO";
            }
        }
        /// <summary>
        /// String for "EXIT" word
        /// </summary>
        /// <returns></returns>
        public static String EXIT()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "خروج";
                case (Language.EN):
                default: return "EXIT";
            }
        }
        /// <summary>
        /// String for "DONE" word
        /// </summary>
        /// <returns></returns>
        public static String DONE()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إنهاء";
                case (Language.EN):
                default: return "DONE";
            }
        }
    }
}
