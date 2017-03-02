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
                case (Language.AR): return "تم إرسال الرسالة بنجاح";

                case (Language.EN):
                default: return "The Message has been successfully sent";
            }
        }

        public static String MessageSendFaild()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "فشلت محاولة إرسال الرسالة";

                case (Language.EN):
                default: return "Message sending has failed";
            }
        }

        public static String MessageStatus()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "حالة إرسال الرسالة";

                case (Language.EN):
                default: return "Message Send Status";
            }
        }
    }
}
