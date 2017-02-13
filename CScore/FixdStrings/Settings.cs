using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
    public class Settings
    {
        public static String SettingsSaved()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تم حفظ الإعدادات ";

                case (Language.EN):
                default: return "Settings saved";
            }
        }
        public static String SettingsStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة الإعدادات";

                case (Language.EN):
                default: return "Settings Status";
            }
        }
         public static String SettingsLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإعدادات";

                case (Language.EN):
                default: return "Settings";
            }
        }
        public static String LanguageLabel()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اللغة";

                case (Language.EN):
                default: return "Language";
            }
        }
        
        public static String LanguageLabelArabic()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "العربية";

                case (Language.EN):
                default: return "Arabic";
            }
        }
        public static String LanguageLabelEnglish()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإنجليزية";

                case (Language.EN):
                default: return "English";
            }
        }
        public static String ThemeLabel()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "النمط";

                case (Language.EN):
                default: return "Theme";
            }
        }
        public static String ThemeLabelIndigo()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "أزرق نيلي";

                case (Language.EN):
                default: return "Indigo";
            }
        }
        public static String ThemeLabelTeal()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "أخضر";

                case (Language.EN):
                default: return "Teal";
            }
        }
        public static String aboutusLabel()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عن التطبيق";

                case (Language.EN):
                default: return "About us";
            }
        }
        public static String aboutusText()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "عن التطبيق";

                case (Language.EN):
                default: return "About us";
            }
        }
    }
}
