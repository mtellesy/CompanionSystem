using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Exams
    {
         String examTypeAR { set; get; }
         String examTypeEN { set; get; }
         String startDate { set; get; }
         int duration { set; get; }
         String endDate { set; get; }

        //      examTypeAR
        public String ExamTypeAR
        {
            get
            {
                return examTypeAR;
            }
            set
            {
                examTypeAR = value;
            }

        }
        //      examTypeEN
        public String ExamTypeEN
        {
            get
            {
                return examTypeEN;
            }
            set
            {
                examTypeEN = value;
            }

        }
        //      startDate
        public String StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }

        }
        //      duration
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }

        }
        //      endDate
        public String EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }

        }
    }
}
