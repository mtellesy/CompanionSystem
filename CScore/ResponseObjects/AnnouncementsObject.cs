using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    class AnnouncementsObject
    {
        //          JSON2C#
        public int postID { get; set; }
        public int postPrivacyID { get; set; }
        public string postPrivacyNameAR { get; set; }
        public string postPrivacyNameEN { get; set; }
        public string postTypeID { get; set; }
        public string postTypeNameAR { get; set; }
        public string postTypeNameEN { get; set; }
        public string content { get; set; }
        public string postTime { get; set; }
        public int postBy { get; set; }
        public string postByName { get; set; }
        //         By D.U.S.T
        public string courseID { get; set; }
        public int termID { get; set; }
        public int referenceID { get; set; }

        public static BCL.Announcements convertToAnnouncement(AnnouncementsObject ano)
        {
            BCL.Announcements announcement = new BCL.Announcements();
            announcement.Ano_id = ano.postID;
            announcement.Ano_sender = ano.postBy;
            announcement.Ano_time = ano.postTime;
            announcement.Ano_content = ano.content;
            //announcement.Cou_id = ano.postByName;
            announcement.Cou_id = ano.courseID;
            announcement.Ter_id = ano.termID;
            announcement.ReferenceID = ano.referenceID.ToString();

            return announcement;
        }
        /*
         post{
postID: string
postPrivacyID: string
postTypeID: string
content: string
}

             */
        public static AnnouncementsObject convertToAnnouncementObject(BCL.Announcements ano)
        {
            AnnouncementsObject announcement = new AnnouncementsObject();
            announcement.postID = ano.Ano_id;
            //announcement.referenceID = ano.referenceID
            //
            return announcement;
        }

    }
}
