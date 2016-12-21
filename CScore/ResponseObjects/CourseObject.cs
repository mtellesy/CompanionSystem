using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.BCL;

namespace CScore.ResponseObjects
{
    public class CourseObject
    {
        //      done
        // as created by json2csharp
        //      course
        public string courseID { get; set; }
        public string nameAR { get; set; }
        public string nameEN { get; set; }
        public int credit { get; set; }
        //      group
        public int groupID { set; get; }
        public string groupNameAR { set; get; }
        public string groupNameEN { set; get; }
       
        //      lecturer
        public int lecturerID { set; get; }
        public string lecturerNameAR { set; get; }
        public string lecturerNameEN { set; get; }
        public int managerID { set; get; }
        //      department
        public int departmentID { set; get; }
        public String departmentNameAR { set; get; }
        public String departmentNameEN { set; get; }
        //      branch
        public int branchID { set; get; }
        public String branchNameAR { set; get; }
        public String branchNameEN { set; get; }

        //      schedule
        public int semester { get; set; }
        public List<ScheduleObject> schedule { set; get; }

        //      enrolled flag
        public bool flag;//to know if it has been enrolled or not

        //      group full flag
        public bool groupFull { set; get; }

        //      converters
        public static BCL.Course convertToCourse(CourseObject cou)
        {
            BCL.Course course = new BCL.Course();
            BCL.Schedule ex = new BCL.Schedule();
             course.Cou_id = cou.courseID;

            course.Cou_nameAR = cou.nameAR;
            course.Cou_nameEN = cou.nameEN;
            course.Cou_credits = cou.credit;
            course.Ter_id = cou.semester;
            
            
             course.Flag = cou.flag;
             course.GroupFull = cou.groupFull;
            course.Schedule = new List<Schedule>();
            if (cou.schedule != null)
            {
                foreach (ScheduleObject x in cou.schedule)
                {
                    ex.Tea_id = x.lecturerID;
                    ex.Gro_id = x.groupID;
                    ex.Gro_NameAR = x.groupNameAR;
                    ex.Gro_NameEN = x.groupNameEN;
                    
                  
                    ex.ClassDuration = x.timeDuration;
                    ex.ClassRoomAR = x.classRoomAR;
                    ex.ClassRoomEN = x.classRoomEN;
                    ex.ClassRoomID = x.classRoomID;
                    ex.ClassStart = x.timeStart;
                    ex.ClassTimeID = x.classTimeID;
                    ex.DayID = x.dayID;
                    ex.DayAR = x.dayAR;
                    ex.DayEN = x.dayEN;
                    
                    course.Schedule.Add(ex);
                    
                }
            }
            return course;

        }
        // works only for enrollment
         public static CourseObject convertToCourseObjectForEnrollment(BCL.Course courses)
        {
            CourseObject course = new CourseObject();            

            course.courseID = courses.Cou_id;
            course.groupID = courses.TemGro_id;            

            return course;
        }
    }
}
