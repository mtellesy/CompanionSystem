using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
  public class Enrollment
    {
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
    }
}
