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
    public class StudentCoursesL
    {
        [PrimaryKey]
        public String Cou_id { get; set; }
      
        public int Gro_id { get; set; }
  
        public int Ter_id { get; set; }

        public int Cou_credits { get; set; }

        public int Tea_id { get; set; }
        
        public float finalMark { get; set; } 

    }
}
