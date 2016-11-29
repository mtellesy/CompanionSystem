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
    public static class MessageD 
    {
        public static async Task<List<Messages>> getSentMessages(int NumberOfMessages, int StartFrom)
        {
            var results = await  DBuilder._connection.Table<InboxL>().Where(i => i.Mes_sender.Equals(User.use_id)).OrderByDescending(i => i.Mes_id).ToListAsync();
            // how limit and start from
        // var resul =  await DBuilder._connection.QueryAsync<InboxL>(
           //    "SELECT * FROM InboxL Where Mes_sender = ? Limit ?",User.use_id,NumberOfMessages
         //      );
         
            List<Messages> messages = new List<Messages>();

            foreach(var mesg in results)
            {
                Messages newMess = new Messages();
                newMess.mes_id = mesg.Mes_id;
                newMess.mes_sender = mesg.Mes_sender;
                newMess.mes_content = mesg.Mes_content;
                newMess.mes_status = mesg.Mes_status;
                messages.Add(newMess);
            }

            return messages;
        }

        public static async Task saveMessage(Messages message)
        {
            CScore.DataLayer.Tables.InboxL DbMessage = new InboxL();
            DbMessage.Mes_id = message.mes_id;
            DbMessage.Mes_sender = message.mes_sender;
            DbMessage.Mes_status = message.mes_status;
            //DbMessage.Mes_time = current time 
            DbMessage.Mes_content = message.mes_content;

         var results =  await DBuilder._connection.Table<InboxL>().Where(i => i.Mes_id.Equals(message.mes_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(DbMessage);
            }
            else
                await DBuilder._connection.UpdateAsync(DbMessage);

        }
    }
}
