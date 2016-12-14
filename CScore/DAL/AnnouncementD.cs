using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;
using CScore.DataLayer;
using CScore.BCL;
using SQLite.Net;

namespace CScore.DAL
{
    public static class AnnouncementD
    {

        public static async Task<List<Announcements>> getReceivedAnnouncements(int NumberOfAnnouncements, int StartFrom, String CourseID)
        {
            var results = await DBuilder._connection.Table<AnboxL>().Where(t => t.Cou_id.Equals(CourseID)).OrderByDescending(i => i.Ano_id).ToListAsync();

            int index = 1; // start from one when you fetch the messages
            if (NumberOfAnnouncements <= 0) // if you got zero or less send the default number of Announcements
                NumberOfAnnouncements = 10; // the default number of Announcements

            List<Announcements> announcements = new List<Announcements>(); // list of the returned Announcements

            if (StartFrom <= 0) // if they tell you start from zero or less then just fetch from the first Announcements
            {
                foreach (var anno in results)
                {
                    if (index <= NumberOfAnnouncements)
                    {
                        Announcements newAnno = new Announcements();
                        newAnno.ano_id = anno.Ano_id;
                        newAnno.ano_sender = anno.Ano_sender;
                        newAnno.ano_content = anno.Ano_content;
                        newAnno.ano_time = anno.Ano_time;
                        newAnno.cou_id = anno.Cou_id;
                       // newAnno.ano_status = anno.Ano_status;
                        announcements.Add(newAnno);
                        index++; // okay go and fetch the next one 

                    }
                    else break;
                }
            }
            else // if they tell you to start from somewhere not from the first message
            {
                int whenToStart = StartFrom; // when we start fetching
                foreach (var anno in results)
                {
                    if (whenToStart >= 1 && index <= NumberOfAnnouncements) // <==
                    {
                        // if (index <= NumberOfMessages) we add it ^uphere^ 
                        //{
                        Announcements newAnno = new Announcements();
                        newAnno.ano_id = anno.Ano_id;
                        newAnno.ano_sender = anno.Ano_sender;
                        newAnno.ano_content = anno.Ano_content;
                        newAnno.cou_id = anno.Cou_id;
                        // newAnno.ano_status = anno.Ano_status;
                        announcements.Add(newAnno);
                        index++;
                        // }

                    }
                    else break;

                    whenToStart--;

                }
            }
            return announcements;
        }


        public static async Task<List<Announcements>> getSentAnnouncements(int NumberOfAnnouncements, int StartFrom, String user_id)
        {
            var results = await DBuilder._connection.Table<AnboxL>().Where(t => t.Ano_sender.Equals(user_id)).OrderByDescending(i => i.Ano_id).ToListAsync();


            int index = 1; // start from one when you fetch the messages
            if (NumberOfAnnouncements <= 0) // if you got zero or less send the default number of Announcements
                NumberOfAnnouncements = 10; // the default number of Announcements

            List<Announcements> announcements = new List<Announcements>(); // list of the returned Announcements

            if (StartFrom <= 0) // if they tell you start from zero or less then just fetch from the first Announcements
            {
                foreach (var anno in results)
                {
                    if (index <= NumberOfAnnouncements)
                    {
                        Announcements newAnno = new Announcements();
                        newAnno.ano_id = anno.Ano_id;
                        newAnno.ano_sender = anno.Ano_sender;
                        newAnno.ano_content = anno.Ano_content;
                        newAnno.ano_time = anno.Ano_time;
                        newAnno.cou_id = anno.Cou_id;
                        // newAnno.ano_status = anno.Ano_status;
                        announcements.Add(newAnno);
                        index++; // okay go and fetch the next one 

                    }
                    else break;
                }
            }
            else // if they tell you to start from somewhere not from the first message
            {
                int whenToStart = StartFrom; // when we start fetching
                foreach (var anno in results)
                {
                    if (whenToStart >= 1 && index <= NumberOfAnnouncements) // <==
                    {
                        // if (index <= NumberOfMessages) we add it ^uphere^ 
                        //{
                        Announcements newAnno = new Announcements();
                        newAnno.ano_id = anno.Ano_id;
                        newAnno.ano_sender = anno.Ano_sender;
                        newAnno.ano_content = anno.Ano_content;
                        newAnno.cou_id = anno.Cou_id;
                        // newAnno.ano_status = anno.Ano_status;
                        announcements.Add(newAnno);
                        index++;
                        // }

                    }
                    else break;

                    whenToStart--;

                }
            }
            return announcements;
        }



        public static async Task<Announcements> getAnnouncement(int announcementID)
        {
            var checker = await DBuilder._connection.Table<AnboxL>().Where(i => i.Ano_id.Equals(announcementID)).CountAsync();

            if (checker > 0)
            {
                var results = await DBuilder._connection.Table<AnboxL>().Where(i => i.Ano_id.Equals(announcementID)).ToListAsync();

                Announcements announcements = new Announcements();
                announcements.ano_id = results.Select(i => i.Ano_id).First();
                announcements.ano_sender = results.Select(i => i.Ano_sender).First();
                announcements.ano_content = results.Select(i => i.Ano_content).First();
                announcements.ano_time = results.Select(i => i.Ano_time).First();
                //   announcements.mes_status = results.Select(i => i.Ano_status).First();
                announcements.cou_id = results.Select(i => i.Cou_id).First();
                announcements.ter_id = results.Select(i => i.Ter_id).First();

                return announcements;
            }
            else
            {
                Announcements announcements = null;
                return announcements;
            }
                
        }

        public static async Task saveAnnouncement(Announcements announcement)
        {
            CScore.DataLayer.Tables.AnboxL DbAnnouncement = new AnboxL();
            DbAnnouncement.Ano_id = announcement.ano_id;
            DbAnnouncement.Ano_sender = announcement.ano_sender;
            //DbAnnouncement.Ano_status = announcement.Ano_status;
            DbAnnouncement.Ano_time = announcement.ano_time;  
            DbAnnouncement.Ano_content = announcement.ano_content;
            DbAnnouncement.Cou_id = announcement.cou_id;
            DbAnnouncement.Ter_id = announcement.ter_id;


            var results = await DBuilder._connection.Table<AnboxL>().Where(i => i.Ano_id.Equals(announcement.ano_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(DbAnnouncement);
            }
            else
                await DBuilder._connection.UpdateAsync(DbAnnouncement);

        }
    }
}
