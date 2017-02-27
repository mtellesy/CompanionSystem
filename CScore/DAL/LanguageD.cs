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
   public class LanguageD
    {
        public static async Task<String> getLanguage()
        {
            String language = null;
            if(await DBuilder._connection.Table<LanguageL>().CountAsync() > 0)
            {
                var Result = await DBuilder._connection.Table<LanguageL>().FirstAsync();
                language = Result.lan;
            }

            return language;
        }

        public static async Task saveLanguage(FixdStrings.Language language)
        {
            LanguageL l = new LanguageL();
            l.id = 1;
            l.lan = language.ToString();
            // this Table should only hold one row
            if(await DBuilder._connection.Table<LanguageL>().CountAsync() > 0)
            {
                var result = await DBuilder._connection.Table<LanguageL>().FirstAsync();
                l.id = result.id;
                await DBuilder._connection.UpdateAsync(l);
            }
            else
            {
                await DBuilder._connection.InsertAsync(l);
            }
        }
    }
}
