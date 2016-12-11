using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class ExamsObject
    {       
        public String examTypeAR { set; get; }
        public String examTypeEN { set; get; }
        public String startDate { set; get; }
        public int duration { set; get; }
        public String endDate { set; get; }
    }
}
