using CScore.BCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CScore.SAL
{
  public static class CourseS 
    {
        /*        set path to(endpoint path)
        Initialize Object to(Received Object) \\ only if it’s a(send) method
        Initialize received_object
        received_object = AuthenticationS.sendRequest(path) \\ only if it’s a(send) method
        Initialize Final_object // has the object type of the returned parameter type
        Store received_objec in Final_object
        Return Final_object*/
        // public static List<String> response { set; get; }

        public static List<Course> getCourses()
        {
            String path;
            path = "";
            if (User.use_typeID == 0) {
                path = "/users/"+User.use_id+"/courses";
            }
            else
            {
                path = "/students/" + User.use_id + "/ courses";

            }
            //  TOTO NEEDS TO SAVE THE DAY HERE :) >.<
            List<Course> courses = new List<Course>();
            //  TOTO NEEDS TO SAVE THE DAY AGAIN :d
            return courses;
        }

        // get ENROLLED COURSES
        public static List<Course> getEnrolledCourses()
        {
            List<Course> courses = new List<Course>();
            List<Course> enrolledCourses = new List<Course>();
            courses = getCourses();
            foreach(Course x in courses)
            {
                if (x.Ter_id == Semester.current_term)
                {
                    enrolledCourses.Add(x);
                }
            }
            return enrolledCourses;
        }



    }
}
