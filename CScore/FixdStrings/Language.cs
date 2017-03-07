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
        private static Language locLang;
        private static Language language;// by defualt

        public static void setLanguage(Language newLang)
        {

            language = newLang;
            try
            {
                var task = Task.Run(async () => { await DAL.LanguageD.saveLanguage(newLang); });
                task.Wait();
            }
            catch
            { }
        }

        public static Language getLanguage()
        {
            locLang = Language.EN;
            language = Language.EN; // by defualt
            try
            {
                var task = Task.Run(async () => { await getLanguageAsync(); });
                task.Wait();
                language = locLang;
            }
            catch
            { }
            return language;
        }

        public static async Task getLanguageAsync()
        {
            Language Newlanguage = Language.EN;
            
            String lanString = await DAL.LanguageD.getLanguage();
            if (lanString != null)
            {
                switch (lanString)
                {
                    case ("AR"):
                        Newlanguage = Language.AR;
                        break;
                    case ("EN"):
                    default:
                        Newlanguage = Language.EN;
                        break;
                }
            }

            locLang = Newlanguage;
        }
    }

    }

