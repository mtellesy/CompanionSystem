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

        public static List<Announcements> getAnnouncements(int NumberOfAnnouncements, int startFrom, String type)
        {
            if (UpdateBox.CheckForInternetConnection() == true)
            {

                //SAL stuff
                // save messages in dal

            }
            //get messages from dal
            List<Announcements> tt = new List<Announcements>();
            return tt;
        }

    }
}

