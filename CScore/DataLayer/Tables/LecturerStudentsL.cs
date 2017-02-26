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
    public class LecturerStudentsL
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        public String Cou_id { get; set; }
        
        public int Gro_id { get; set; }
       
        public int Ter_id { get; set; }

        public int Stu_id { get; set; }

        public String Stu_nameAR { get; set; }

        public String Stu_nameEN { get; set; }
    }
}
