using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Transcript
    {
        public static String TranscriptLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "كشف الدرجات";

                case (Language.EN):
                default: return "Transcript";
            }
        }
    }
}
