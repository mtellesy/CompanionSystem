using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.BCL;

namespace CScore.ResponseObjects
{
    public class MessagesObject
    {
        //      message
        public int messageID { set; get; }
        public int messageFrom { set; get; }
        public int messageTo { set; get; }
        public String messageTitle { set; get; }
        public String messageText { set; get; }
        public String messageTime { set; get; }
        //      attatchement
        public string attachementID { set; get; }
        public string attachementPath { set; get; }
        public string attachementType { set; get; }
        //      others
        public bool seenState { set; get; }



        public static Messages convertToMessage(MessagesObject mes)
        {
            Messages message = new BCL.Messages();
            message.Is_updated = false;
            message.Mes_content = mes.messageText;
            message.Mes_id = mes.messageID;
            message.Mes_reciever = mes.messageTo;
            message.Mes_sender = mes.messageFrom;
            message.Mes_status = mes.seenState;
            message.Mes_subject = mes.messageTitle;
            message.Mes_time = mes.messageTime;
            if (mes.attachementID!= null)
            {
                message.AttatchementID = mes.attachementID;
                message.AttatchementPath = mes.attachementPath;
                message.AttatchementType = mes.attachementType;
            }else
            {
                message.AttatchementID = null;
                message.AttatchementPath = null;
                message.AttatchementType = null;
            }
            return message;
        }
        public static MessagesObject convertToMessagesObject(Messages mes)
        {
            MessagesObject message = new MessagesObject();

            message.messageTo = mes.Mes_reciever;
            message.messageTime = mes.Mes_time;
            message.messageTitle = mes.Mes_subject;
            message.messageText = mes.Mes_content;
            message.attachementID = mes.AttatchementID;
            message.attachementPath = mes.AttatchementPath;
            message.attachementType = mes.AttatchementType;
            message.seenState = mes.Mes_status;

            return message;
        }
    }
}