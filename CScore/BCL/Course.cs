using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer;

namespace CScore.BCL
{
    public  class Course
    {
       //  String cou_id { get; set; }
         String cou_nameAR { get; set; }
         String cou_nameEN { get; set; }
         int ter_id { get; set; }
         int cou_credits { get; set; }
         List<Schedule> schedule { get; set; }

        //      cou_id
        public String Cou_id
        {
            set
            {
                Cou_id = value;
            }
            get
            {
                return Cou_id;
            }
        }
        //      cou_nameAR
        public String Cou_nameAR
        {
            set
            {
                cou_nameAR = value;
            }
            get
            {
                return cou_nameAR;
            }
        }
        //      cou_nameEN
        public String Cou_nameEN
        {
            set
            {
                cou_nameEN = value;
            }
            get
            {
                return cou_nameEN;
            }
        }
        //      ter_id
        public int Ter_id
        {
            set
            {
                ter_id = value;
            }
            get
            {
                return ter_id;
            }
        }
        //      cou_credits
        public int Cou_credits
        {
            set
            {
                cou_credits = value;
            }
            get
            {
                return cou_credits;
            }
        }
        //      schedule
        public List<Schedule> Schedule
        {
            set
            {
                schedule = value;
            }
            get
            {
                return schedule;
            }
        }
        public static async Task<Course> getCourse(String courseID)
        {
            Course course = new Course();
            course = await DAL.CourseD.getCourse(courseID,User.use_type);
            return course;
        }

        public static async Task<List<Course>> getUserCoursesSchedule()
        {
            List<Course> courses = new List<Course>();

            if(await UpdateBox.CheckForInternetConnection() == true)
            {
                //SAL stuff
                //save what you got from sal anyway
            }

            courses = await DAL.CourseD.getUserCoursesSchedule(Semester.current_term);

            return courses;
            
        }


    }
}
