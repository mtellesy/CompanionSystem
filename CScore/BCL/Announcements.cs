using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Announcements
    {
        //              *** Properties ***
        int ano_id { get; set; } 
         int ano_sender { get; set; }
         String ano_time { get; set; }
         String ano_content { get; set; }
         String cou_id { get; set; }
         String referenceID { get; set; } // not available in database
         int ter_id { get; set; }
        // int gro_id { get; set; }


        //              *** setters and getters ***

        //        cou_id
        public String Cou_id
        {
            set
            {
                cou_id = value;
            }
            get
            {
                return cou_id;
            }
        }
        //        ano_id
        public int Ano_id
        {
            set
            {
                ano_id = value;
            }
            get
            {
                return ano_id;
            }
        }
        //        ano_sender
        public int Ano_sender
        {
            set
            {
                ano_sender = value;
            }
            get
            {
                return ano_sender;
            }
        }
        //        ano_time
        public String Ano_time
        {
            set
            {
                ano_time = value;
            }
            get
            {
                return cou_id;
            }
        }
        //        ano_content
        public String Ano_content
        {
            set
            {
                ano_content = value;
            }
            get
            {
                return ano_content;
            }
        }
        //        referenceID
        public String ReferenceID
        {
            set
            {
                referenceID = value;
            }
            get
            {
                return referenceID;
            }
        } 
        //        ter_id
        public int Ter_id
        {
            set
            {
                ter_id = value;
            }
            get
            {
                return ter_id;
            }
        }

        //              *** Methods ***

        //      get announcement      
        public static async Task<StatusWithObject<Announcements>> getAnnouncement(int announcementId)
        {
            Announcements result = new Announcements();
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();            
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.AnnouncementsS.getAnnouncement(announcementId);
                if (returnedValue.status.status == true && returnedValue.statusObject != null)
                {                    
                        await DAL.AnnouncementD.saveAnnouncement(returnedValue.statusObject);                    
                }
            }
            result = await DAL.AnnouncementD.getAnnouncement(announcementId);
            returnedValue.statusObject = result;
            return returnedValue;
        }

        public static async Task<StatusWithObject<Announcements>> sendAnnouncement(Announcements announcement)
        {
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();

            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.AnnouncementsS.sendAnnouncement(announcement);
                if (returnedValue.status.status == true && returnedValue.statusObject !=null)
                {                    
                        await DAL.AnnouncementD.saveAnnouncement(announcement);                    
                }
            }
            
            return returnedValue;
        }

        public static async Task<StatusWithObject<List<Announcements>>> getAnnouncements(int NumberOfAnnouncements, int startFrom, String type, String courseID)
        {
            // type is used for to know which type of Announcements it will return (received or sent)
            List<Announcements> announcements = new List<Announcements>();
            //if there is a internet bring from SAL and save in DB then bring them from DAL anyway 
            Announcements result = new Announcements();
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.AnnouncementsS.getAnnouncements(NumberOfAnnouncements, startFrom, false,null);
                if (returnedValue.status.status == true && returnedValue.statusObject != null)
                {
                    foreach (Announcements x in returnedValue.statusObject)
                    {
                        await DAL.AnnouncementD.saveAnnouncement(x);
                        int j = 1 + 1;
                    }
                }
            }

            //Sent
            if (type == "sent" || type == "S" || type == "Sent" || type == "SENT")
                announcements = await DAL.AnnouncementD.getSentAnnouncements(NumberOfAnnouncements, startFrom, User.use_id);
            //Receive
            else if (type == "received" || type == "R" || type == "Received" || type == "RECEIVED")
                announcements = await DAL.AnnouncementD.getReceivedAnnouncements(NumberOfAnnouncements, startFrom, courseID);
            else
                return null;

            returnedValue.statusObject = announcements;
            return returnedValue;

        }

        public static async Task<StatusWithObject<List<Announcements>>> getSentAnnouncements(int NumberOfAnnouncements, int startFrom, String type, String courseID)
        {
            // type is used for to know which type of Announcements it will return (received or sent)
            List<Announcements> announcements = new List<Announcements>();
            //if there is a internet bring from SAL and save in DB then bring them from DAL anyway 
            Announcements result = new Announcements();
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.AnnouncementsS.getAnnouncements(NumberOfAnnouncements, startFrom, true, null);
                if (returnedValue.status.status == true && returnedValue.statusObject != null)
                {
                    foreach (Announcements x in returnedValue.statusObject)
                    {
                        await DAL.AnnouncementD.saveAnnouncement(x);
                    }
                }
            }

            //Sent
            if (type == "sent" || type == "S" || type == "Sent" || type == "SENT")
                announcements = await DAL.AnnouncementD.getSentAnnouncements(NumberOfAnnouncements, startFrom, User.use_id);
            //Receive
            else if (type == "received" || type == "R" || type == "Received" || type == "RECEIVED")
                announcements = await DAL.AnnouncementD.getReceivedAnnouncements(NumberOfAnnouncements, startFrom, courseID);
            else
                return null;

            returnedValue.statusObject = announcements;
            return returnedValue;

        }


    }
}

