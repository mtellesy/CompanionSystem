using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
  public class Announcements
    {
        public static String AnnouncementHasSuccessfullySent()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تم إرسال الإعلان بنجاح";

                case (Language.EN):
                default: return "The Announcement has been successfully sent";
            }
        }

        public static String AnnouncementSendFaild()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "فشلت محاولة إرسال الإعلان";

                case (Language.EN):
                default: return "Announcement sending has failed";
            }
        }

        public static String AnnouncementStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة الإعلان";

                case (Language.EN):
                default: return "Announcement Status";
            }
        }
    }
}
