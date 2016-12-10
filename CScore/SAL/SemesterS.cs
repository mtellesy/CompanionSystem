using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class SemesterS:Template
    {
        /*getCurrentSemester(): List<String>
getUserSchedule(User id): List<Schedule>

getSemesterSchedule(): List<Timetable>
getCoursesTimetable(): List<Schedule>
*/
        public static Semester getCurrentSemester()
        {
            Semester semester = new Semester();
            String path = "/term";
            return semester;
        }

        public static List<Schedule> getUserSchedule()
        {
            List<Schedule> schedule = new List<Schedule>();
            String path = "/schedule";
            return schedule;
            // calls for the same path as get courses schedule but omly courses the user enrolled in 
        }
        public static Semester getSemesterSchedule()
        {
            Semester semester = new Semester();
            String path = "/term/schedule";
            return semester;
        }

        public static List<Schedule> getCoursesTimetable()
        {
            List<Schedule> schedule = new List<Schedule>();
            List<Course> course = new List<Course>();
            String path = "/schedule";
            return schedule;
        }

    }
}
