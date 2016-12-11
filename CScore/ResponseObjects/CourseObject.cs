using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class CourseObject
    {
        //      course
        public String courseID { set; get; }
        public String nameAR { set; get; }
        public String nameEN { set; get; }
        //      group
        public int groupID { set; get; }
        public String groupNameAR { set; get; }
        public String groupNameEN { set; get; }
        //      other
        public int credit { set; get; }
        public int semester { set; get; }
        //      lecturer
        public int lecturerID { set; get; }
        public String lecturerNameAR { set; get; }
        public String lecturerNameEN { set; get; }
        public int managerID { set; get; }
        //      department
        public String departmentID { set; get; }
        public String departmentNameAR { set; get; }
        public String departmentNameEN { set; get; }
        //      branch
        public String branchID { set; get; }
        public String branchNameAR { set; get; }
        public String branchNameEN { set; get; }



    }
}
