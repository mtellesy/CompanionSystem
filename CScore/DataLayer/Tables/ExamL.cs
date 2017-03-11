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
   public class ExamL
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        
        
        public int Ter_id { get; set; }

        public String Exam_nameAR { get; set; }

        public String Exam_nameEN { get; set; }

        public String Exam_start { get; set; }

        public String Exam_end { get; set; }
    }
}
