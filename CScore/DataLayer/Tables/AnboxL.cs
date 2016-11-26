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
    public class AnboxL
    {
        [PrimaryKey]
        public int Ano_id { get; set; }

        public int Ano_status { get; set; } 

        public int Ano_sender { get; set; }

        public String Ano_subject { get; set; }

        public String Ano_time { get; set; }

        public String Ano_content { get; set; }

        public String Cou_id { get; set; }

        public int Gro_id { get; set; }

        public int Ter_id { get; set; }

        public Boolean is_updated { get; set; } // to know wither the seen status is updated
        
    }
}
