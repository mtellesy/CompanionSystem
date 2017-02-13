using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
    public enum Theme
    {
        Indigo, Teal
    };
    public static class ThemeSetter
    {
            private static Theme locThem;
            private static Theme theme;// by defualt

            public static void setTheme(Theme newTheme)
            {

                theme = newTheme;
                try
                {
                    var task = Task.Run(async () => { await DAL.ThemeD.saveTheme(newTheme); });
                    task.Wait();
                }
                catch
                { }
            }

            public static Theme getTheme()
            {
                locThem = Theme.Indigo;
                theme = Theme.Indigo; // by defualt
                try
                {
                    var task = Task.Run(async () => { await getThemeAsync(); });
                    task.Wait();
                    theme = locThem;
                }
                catch
                { }
                return theme;
            }

            public static async Task getThemeAsync()
            {
                Theme NewTheme = Theme.Indigo;

                String themeString = await DAL.ThemeD.getTheme();
                if (themeString != null)
                {
                    switch (themeString)
                    {
                        case ("Indigo"):
                            NewTheme = Theme.Indigo;
                            break;
                        case ("Teal"):
                        default:
                            NewTheme = Theme.Teal;
                            break;
                    }
                }

                locThem = NewTheme;
            }
        }
    }
