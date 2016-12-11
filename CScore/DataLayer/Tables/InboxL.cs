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
   public class InboxL
    {
        [PrimaryKey]
        public int Mes_id { get; set; }

        public int Mes_status { get; set; }

        public int Mes_sender { get; set; }

        public int Mes_receiver { get; set; }

        public String Mes_subject { get; set; }

        public String Mes_time { get; set; }

        public String Mes_content { get; set; }

        public Boolean is_updated { get; set; } // to know wither the seen status is updated

    }
}