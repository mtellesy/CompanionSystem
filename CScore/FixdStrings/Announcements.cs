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
                case (Language.AR): return "تم إرسال الإعلان";

                case (Language.EN):
                default: return "Announcement sent";
            }
        }

        public static String YouveNewNotifications()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لديك إعلان جديدة";

                case (Language.EN):
                default: return "You've a new Announcement";
            }
        }

        public static String newMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return " إعلانات جديدة";

                case (Language.EN):
                default: return " new Announcements";
            }
        }

        public static String AnnouncementSendFaild()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "فشلت محاولة إرسال الإعلان";

                case (Language.EN):
                default: return "Failed to send announcement";
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

        public static string AnnouncementsLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الإعلانات";

                case (Language.EN):
                default: return "Announcements";
            }
        }

        public static String SendAnnouncementLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إرسال إعلان";

                case (Language.EN):
                default: return "Send Announcement";
            }
        }
    }
}
