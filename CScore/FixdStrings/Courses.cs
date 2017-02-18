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
        public static String CourseName()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إسم المادة";

                case (Language.EN):
                default: return "Course Name";
            }
        }
        public static String CourseDoesNotExist()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المادة غير موجودة";

                case (Language.EN):
                default: return "Course does't exist";
            }
        }

        public static String PleaseTypeCourseCode()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "قم بكتابة رمز المادة";

                case (Language.EN):
                default: return "Type the course code";
            }
        }

        public static String MyCoursesLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "موادي";

                case (Language.EN):
                default: return "My Courses";
            }
        }
        public static String courseNameAR()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اسم المادة بالعربية";

                case (Language.EN):
                default: return "Course name in Arabic";
            }
        }
        public static String courseNameEN()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اسم المادة بالاإنجليزية";

                case (Language.EN):
                default: return "Course name in English";
            }
        }
        public static String courseCredits()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الوحدات";

                case (Language.EN):
                default: return "Credits";
            }
        }
        public static String lecturerNameAR()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اسم المحاضر بالعربية";

                case (Language.EN):
                default: return "Lecturer name in English";
            }
        }
        public static String lecturerNameEN()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اسم المحاضر بالانجليزية";

                case (Language.EN):
                default: return "Lecturer name in Arabic";
            }
        }
        public static String sendMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "ارسال رسالة";

                case (Language.EN):
                default: return "MESSAGE";
            }
        }
        public static String profile()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الملف الشخصي";

                case (Language.EN):
                default: return "PROFILE";
            }
        }
    }
}
