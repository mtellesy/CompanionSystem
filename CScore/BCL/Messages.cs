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

        public static Messages getMesssage(int messageId)
        {
            Messages Message = new Messages();
 
            // Message = await DAL.MessageD.getMessage(messageId);
            return Message;
        }

        public static Boolean sendMessage(Messages Message)
        {
            if (UpdateBox.CheckForInternetConnection() == true)
            {
                
                //SAL stuff
                // save message in dal
                return true;
            }
            else
                return false;
        }

        public static List<Messages> getMessages(int NumberOfMessages, int startFrom,String type)
        {
            if (UpdateBox.CheckForInternetConnection() == true)
            {

                //SAL stuff
                // save messages in dal
               
            }
            //get messages from dal
            List<Messages> tt = new List<Messages>();
            return tt ;
        }

    }
}
