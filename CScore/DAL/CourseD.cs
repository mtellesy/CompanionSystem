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
                course.Cou_id = results.Cou_id;
                course.Cou_nameAR = results.Cou_nameAR;
                course.Cou_nameEN = results.Cou_nameEN;
                if (type == "S" || type == "Student" || type == "student")
                {
                    var credits = await DBuilder._connection.Table<StudentCoursesL>().Where(
                        i => i.Cou_id.Equals(course.Cou_id)).ToListAsync();

                    if (credits.Count() > 0)
                    {
                        var courseC = credits.First();
                        course.Cou_credits = courseC.Cou_credits;
                    }
                }
                else course.Cou_credits = 0;
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
                    course.Cou_id = data.Cou_id;
                    course.Cou_nameAR = data.Cou_nameAR;
                    course.Cou_nameEN = data.Cou_nameEN;
                    
                    course.Schedule = new List<Schedule>();

                    // now get the schedule for each course group 
                    var schedule = await DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(data.Cou_id)).Where(i => i.Gro_id.Equals(data.Gro_id)).
                        Where(i => i.dayID.Equals(data.dayID)).Where(i => i.Ter_id.Equals(termID)).ToListAsync();

                    foreach (var courseGro in schedule)
                    {
                        Schedule courseSchedule = new Schedule();
                        courseSchedule.Gro_id = courseGro.Gro_id;
                        courseSchedule.Gro_NameAR = courseGro.Gro_nameAR;
                        courseSchedule.Gro_NameEN = courseGro.Gro_nameEN;
                        courseSchedule.Tea_id = courseGro.Tea_ID;
                        courseSchedule.ClassRoomAR = courseGro.classRoomAR;
                        courseSchedule.ClassRoomEN = courseGro.classRoomEN;
                        courseSchedule.ClassRoomID = courseGro.classRoomID;
                        courseSchedule.ClassTimeID = courseGro.classTimeID;
                        courseSchedule.ClassStart = courseGro.classStart;
                        courseSchedule.ClassDuration = courseGro.classDuration;
                        courseSchedule.DayID = courseGro.dayID;
                        //days name will be named based on the id from 1-7 from sat to fri
                        course.Schedule.Add(courseSchedule);
                    }
                    courses.Add(course);
                }

                return courses;
            }
            else return null;
          
        }

        public static async Task saveUserCoursesSchedule(List<Course> courses)
        {
            

            foreach(Course course in courses)
            {
                ScheduleL schedule = new ScheduleL();
                schedule.Cou_id = course.Cou_id;
                schedule.Cou_nameAR = course.Cou_nameAR;
                schedule.Cou_nameEN = course.Cou_nameEN;
               
                schedule.Ter_id = course.Ter_id;
                
                
               
                foreach (Schedule courseSchedule in course.Schedule)
                {
                    schedule.Gro_id = courseSchedule.Gro_id;
                    schedule.Gro_nameAR = courseSchedule.Gro_NameAR;
                    schedule.Gro_nameEN = courseSchedule.Gro_NameEN;
                    schedule.Tea_ID = courseSchedule.Tea_id;
                    schedule.dayID = courseSchedule.DayID;
                    schedule.classTimeID = courseSchedule.ClassTimeID;
                    schedule.classStart = courseSchedule.ClassStart;
                    schedule.classDuration = courseSchedule.ClassDuration;
                    schedule.classRoomID = courseSchedule.ClassRoomID;
                    schedule.classRoomAR = courseSchedule.ClassRoomAR;
                    schedule.classRoomEN = courseSchedule.ClassRoomEN;
                    //now add it to database so you'll have row for every course time
                    //but before that make sure that the coulmn does exsits
                    var checker =  DBuilder._connection.Table<ScheduleL>().Where(i => i.Cou_id.Equals(schedule.Cou_id))
                        .Where(i => i.Gro_id.Equals(schedule.Gro_id))
                        .Where(i => i.dayID.Equals(schedule.dayID));
                    int count = await checker.CountAsync();
                    if(count > 0)
                    {
                        var t = await checker.FirstAsync();
                        schedule.id = t.id;
                    }
                    
                    if (count <= 0)
                        await DBuilder._connection.InsertAsync(schedule);
                    else
                    {
                       
                       
                        await DBuilder._connection.UpdateAsync(schedule);
                    }
                      
                }
              
            }
           
        }

        public static async Task saveStudentSemesterCourses(Course c)
        {
            CScore.DataLayer.Tables.StudentCoursesL studentCourses = new StudentCoursesL();
            studentCourses.Cou_id = c.Cou_id;
            studentCourses.Cou_credits = c.Cou_credits;
           // studentCourses.finalMark = 0;
            studentCourses.Ter_id = Semester.current_term;
            var results = DBuilder._connection.Table<StudentCoursesL>().Where(i => i.Cou_id.Equals(c.Cou_id)).Where(
                i => i.Ter_id.Equals(studentCourses.Ter_id));


            if (await results.CountAsync() <= 0)
            {
                await DBuilder._connection.InsertAsync(studentCourses);
            }
            else
            {
                await DBuilder._connection.UpdateAsync(studentCourses);
            }

          
        }

        public static async Task<List<Course>> getStudentSemesterCourses()
        {
            List<Course> c = new List<Course>();
            var results = await DBuilder._connection.Table<StudentCoursesL>().Where(i => i.Ter_id.Equals(Semester.current_term)).ToListAsync();//NEEDS NOT NULL OPERATOR FOR FINALMARK

            if (results.Count > 0)
            {
                foreach (var x in results)
                {
                    Course ReturnedCourse = new Course();
                    ReturnedCourse.Cou_id = x.Cou_id;
                    ReturnedCourse.Tea_id = x.Tea_id;
                    ReturnedCourse.Ter_id = x.Ter_id;
                
                    c.Add(ReturnedCourse);
                }
                return c;
            }
            else
            {
                return null;
            }
        }

    }
}
