using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public  class Course
    {
        public String cou_id { get; set; }
        public String cou_nameAR { get; set; }
        public String cou_nameEN { get; set; }
        public int Ter_id { get; set; }
        public List<Schedule> schedule { get; set; }
        public int cou_credits { get; set; }
       
       

    }
}
