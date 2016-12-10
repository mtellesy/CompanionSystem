using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class EnrollmentS:Template
    {
        public static bool enrollmentStatus()
        {
            bool status=false;
            String path = "enrollment/status/";
            String type = "GET";
            return status;
        }
        public static List<Course> getAvailableCourses()
        {
            List<Course> courses = new List<Course>();
            String path = "/enrollment/" + User.use_id;


            return courses;
        }
        public static void sendEnrolledCourses(List<Course> courses)
        {
            String path = "/enrollment/" + User.use_id;

        }

        public static void sendDroppedCourses(List<Course> couses)
        {
            String path = "/enrollment/" + User.use_id;
        }
        //  TOTO NEEDS TO KNOW ABOUT ADDING IS GROUP FULL API
    }
}
