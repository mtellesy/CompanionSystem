using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.BCL;

namespace CScore.SAL
{
    class AnnouncementsS:Template
    {
        /*getLatestAnnouncements(User id): List<Announcement>
getAnnouncements(User id): List<Announcement>
getMoreAnnouncements(User id, number of the oldest saved Announcements): List<Announcement>
getAnnouncement(User id, Announcement number): Announcement
*/
        public static List<Announcements> getLatestAnnouncements()
        {
            List<Announcements> announcements = new List<Announcements>();
            String path;
            path = "announcements/";
            //SORRY BABE :( I DONT REALLY UNDERSTAND HOW TO MAKE THIS

            return announcements;
        }

        public static List<Announcements> getAnnouncements()
        {
            List<Announcements> announcements = new List<Announcements>();
            String path;
            path = "announcements/";
            //SORRY BABE :( I DONT REALLY UNDERSTAND HOW TO MAKE THIS

            return announcements;
        }

        public static List<Announcements> getMoreAnnouncements(int latestAnnouncement)
        {
            List<Announcements> announcements = new List<Announcements>();
            String path;
            path = "announcements/";
            return announcements;
        }
        public static Announcements getAnnouncement()
        {
            Announcements announcements = new Announcements();
            String path;
            path = "announcements/";
            return announcements;
        }
  
    }
}
