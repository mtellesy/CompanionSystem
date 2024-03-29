﻿using System;
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

        public static String YouveNewNotifications()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "لديك رسالة جديدة";

                case (Language.EN):
                default: return "You've a new Message";
            }
        }

        public static String newMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "رسائل جديدة ";

                case (Language.EN):
                default: return " new Messages";
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
        public static String sendTo()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "إلى";

                case (Language.EN):
                default: return "TO";
            }
        }
        public static String messageTitle()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "العنوان";

                case (Language.EN):
                default: return "Subject";
            }
        }
        public static String commposeMessage()
        {
            Language e = LanguageSetter.getLanguage();
            switch (e)
            {
                case (Language.AR): return "اكتب الرسالة";

                case (Language.EN):
                default: return "Compose message";
            }
        }
    }
}
