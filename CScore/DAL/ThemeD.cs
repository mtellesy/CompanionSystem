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
    class ThemeD
    {
        public static async Task<String> getTheme()
        {
            String theme = null;
            if (await DBuilder._connection.Table<ThemeL>().CountAsync() > 0)
            {
                var Result = await DBuilder._connection.Table<ThemeL>().FirstAsync();
                theme = Result.theme;
            }

            return theme;
        }

        public static async Task saveTheme(FixdStrings.Theme theme)
        {
            ThemeL l = new ThemeL();
            l.id = 1;
            l.theme = theme.ToString();
            // this Table should only hold one row
            if (await DBuilder._connection.Table<ThemeL>().CountAsync() > 0)
            {
                var result = await DBuilder._connection.Table<ThemeL>().FirstAsync();
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
