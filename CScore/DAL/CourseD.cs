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
        public static async Task<Course> getCourse(String courseID,String type)
        {
            Course course = new Course();
            var checker = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(courseID)).CountAsync();
            if (checker > 0)
            {
                var results = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(courseID)).FirstAsync();
                course.cou_id = results.Cou_id;
                course.cou_nameAR = results.Cou_nameAR;
                course.cou_nameEN = results.Cou_nameEN;
                if (type == "S" || type == "Student" || type == "student")
                {
                    var credits = await DBuilder._connection.Table<StudentCoursesL>().Where(
                        i => i.Cou_id.Equals(course.cou_id)).ToListAsync();

                    if (credits.Count() > 0)
                    {
                        var courseC = credits.First();
                        course.cou_credits = courseC.Cou_credits;
                    }
                }
                else course.cou_credits = 0;
                return course;
            }
            else return null;
          
        }

        public static async Task<List<Course>> getUserCoursesSchedule(int termID)
        {
            List<Course> courses = new List<Course>();

            var checker = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Ter_id.Equals(termID)).CountAsync();

            if (checker > 0)
            {
                // get courses info from scheduleL table 

                var results = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Ter_id.Equals(termID)).ToListAsync();

                //now after we got every course the user is enrolled in (or teaching) we must fetch the shedule for every course group
                foreach (var data in results)
                {
                    // first the get the basic info of the course
                    Course course = new Course();
                    course.cou_id = data.Cou_id;
                    course.cou_nameAR = data.Cou_nameAR;
                    course.cou_nameEN = data.Cou_nameEN;

                    // now get the schedule for each course group 
                    var schedule = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(data.Cou_id)).Where(i => i.Gro_id.Equals(data.Gro_id)).ToListAsync();

                    foreach (var courseGro in schedule)
                    {
                        Schedule courseSchedule = new Schedule();
                        courseSchedule.gro_id = courseGro.Gro_id;
                        courseSchedule.gro_NameAR = courseGro.Gro_nameAR;
                        courseSchedule.gro_NameEN = courseGro.Gro_nameEN;
                        courseSchedule.tea_id = courseGro.Tea_ID;
                        courseSchedule.classRoomAR = courseGro.classRoomAR;
                        courseSchedule.classRoomEN = courseGro.classRoomEN;
                        courseSchedule.classRoomID = courseGro.classRoomID;
                        courseSchedule.classTimeID = courseGro.classTimeID;
                        courseSchedule.classStart = courseGro.classStart;
                        courseSchedule.classDuration = courseGro.classDuration;
                        courseSchedule.dayID = courseGro.dayID;
                        //days name will be named based on the id from 1-7 from sat to fri
                        course.schedule.Add(courseSchedule);
                    }
                    courses.Add(course);
                }

                return courses;
            }
            else return null;
          
        }

        public static async Task saveUserCoursesSchedule(List<Course> courses)
        {
            ScheduleL schedule = new ScheduleL();

            foreach(Course course in courses)
            {
                schedule.Cou_id = course.cou_id;
                schedule.Cou_nameAR = course.cou_nameAR;
                schedule.Cou_nameEN = course.cou_nameEN;
                schedule.Ter_id = course.Ter_id;
                foreach(Schedule courseSchedule in course.schedule)
                {
                    schedule.Gro_id = courseSchedule.gro_id;
                    schedule.Gro_nameAR = courseSchedule.gro_NameAR;
                    schedule.Gro_nameEN = courseSchedule.gro_NameEN;
                    schedule.Tea_ID = courseSchedule.tea_id;
                    schedule.dayID = courseSchedule.dayID;
                    schedule.classTimeID = courseSchedule.classTimeID;
                    schedule.classStart = courseSchedule.classStart;
                    schedule.classDuration = courseSchedule.classDuration;
                    schedule.classRoomID = courseSchedule.classRoomID;
                    schedule.classRoomAR = courseSchedule.classRoomAR;
                    schedule.classRoomEN = courseSchedule.classRoomEN;
                    //now add it to database so you'll have row for every course time
                    //but before that make sure that the coulmn does exsits
                    var checker = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(schedule.Cou_id))
                        .Where(i => i.Gro_id.Equals(schedule.Gro_id))
                        .Where(i => i.classTimeID.Equals(schedule.classTimeID)).CountAsync();
                    if (checker <= 0)
                        await DBuilder._connection.InsertAsync(schedule);
                    else
                        await DBuilder._connection.UpdateAsync(schedule);
                }
            }
           
        }

      
    }
}
