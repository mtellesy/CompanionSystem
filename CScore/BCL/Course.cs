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
        public String cou_id { get; set; }
        public String cou_nameAR { get; set; }
        public String cou_nameEN { get; set; }
        public int Ter_id { get; set; }
        public int cou_credits { get; set; }
        public List<Schedule> schedule { get; set; }
        

        public static async Task<Course> getCourse(String courseID)
        {
            Course course = new Course();
            course = await DAL.CourseD.getCourse(courseID,User.use_type);
            return course;
        }

        public static async Task<List<Course>> getUserCoursesSchedule()
        {
            List<Course> courses = new List<Course>();

            if(UpdateBox.CheckForInternetConnection() == true)
            {
                //SAL stuff
                //save what you got from sal anyway
            }

            courses = await DAL.CourseD.getUserCoursesSchedule(Semester.current_term);

            return courses;
            
        }


    }
}
