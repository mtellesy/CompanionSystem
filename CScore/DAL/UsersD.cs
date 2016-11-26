using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;
using CScore.DataLayer;
using CScore.BCL;
using SQLite.Net;
//using SQLite.Net.Async;
//using SQLite.Net.Interop;
//sing SQLite.Net.Attributes;

namespace CScore.DAL
{
    public static class UsersD 
    {
        
        public static List<String> results;


        public static async Task saveUser(String name)
        {

            var user = new Users()
            {
                Use_nameEN = name
            };
      
           
          await DBuilder._connection.InsertAsync(user);

        }

       // <IEnumerable<Users>
        public static async Task<List<String>> getUsers()
        {
            var entities = await DBuilder._connection.Table<Users>().ToListAsync();
         List<String>   results = entities.Select(i => i.Use_nameEN).ToList();
            return results;
        }

        public static async Task<Messages> getRecievedMessages()
        {
            Messages messages = new Messages();
            return messages;
        }


    }
}
