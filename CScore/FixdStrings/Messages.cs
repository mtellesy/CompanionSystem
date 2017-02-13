using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public class Messages
    {
        public static String MessageHasSuccessfullySent()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "تم إرسال الرسالة";

                case (Language.EN):
                default: return "Message sent";
            }
        }

        public static String MessageSendFaild()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "فشلت محاولة إرسال الرسالة";

                case (Language.EN):
                default: return "Failed to send message";
            }
        }

        public static String MessageStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة الرسالة";

                case (Language.EN):
                default: return "Message Status";
            }
        }

        public static String MessagesLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "الرسائل";

                case (Language.EN):
                default: return "Messages";
            }
        }

        public static String SendMessageLable()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إرسال رسالة";

                case (Language.EN):
                default: return "Send Message";
            }
        }
    }
}
