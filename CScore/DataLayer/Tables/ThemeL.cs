using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Attributes;


namespace CScore.DataLayer.Tables
{
    class ThemeL
    {
        [PrimaryKey]
        public int id { get; set; }
        [Default(true, "Indigo")]
        public String theme { get; set; }
    }
}
