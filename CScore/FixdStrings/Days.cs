using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Days
    {
        public static String SAT()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "سبت";
                case (Language.EN):
                default: return "SAT";
            }
        }

        public static String SUN()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "أحد";
                case (Language.EN):
                default: return "SUN";
            }
        }

        public static String MON()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إثنين";
                case (Language.EN):
                default: return "MON";
            }
        }

        public static String TUE()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "ثلاثاء";
                case (Language.EN):
                default: return "TUE";
            }
        }

        public static String WED()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إربعاء";
                case (Language.EN):
                default: return "WED";
            }
        }

        public static String THU()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "خميس";
                case (Language.EN):
                default: return "THU";
            }
        }

        public static String DandH()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "ي\\س";
                case (Language.EN):
                default: return "D//H";
            }
        }
    }
}
