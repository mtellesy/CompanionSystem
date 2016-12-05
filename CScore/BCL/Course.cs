using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Course
    {
        public String cou_id { get; set; }
        public String cou_nameAR { get; set; }
        public String cou_nameEN { get; set; }
        public int cou_credits { get; set; }
        public int Ter_id { get; set; }
        public List<Schedule> schedule { get; set; }


       public static async Task<Course> getCourse(String courseID)
        {
            Course course = new Course();
            if(UpdateBox.CheckForInternetConnection() == true)
            {
                //SAL stuff
            }
            //use_type must be set from Application layer
            course = await DAL.CourseD.getCourse(courseID,User.use_type);

            return course;


        }

       public static async Task<List<Course>> getUserCoursesSchedule()
        {
            List<Course> myCourses = new List<Course>();

            if (UpdateBox.CheckForInternetConnection() == true)
            {
                //SAL stuff
            }
            //current_term must be set from Application layer

            myCourses = await DAL.CourseD.getUserCoursesSchedule(BCL.Semester.current_term);

            return myCourses;

        }

       

    }
}
