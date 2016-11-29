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
    [Table("SemesterL")]
    public class SemesterL
    {
        [PrimaryKey]
        public int Ter_id { get; set; }

        public String Ter_nameAR { get; set; }

        public String Ter_nameEN { get; set; }

        public String year { get; set; }

        public String Ter_start { get; set; }

        public String Ter_end { get; set; }

        public String Ter_lastStudyDate { get; set; }

        public String Ter_enrollment { get; set; }

        public String Ter_dropCourses { get; set; }

        public Boolean enrollment { get; set; }

    
    }
}
