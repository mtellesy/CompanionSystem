using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
  public class Enrollment
    {

        /// <summary>
        /// String for Enrollment Message title
        /// </summary>
        /// <returns></returns>
        public static String enrollmentStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة عملية تسجيل المواد";
                case (Language.EN):
                default: return "Enrollment Process Status";
            }
        }
        /// <summary>
        /// String for Disenrollment Message title
        /// </summary>
        /// <returns></returns>
        public static String disenrollmentStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch(e)
            {
                case (Language.AR): return "حالة عملية إسقاط المواد";
                case (Language.EN):
                default: return "Disenrollment Process Status";
            }
        }
        /// <summary>
        /// String for Enrollment Succeeded Message
        /// </summary>
        /// <returns></returns>
        public static String enrollmentSucceededMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تم إضافة المادة بنجاح";
                case (Language.EN):
                default: return "The course has been successfully added";
            }
        }
        /// <summary>
        /// String for Disenrollment Succeeded Message
        /// </summary>
        /// <returns></returns>
        public static String disenrollmentSucceededMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تم حذف المادة بنجاح";
                case (Language.EN):
                default: return "The course has been successfully droped";
            }
        }
        /// <summary>
        /// String for When nothing is Changed durring the enrollment or disenrollment
        /// process
        /// </summary>
        /// <returns></returns>
        public static String nothingIsChangedMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لم تقم بإجراء أي تعديلات";
                case (Language.EN):
                default: return "Nothing Has Changed";
            }
        }
        /// <summary>
        /// String for Conflect between courses
        /// </summary>
        /// <returns></returns>
        public static String enrollmentConflectMessage()
        {
            
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عذراً, وقت هذه المجموعة يتعارض مع مادة\\مواد أخرى:\n";
                case (Language.EN):
                default: return "Sorry, the group's lecture time conflects with another subject(s):\n";
            }
        }
        /// <summary>
        /// String for Conflect between courses
        /// </summary>
        /// <returns></returns>
        public static String enrollmentNotAvailable()
        {

            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل المواد غير متاح الأن\n";
                case (Language.EN):
                default: return "Enrollment is not available\n";
            }
        }
         /// <summary>
         /// "Droped Courses:" message
         /// </summary>
         /// <returns></returns>
         public static String dropedCourses()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "\nالمواد التي تم إسقاطها:\n";
                case (Language.EN):
                default: return "\nDroped Courses:\n";
            }
        }

    }
}
