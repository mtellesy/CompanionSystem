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
                case (Language.AR): return "قم بإختيار أحد الأقسام أولاً";
                case (Language.EN):
                default: return "Please choose a department first";
            }
        }

        public static String MajorStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة عملية التخصص";
                case (Language.EN):
                default: return " Major Status";
            }
        }

        public static String SorryMajorisNotAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عذراً, التخصص غير متاح";
                case (Language.EN):
                default: return "Sorry Major is Not Available";
            }
        }

        public static String MajorisAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التخصص متاح";
                case (Language.EN):
                default: return "Major is Available";
            }
        }

        public static String YouHaveBeenSuccessfullyMajored()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تمت عملية التخصص بنجاح";
                case (Language.EN):
                default: return "You Have Been Successfully Majored";
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
                case (Language.AR): return "التخصص في الأقسام متاح الأن";
                case (Language.EN):
                default: return "Major is now Available";
            }
        }
    }
           
    }

