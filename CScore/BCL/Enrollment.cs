using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    class ReservedDayAndTime
    {
        public int dayID { get; set; }
        public int classTimeID { get; set; }
    }

    public static class Enrollment
    {
        //              done
        //              *** Properties ***
        private static int creditSum{ get; set; }
        public static int creditMax { get; set; }
        private static List<ReservedDayAndTime> reservedLectureTimes{ get; set; }
        private static List<Course> enrollableCourses { get; set; }
        private static List<Course> enrolledCourses { get; set; }

        //              *** Methods ***



        /// <summary>
        /// always call this method before the start of enrollment process
        /// </summary>
        /// <returns></returns>
        public static async Task<int> getCurrentCreditSum()
        {
            StatusWithObject<List<Course>> courses =
            await BCL.Course.getStudentCourses();

           creditSum = 0;

            foreach(Course course in courses.statusObject)
            {
                creditSum += course.Cou_credits;
            }

            return creditSum;
        }

        private static bool isCreditAtMax()
        {
            if (creditMax == creditSum || creditMax <= creditSum)
                return true;
            else 
                return false;
            
        }

        private static bool isTimeReserved(int time, int day)
        {
            if (reservedLectureTimes == null)
            {
                return false;
            }

            //ReservedDayAndTime dayTime = new ReservedDayAndTime();
            //dayTime.dayID = day;
            //dayTime.classTimeID = time;

            int count = reservedLectureTimes.Where(i => i.dayID.Equals(day)).Where(i => i.classTimeID.Equals(time)).Count();
            if (count>0)
                return true;
            else
                return false;
        }
        // not done yet
        private static bool isGroupFull(String course_id, int group_id)
        {
            bool result = false;
            //result = SAL.getIsGroupFull();
            return result;
        }

        //      CHECK IF A CERTAIN COURSE IS ENROLLABLE
        public static Status isEnrollable(Course c)
        {
            Status s1 = new Status();
            s1.status = true;
            s1.message = "";
            bool res1, res2, res3;
            res1 = isCreditAtMax();
            if (res1)
            {
                s1.message += "Sorry, you have reached the maximum limit of credit for this semester.";
                s1.status = false;
                return s1;
            }
            //res2 = isGroupFull(c.Cou_id, c.Schedule[0].Gro_id);
            //if (res2)
            //{
            //    s1.message += "Sorry, the group is full.";
            //    s1.status = false;
            //    return s1;
            //}

            int time = 0;
            int day = 0;
            foreach(Schedule schedule in c.Schedule)
            {
                time = schedule.ClassTimeID;
                day = schedule.DayID;
                res3 = isTimeReserved(time,day);
                if (res3)
                {
                    s1.message += "Sorry, the group's lecture time conflects with another subject.";
                    s1.status = false;
                    return s1;

                }
            }
            return s1;

        }

        private static void addCreditSum(Course c)
        {
            creditSum += c.Cou_credits;
        }

        private static void subCreditSum(Course c)
        {
            creditSum -= c.Cou_credits;
        }

        public static void addReservedLectureTime(Course course, int gro_id)
        {
            if(reservedLectureTimes == null)
            reservedLectureTimes = new List<ReservedDayAndTime>();
            foreach(Schedule x in course.Schedule)
            {
                if (x.Gro_id == gro_id)
                {
                    ReservedDayAndTime timeDate = new ReservedDayAndTime();
                    timeDate.classTimeID= x.ClassTimeID;
                    timeDate.dayID = x.DayID;
                    reservedLectureTimes.Add(timeDate);
                }
            }
        }

        public static void deleteReservedLectureTime(Course course,int gro_id)
        {
            foreach (Schedule x in course.Schedule)
            {
                if (x.Gro_id == gro_id)
                {
                    ReservedDayAndTime timeDate = new ReservedDayAndTime();
                    //timeDate.dayID = x.DayID;
                    //timeDate.classTimeID = x.ClassTimeID;
                    timeDate = reservedLectureTimes.Where(i => i.dayID.Equals(x.DayID))
                        .Where(i => i.classTimeID.Equals(x.ClassTimeID)).First();

                    reservedLectureTimes.Remove(timeDate);
                }
            }
        }

        
        public static async Task<StatusWithObject<List<Course>>> getEnrollableCourses()
        {
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.EnrollmentS.getAvailableCourses();
            }
            else
            {
                returnedValue = null;
            }
            return returnedValue;
        }

        //          enroll couses
        public static async Task<StatusWithObject<object>> enrollCourse(Course course, String force)
        {
            // List<AllResult> result = new List<AllResult>();
            StatusWithObject<object> returnedValue = new StatusWithObject<object>();
            List<Course> temp = new List<Course>();
            temp.Add(course);
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.EnrollmentS.sendEnrolledCourses(temp, force);
            }

            return returnedValue;
        }
        //      overload
        public static async Task<StatusWithObject<object>> enrollCourse(List<Course> course, String force)
        {
            // List<AllResult> result = new List<AllResult>();
            StatusWithObject<object> returnedValue = new StatusWithObject<object>();

            OtherUsers user = new OtherUsers();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.EnrollmentS.sendEnrolledCourses(course, force);
                if (returnedValue.status.status == true)
                {
                    List<Course> courses = new List<Course>();
                    course = (List<Course>)returnedValue.statusObject;
                    foreach(Course x in course)
                    {
                        user.use_id = x.Tea_id;
                        
                    }
                }
            }

            return returnedValue;
        }
        //      overload
        public static async Task<StatusWithObject<object>> enrollCourse(Course course)
        {
            // List<AllResult> result = new List<AllResult>();
            StatusWithObject<object> returnedValue = new StatusWithObject<object>();
            List<Course> temp = new List<Course>();
            temp.Add(course);
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.EnrollmentS.sendEnrolledCourses(temp, null);
            }

            return returnedValue;
        }
        //      overload
        public static async Task<StatusWithObject<object>> enrollCourse(List<Course> course)
        {
            // List<AllResult> result = new List<AllResult>();
            StatusWithObject<object> returnedValue = new StatusWithObject<object>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.EnrollmentS.sendEnrolledCourses(course, null);
            }

            return returnedValue;
        }


        public static async Task<bool> isEnrollmentEnabled()
        {
            bool returnedValue = false;
            StatusWithObject<bool> temp = new StatusWithObject<bool>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                temp = await SAL.EnrollmentS.enrollmentStatus();
                returnedValue = temp.statusObject;
            }
            
            return returnedValue;
        }

        public static async  Task<StatusWithObject<Status>> dropCourse(Course course,int gro_id)
        {
            StatusWithObject<Status> returnedValue = new StatusWithObject<Status>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue= await SAL.EnrollmentS.sendDroppedCourses(course);
                if (returnedValue.statusObject.status == true)
                {
                    subCreditSum(course);
                    deleteReservedLectureTime(course, gro_id);
                }
            }
            return returnedValue;
        }

        
    }
}
