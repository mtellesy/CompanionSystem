using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;
using CScore.DataLayer;
using CScore.BCL;
using SQLite.Net;

namespace CScore.DAL
{
    public static class CourseD
    {
        public static async Task<Course> getCourse(String courseID)
        {
            Course course = new Course();
            var results = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(courseID)).FirstAsync();
            course.cou_id = results.Cou_id;
            course.cou_nameAR = results.Cou_nameAR;
            course.cou_nameEN = results.Cou_nameEN;
            return course;
        }

        public static async Task<List<Course>> getUserCoursesSchedule(int termID)
        {
            List<Course> courses = new List<Course>();
            // get courses info from scheduleL table 

            var results = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Ter_id.Equals(termID)).ToListAsync();

            //now after we got every course the user is enrolled in (or teaching) we must fetch the shedule for every course group
            foreach(var data in results)
            {
                // first the get the basic info of the course
                Course course = new Course();
                course.cou_id = data.Cou_id
                course.cou_nameAR = data.Cou_nameAR;
                course.cou_nameEN = data.Cou_nameEN;

                // now get the schedule for each course group 
            var schedule = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(data.Cou_id)).Where(i => i.Gro_id.Equals(data.Gro_id)).ToListAsync();

                foreach(var courseGro in schedule)
                {
                    Schedule courseSchedule = new Schedule();
                    courseSchedule.classRoomAR = courseGro.classRoomAR;
                    courseSchedule.classRoomEN = courseGro.classRoomEN;
                    courseSchedule.classRoomID = courseGro.classRoomID;
                    courseSchedule.classTimeID = courseGro.classTimeID;
                    courseSchedule.classStart = courseGro.classStart;
                    //complete the rest
                }
            }


            return courses;
        }
    }
}
