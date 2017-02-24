using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
 /// <summary>
 /// AR for Arabic
 /// EN for Engilish
 /// </summary>
 public enum Language
    {
        AR,EN
    };
    public static class LanguageSetter
    {
        private static Language language = Language.EN; // by defualt

        public static void setLanguage(Language newLang)
        {
            language = newLang;
        }

        public static Language getLanguage()
        {
            return language;
        }

    }

    }

