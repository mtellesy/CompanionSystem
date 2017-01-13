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
                default: return "Courese Code";
            }
        }
    }
}
