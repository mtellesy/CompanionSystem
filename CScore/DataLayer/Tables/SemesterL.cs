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
   public class SemesterL
    {
        [PrimaryKey]
        public int current_termID { get; set; }

        public String Ter_nameAR { get; set; }

        public String Ter_nameEN { get; set; }

        public Boolean enrollment { get; set; }
    
    }
}
