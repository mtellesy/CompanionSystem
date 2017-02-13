using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Major
    {
        public static String PleaseChooseAdepartmentFirst()
        {
            Language e = LanguageSetter.getLanguage();
            switch(e)
            {
                case (Language.AR): return "قم بإختيار أحد الأقسام ";
                case (Language.EN):
                default: return "Choose a department ";
            }
        }

        public static String MajorStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص";
                case (Language.EN):
                default: return " Major Status";
            }
        }

        public static String SorryMajorisNotAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص غير متاح";
                case (Language.EN):
                default: return "Major isn't available";
            }
        }

        public static String MajorisAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص متاح الآن";
                case (Language.EN):
                default: return "Major is available";
            }
        }

        public static String YouHaveBeenSuccessfullyMajored()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لقد قمت بالتخصص";
                case (Language.EN):
                default: return "You have majored!";
            }
        }

        public static String MajorStatusNotification()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة التخصص";
                case (Language.EN):
                default: return "Major Status";
            }
        }
        /// <summary>
        /// "Major is Available" message String 
        /// </summary>
        /// <returns></returns>
        public static String MajormentIsAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص  متاح الأن";
                case (Language.EN):
                default: return "Major is available";
            }
        }

        public static String MajorTitle()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص";
                case (Language.EN):
                default: return "Major";
            }
        }
    }
           
    }

