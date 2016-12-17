using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class MidMarkDistribution
    {
        //      done
        //              *** Properties ***
        int midMarkDistributionID { set; get; }
         String cou_id { set; get; }
         String mid_nameAR { set; get; }
         String mid_nameEN { set; get; }
         float grade { set; get; }

        //              *** setters and getters ***

        //        midMarkDistributionID
        public int MidMarkDistributionID
        {
            set
            {
                midMarkDistributionID = value;
            }
            get
            {
                return midMarkDistributionID;
            }
        }
        //        cou_id
        public String Cou_id
        {
            set
            {
                cou_id = value;
            }
            get
            {
                return cou_id;
            }
        }
        //        mid_nameAR
        public String Mid_nameAR
        {
            set
            {
                mid_nameAR = value;
            }
            get
            {
                return mid_nameAR;
            }
        }
        //        mid_nameEN
        public String Mid_nameEN
        {
            set
            {
                mid_nameEN = value;
            }
            get
            {
                return mid_nameEN;
            }
        }
        //        grade
        public float Grade
        {
            set
            {
                grade = value;
            }
            get
            {
                return grade;
            }
        }

    }
}
