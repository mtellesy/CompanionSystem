﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.BCL;

namespace CScore.ResponseObjects
{
    public class CourseObject
    {
        //      course
       /* public String courseID { set; get; }
        public String nameAR { set; get; }
        public String nameEN { set; get; }*/
        //      group
        public int groupID { set; get; }
        public String groupNameAR { set; get; }
        public String groupNameEN { set; get; }
        //      other
      /*  public int credit { set; get; }
        public int semester { set; get; }*/
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
        // as created by json2csharp
        public string courseID { get; set; }
        public string nameAR { get; set; }
        public string nameEN { get; set; }
        public int credit { get; set; }
        public int semester { get; set; }
       // public List<Schedule> schedule { get; set; }
        public List<ScheduleObject> schedule { set; get; }
        public bool flag;//to know if it has been enrolled or not


        public static BCL.Course convertToCourse(CourseObject cou)
        {
            BCL.Course course = new BCL.Course();
            BCL.Schedule ex = new BCL.Schedule();
            course.Cou_id = cou.courseID;
            course.Cou_nameAR = cou.groupNameAR;
            course.Cou_nameEN = cou.groupNameEN;
            course.Cou_credits = cou.credit;
            course.Ter_id = cou.semester;
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
         public static CourseObject convertToCourseObjectToEnroll(BCL.Course courses)
        {
            CourseObject course = new CourseObject();            

            course.courseID = courses.Cou_id;
            course.groupID = courses.TemGro_id;            

            return course;
        }
    }
}
