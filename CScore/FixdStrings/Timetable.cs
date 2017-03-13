using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Timetable
    {
        public static String Date()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "التاريخ";

                case (Language.EN):
                default: return "Date";
            }
        }

        public static String TermName()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إسم الفصل";

                case (Language.EN):
                default: return "Term name";
            }
        }

       


        public static String TermNameEN()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إسم الفصل (إنجليزية)";

                case (Language.EN):
                default: return "Term name (EN)";
            }
        }

        public static String Year()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "السنة";

                case (Language.EN):
                default: return "Year";
            }
        }

        public static String TermStart()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "بداية الفصل";

                case (Language.EN):
                default: return "Term start";
            }
        }

        public static String EnrollmentStart()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "بداية تسجيل المواد";

                case (Language.EN):
                default: return "Enrollment start";
            }
        }

        public static String DropStart()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إسقاط المواد";

                case (Language.EN):
                default: return "Courses disenrollment";
            }
        }

        public static String LastStudyDate()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "أخر يوم دراسي";

                case (Language.EN):
                default: return "Last study date";
            }
        }

        public static String TimetableLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الجدول الزمني";

                case (Language.EN):
                default: return "Timetable";
            }
        }

    }
}
