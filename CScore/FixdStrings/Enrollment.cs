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
                case (Language.AR): return " عملية تسجيل المواد";
                case (Language.EN):
                default: return "Enrollment Status";
            }
        }
        /// <summary>
        /// String for Disenrollment Message title
        /// </summary>
        /// <returns></returns>
        public static String disenrollmentStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عملية إسقاط المواد";
                case (Language.EN):
                default: return "Disenrollment Status";
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
                case (Language.AR): return "تم اضافة المادة";
                case (Language.EN):
                default: return "Course added";
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
                case (Language.AR): return "تم حذف المادة";
                case (Language.EN):
                default: return "Course dropped";
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
                default: return "Nothing has changed";
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
                case (Language.AR): return "وقت هذه المجموعة يتعارض مع مادة\\مواد أخرى:\n\n";
                case (Language.EN):
                default: return "Group's lecture time conflicts with another course(s):\n\n";
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
                default: return "Enrollment isn't available\n";
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
                default: return "\nDropped Courses:\n";
            }
        }
        /// <summary>
        /// "Enrolled Courses:" message
        /// </summary>
        /// <returns></returns>
        public static String enrolledCourses()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "\nالمواد التي تم إضافتها:\n";
                case (Language.EN):
                default: return "\nEnrolled Courses:\n";
            }
        }
        /// <summary>
        /// "Available Credits to drop:" message
        /// </summary>
        /// <returns></returns>
        public static String AvaialabeCreditTodrop()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return " الوحدات المتاحة للإسقاط:";
                case (Language.EN):
                default: return "Credits to drop:";
            }
        }
        /// <summary>
        /// "Available Credits:" message
        /// </summary>
        /// <returns></returns>
        public static String AvaialabeCreditToEnroll()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الوحدات المتاحة:";
                case (Language.EN):
                default: return "Allowed:";
            }
        }
        /// <summary>
        /// "Total Credits:" message
        /// </summary>
        /// <returns></returns>
        public static String TotalCredits()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإجمالي:";
                case (Language.EN):
                default: return "Total:";
            }
        }
        /// <summary>
        /// "You're not Enrolled in any Course" message String
        /// </summary>
        /// <returns></returns>
        public static String noCoursesToDrop()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لست مسجلاً في أي مادة";
                case (Language.EN):
                default: return "You didn't enroll in any course";
            }
        }
        /// <summary>
        /// Enrollment Status Notification title
        /// </summary>
        /// <returns></returns>
        public static String EnrollmentStatusNotification()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل المواد";
                case (Language.EN):
                default: return "Enrollment Status";
            }
        }
        /// <summary>
        /// "Enrollment is Available" message String 
        /// </summary>
        /// <returns></returns>
        public static String EnrollmentIsAvailable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل المواد متاح";
                case (Language.EN):
                default: return "Enrollment is available";
            }
        }
        /// <summary>
        /// Couses Status String
        /// </summary>
        /// <returns></returns>
        public static String CourseStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة المادة";
                case (Language.EN):
                default: return "Course Status";
            }
        }
        
        public static String Reg()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "مسجلة";
                case (Language.EN):
                default: return "REG";
            }
        }

        public static String EnrollmentLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تسجيل المواد";
                case (Language.EN):
                default: return "Enrollment";
            }
        }
    }
}
