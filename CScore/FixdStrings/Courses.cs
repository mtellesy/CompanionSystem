using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Courses
    {
        public static String CourseCode()
        {
            Language e = LanguageSetter.getLanguage();
            switch(e)
            {
                case (Language.AR): return "رمز المادة";

                case (Language.EN):
                default: return "Course Code";
            }
        }

        public static String CourseDoesNotExist()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المادة غير موجودة";

                case (Language.EN):
                default: return "Course does not exist";
            }
        }

        public static String PleaseTypeCourseCode()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "رجاءً, قم بكتابة رمز المادة";

                case (Language.EN):
                default: return "Please, Type the course code";
            }
        }
    }
}
