using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class MessageS:Template
    {
        public static List<Messages> getLatesteMessages()
        {
            List<Messages> messages = new List<Messages>();
            //SORRY BABE :( I DONT REALLY UNDERSTAND HOW TO MAKE THIS

            return messages;
        }
            
        public static List<Messages> getMessages()
        {
            List<Messages> messages = new List<Messages>();
            //SORRY BABE :( I DONT REALLY UNDERSTAND HOW TO MAKE THIS
            return messages;
        }

        public static Messages getMessage(int mes_id)
        {
           Messages message = new Messages();
            String path = "/message/"+mes_id;
            return message;
        }

        public static void sendMessage(Messages message)
        {
            String path = "/message";

        }

    }
}
