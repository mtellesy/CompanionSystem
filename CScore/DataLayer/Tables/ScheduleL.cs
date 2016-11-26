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
   public class ScheduleL
    {
        [PrimaryKey]
        public String Cou_id { get; set; }
        
        public int Gro_id { get; set; }
       
        public int Ter_id { get; set; }

        public String Gro_name { get; set; }

        public String Cou_nameAR { get; set; }

        public String Cou_nameEN { get; set; }

        public int dayID { get; set; }

        public int classTimeID { get; set; }
        
        public String classStart { get; set; }

        public float classDuration { get; set; }
        
        public int classRoomID { get; set; }
        
        public String classRoomEN { get; set; }

        public String classRoomAR { get; set; }
    }
}
