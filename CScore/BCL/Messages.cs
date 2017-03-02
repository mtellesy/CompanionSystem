using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Messages
    {
        //      done
        //                  PROBERTIES
        int mes_id;
        bool mes_status;
        int mes_sender;    
        int mes_reciever;      
        String mes_subject;
        String mes_time;
        String mes_content;
        bool is_updated;
        String attatchementID;
        String attatchementPath;
        String attatchementType;

        //                  SETTERS AND GETTERS
        //      mes_id
        public int Mes_id
        {
            set
            {
                mes_id = value;
            }get
            {
                return mes_id;
            }
        }
        //      mes_status
        public bool Mes_status
        {
            set
            {
                mes_status = value;
            }
            get
            {
                return mes_status;
            }
        }
        //      mes_sender
        public int Mes_sender
        {
            set
            {
                mes_sender = value;
            }
            get
            {
                return mes_sender;
            }
        }
        //      mes_reciever
        public int Mes_reciever
        {
            set
            {
                mes_reciever = value;
            }
            get
            {
                return mes_reciever;
            }
        }
        //      mes_subject
        public String Mes_subject
        {
            set
            {
                mes_subject = value;
            }
            get
            {
                return mes_subject;
            }
        }
        //      is_updated
        public bool Is_updated
        {
            set
            {
                is_updated = value;
            }
            get
            {
                return is_updated;
            }
        }
        //      mes_time
        public String Mes_time
        {
            set
            {
                mes_time = value;
            }
            get
            {
                return mes_time;
            }
        }
        //      mes_content
        public String Mes_content
        {
            set
            {
                mes_content = value;
            }
            get
            {
                return mes_content;
            }
        }
        //      attatchementID
        public String AttatchementID
        {
            set
            {
                attatchementID = value;
            }
            get
            {
                return attatchementID;
            }
        }
        //      attatchementPath
        public String AttatchementPath
        {
            set
            {
                attatchementPath = value;
            }
            get
            {
                return attatchementPath;
            }
        }
        //      attatchementType
        public String AttatchementType
        {
            set
            {
                attatchementType = value;
            }
            get
            {
                return attatchementType;
            }
        }


        //                   METHODS
        public static async Task<StatusWithObject<Messages>> getMesssage(int messageId)
        {
            Messages result = new Messages();
            StatusWithObject<Messages> returnedValue = new StatusWithObject<Messages>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.MessageS.getMessage(messageId);
                if (returnedValue.status.status == true)
                {
                    await DAL.MessageD.saveMessage(returnedValue.statusObject);
                }
            }
            result = await DAL.MessageD.getMessage(messageId);
            returnedValue.statusObject = result;
            return returnedValue;
        }

        public static async Task<Boolean> sendMessage(Messages Message)
        {
            if (await UpdateBox.CheckForInternetConnection() == true)
            {
              var messageSatus = await SAL.MessageS.sendMessage(Message);

               return messageSatus.status.status;
               // return true;
            }
            else
                return false;
        }

        public static async Task<StatusWithObject<List<Messages>>> getMessages(int NumberOfMessages, int startFrom, String type)
        {
            // type is used for to know which type of Messages it will return (received or sent)
            List<Messages> messages = new List<Messages>();
            //if there is a internet bring from SAL and save in DB then bring them from DAL anyway 
            Messages result = new Messages();
            StatusWithObject<List<Messages>> returnedValue = new StatusWithObject<List<Messages>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.MessageS.getMessages(NumberOfMessages, startFrom);
                if (returnedValue.status.status == true)
                {
                    foreach (Messages x in returnedValue.statusObject)
                    {
                        await DAL.MessageD.saveMessage(x);
                    }
                }
            }
            //Sent
            if (type == "sent" || type == "S" || type == "Sent" || type == "SENT")
                messages = await DAL.MessageD.getSentMessages(NumberOfMessages, startFrom, User.use_id);
            //Receive
            else if (type == "received" || type == "R" || type == "Received" || type == "RECEIVED")
                messages = await DAL.MessageD.getReceivedMessages(NumberOfMessages, startFrom, User.use_id);
            else returnedValue.statusObject = null;
            returnedValue.statusObject = messages;

                return returnedValue ;
        }

    }
}
