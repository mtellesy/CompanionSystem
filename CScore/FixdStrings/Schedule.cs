using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
    public class Schedule
    {
        public static String ScheduleLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الجدول الدراسي";

                case (Language.EN):
                default: return "Schedule";
            }
        }
    }
}
