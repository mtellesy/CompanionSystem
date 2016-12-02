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

        public static async Task<List<Messages>> getReceivedAnnouncements(int NumberOfMessages, int StartFrom, int user_id)
        {
            var results = await DBuilder._connection.Table<InboxL>().Where(t => t.Mes_receiver.Equals(user_id)).OrderByDescending(i => i.Mes_id).ToListAsync();

            int index = 1; // start from one when you fetch the messages
            if (NumberOfMessages <= 0) // if you got zero or less send the default number of messages
                NumberOfMessages = 10; // the default number of messages

            List<Messages> messages = new List<Messages>(); // list of the returned messages

            if (StartFrom <= 0) // if they tell you start from zero or less then just fetch from the first message
            {
                foreach (var mesg in results)
                {
                    if (index <= NumberOfMessages)
                    {
                        Messages newMess = new Messages();
                        newMess.mes_id = mesg.Mes_id;
                        newMess.mes_sender = mesg.Mes_sender;
                        newMess.mes_content = mesg.Mes_content;
                        newMess.mes_status = mesg.Mes_status;
                        messages.Add(newMess);
                        index++; // okay go and fetch the next one 

                    }
                    else break;
                }
            }
            else // if they tell you to start from somewhere not from the first message
            {
                int whenToStart = StartFrom; // when we start fetching
                foreach (var mesg in results)
                {
                    if (whenToStart >= 1 && index <= NumberOfMessages) // <==
                    {
                        // if (index <= NumberOfMessages) we add it ^uphere^ 
                        //{
                        Messages newMess = new Messages();
                        newMess.mes_id = mesg.Mes_id;
                        newMess.mes_sender = mesg.Mes_sender;
                        newMess.mes_content = mesg.Mes_content;
                        newMess.mes_status = mesg.Mes_status;
                        messages.Add(newMess);
                        index++;
                        // }

                    }
                    else break;

                    whenToStart--;

                }
            }
            return messages;
        }


        public static async Task<List<Messages>> getSentAnnouncements(int NumberOfMessages, int StartFrom, int user_id)
        {
            var results = await DBuilder._connection.Table<InboxL>().Where(t => t.Mes_sender.Equals(user_id)).OrderByDescending(i => i.Mes_id).ToListAsync();

            int index = 1;
            if (NumberOfMessages <= 0)
                NumberOfMessages = 10;

            List<Messages> messages = new List<Messages>();

            if (StartFrom <= 0)
            {
                foreach (var mesg in results)
                {
                    if (index <= NumberOfMessages)
                    {
                        Messages newMess = new Messages();
                        newMess.mes_id = mesg.Mes_id;
                        newMess.mes_sender = mesg.Mes_sender;
                        newMess.mes_content = mesg.Mes_content;
                        newMess.mes_status = mesg.Mes_status;
                        messages.Add(newMess);
                        index++;

                    }
                    else break;
                }
            }
            else
            {
                int whenToStart = StartFrom; // when we start fetching
                foreach (var mesg in results)
                {
                    if (whenToStart >= 1 && index <= NumberOfMessages)
                    {
                        // if (index <= NumberOfMessages)
                        //{
                        Messages newMess = new Messages();
                        newMess.mes_id = mesg.Mes_id;
                        newMess.mes_sender = mesg.Mes_sender;
                        newMess.mes_content = mesg.Mes_content;
                        newMess.mes_status = mesg.Mes_status;
                        messages.Add(newMess);
                        index++;
                        // }

                    }
                    else break;
                    whenToStart--;

                }
            }
            return messages;
        }



        public static async Task<Messages> getAnnouncement(int announcementID)
        {
            var checker = await DBuilder._connection.Table<InboxL>().Where(i => i.Mes_id.Equals(announcementID)).CountAsync();

            if (checker > 0)
            {
                var results = await DBuilder._connection.Table<InboxL>().Where(i => i.Mes_id.Equals(announcementID)).ToListAsync();

                Messages message = new Messages();
                message.mes_id = results.Select(i => i.Mes_id).First();
                message.mes_sender = results.Select(i => i.Mes_sender).First();
                message.mes_content = results.Select(i => i.Mes_content).First();
                message.mes_status = results.Select(i => i.Mes_status).First();

                return message;
            }
            else
                return null;
        }

        public static async Task saveAnnouncement(Messages announcement)
        {
            CScore.DataLayer.Tables.InboxL DbMessage = new InboxL();
            DbMessage.Mes_id = announcement.mes_id;
            DbMessage.Mes_sender = announcement.mes_sender;
            DbMessage.Mes_status = announcement.mes_status;
            //DbMessage.Mes_time = current time 
            DbMessage.Mes_content = announcement.mes_content;

            var results = await DBuilder._connection.Table<InboxL>().Where(i => i.Mes_id.Equals(announcement.mes_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(DbMessage);
            }
            else
                await DBuilder._connection.UpdateAsync(DbMessage);

        }
    }
}
