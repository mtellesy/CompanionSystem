using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Semester
    {
        // Current term id must be set from Application layer from the start of the APP
        public static int current_term {get; set;}


        public  int ter_id { get; set; }

        public String ter_nameAR { get; set; }

        public String ter_nameEN { get; set; }

        public String year { get; set; }

        public DateTime ter_start { get; set; }

        public DateTime ter_end { get; set; }

        public DateTime ter_lastStudyDate { get; set; }

        public DateTime ter_enrollment { get; set; }

        public DateTime ter_dropCourses { get; set; }


    }
}
