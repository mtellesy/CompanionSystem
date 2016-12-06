using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Announcements
    {
        public int ano_id { get; set; } 

        public int ano_sender { get; set; }

       // public String ano_subject { get; set; }

        public String ano_time { get; set; }

        public String ano_content { get; set; }

        public String cou_id { get; set; }

       // public int gro_id { get; set; }

        public int ter_id { get; set; }

        public static async Task<Announcements> getAnnouncement(int announcementId)
        {
            
            Announcements announcement = new Announcements();
            announcement = await DAL.AnnouncementD.getAnnouncement(announcementId);

          
            return announcement;
        }

        public static Boolean sendAnnouncement(Announcements announcement)
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

        public static async Task<List<Announcements>> getAnnouncements(int NumberOfAnnouncements, int startFrom, String type , String courseID)
        {
            // type is used for to know which type of Announcements it will return (received or sent)
            List<Announcements> announcements = new List<Announcements>();
            //if there is a internet bring from SAL and save in DB then bring them from DAL anyway 
            if (UpdateBox.CheckForInternetConnection() == true)
            {

                //SAL stuff
                // save announcements in dal

            }
            //get announcements from dal

            //Sent
            if (type == "sent" || type == "S" || type == "Sent" || type == "SENT")
                announcements = await DAL.AnnouncementD.getSentAnnouncements(NumberOfAnnouncements, startFrom, User.use_id);
            //Receive
            else if (type == "received" || type == "R" || type == "Received" || type == "RECEIVED")
                announcements = await DAL.AnnouncementD.getReceivedAnnouncements(NumberOfAnnouncements, startFrom, courseID);
            else
                return null;

            return announcements;
          
        }

    }
}

