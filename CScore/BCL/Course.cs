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
        public int gro_id { get; set; }
        public int ter_id { get; set; }
        public int cou_credits { get; set; }    
        public String tea_id { get; set; }
        public float finalMark { get; set; }
        public int classTimeID { get; set; }
        public String cou_nameAR { get; set; }
        public String cou_nameEN { get; set; }
        public int classRoomID { get; set; }
        public int classTimeID2{ get; set; }
        public int classRoomID2{ get; set; }
        /*
        public Course getCourse(String cou_id)
        {
            Course cg = new Course();
            Status s= new Status();
            s = internetChecker();
            if (s.status)
            {
                cg = SAL.CourseS.getCourse(cou_id);
                DAL.CourseD.saveCourse();
            }else
            {
                //return the status message
            }

        }*/
        /*
        public void saveCourse()
        {
           // DAL.CourseD.saveCourse(this);
        }

        public void deleteCourse()
        {
            DAL.CourseD.deleteCourse(this);
        }*/

    }
}
