using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
//sing CScore.DataLayer.Tables;

namespace CScore.DataLayer
{
   public class DBDestroyer
    {
        public async static void destroyDB()
        {
           await DBuilder._connection.ExecuteAsync("DROP TABLE Users");
        }
    }
}
