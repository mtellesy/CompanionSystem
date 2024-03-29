﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Results
    {
        public static String ResultsLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "النتائج";

                case (Language.EN):
                default: return "Results";
            }
        }
        public static String Result()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "النتيجة";

                case (Language.EN):
                default: return "Result";
            }
        }
        public static String notSet()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لم ترصد";

                case (Language.EN):
                default: return "not set";
            }
        }
        public static String Total()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المجموع";

                case (Language.EN):
                default: return "Total";
            }
        }
        public static String semesterGPA()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "المعدل الفصلي";

                case (Language.EN):
                default: return "Semester GPA";
            }
        }
    }
}
