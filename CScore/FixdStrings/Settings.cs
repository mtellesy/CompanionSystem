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
                case (Language.AR): return "تم حفظ الإعدادات بنجاح";

                case (Language.EN):
                default: return "The Settings saved successfully";
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
    }
}
