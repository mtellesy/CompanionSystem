using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Messages
    {
        public int mes_id { get; set; }

        public int mes_status { get; set; }

        public int mes_sender { get; set; }

       // private String mes_subject { get; set; }

      //  private String mes_time { get; set; }

        public String mes_content { get; set; }

        public static async Task<Messages> getMesssage(int messageId)
        {
            Messages Message = new Messages();
 
            Message = await DAL.MessageD.getMessage(messageId);

            return Message;
        }

        public static async Task<Boolean> sendMessage(Messages Message)
        {
            if (await UpdateBox.CheckForInternetConnection() == true)
            {
                
                //SAL stuff
                // save message in dal
                return true;
            }
            else
                return false;
        }

        public static async Task<List<Messages>> getMessages(int NumberOfMessages, int startFrom,String type)
        {
            // type is used for to know which type of Messages it will return (received or sent)

            List<Messages> messages = new List<Messages>(); // type Messages
            //if there is a internet bring from SAL and save in DB then bring them from DAL anyway 
            if (await UpdateBox.CheckForInternetConnection() == true)
            {
                //SAL stuff
                // save messages in dal
               
            }
            //get messages from dal
            //Sent
            if (type == "sent" || type == "S" || type == "Sent" || type == "SENT")
                messages = await DAL.MessageD.getSentMessages(NumberOfMessages, startFrom, User.use_id);
            //Receive
            else if (type == "received" || type == "R" || type == "Received" || type == "RECEIVED")
                messages = await DAL.MessageD.getReceivedMessages(NumberOfMessages, startFrom, User.use_id);
            else return null;

                return messages ;
        }

    }
}
