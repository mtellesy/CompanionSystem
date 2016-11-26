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
    public class ResultsL
    {
        [PrimaryKey]
        public String Cou_id { get; set; }

        public String Cou_nameAR { get; set; }

        public String Cou_nameEN { get; set; }
       
        public int Ter_id { get; set; }

        public String Ter_nameAR { get; set; }

        public String Ter_nameEN { get; set; }

        public String year { get; set; }

        public int Cou_credits { get; set; }
        
        public float Res_total { get; set; } 

    }
}
