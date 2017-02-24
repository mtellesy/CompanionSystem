using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    class ReservedDayAndTime
    {
        public String courseID { get; set; }
        public int dayID { get; set; }
        public int classTimeID { get; set; }
    }

    public static class Enrollment
    {
        //  *** Properties ***
        /// <summary>
        /// The total number of enrolled courses credits.
        /// </summary>
        private static int creditSum{ get; set; }
        /// <summary>
        /// The maximum number of credit allowd for student to have in the enrollment
        /// process.
        /// </summary>
        public static int creditMax { get; set; }
        /// <summary>
        /// The minimum number of credit allowd for student to have in the disenrollment
        /// process.(is used for courses disenrollment only)
        /// </summary>
        public static int creditMin { get; set; }  
        /// <summary>
        /// The list of reserved Days and Class Times.
        /// </summary>
        private static List<ReservedDayAndTime> reservedLectureTimes{ get; set; }
        /// <summary>
        /// List of Courses that The student can enroll.
        /// </summary>
        private static List<Course> enrollableCourses { get; set; }
        /// <summary>
        /// List of Courses that The student wants to enroll in.
        /// </summary>
        public static List<Course> enrolledCourses { get; set; }
        /// <summary>
        /// List of Courses that The student wants to drop.
        /// </summary>
        public static List<Course> dropedCourses { get; set; }


        //              *** Methods ***



        /// <summary>
        /// always call this method before the start of enrollment process,
        /// it will add the the already enrolled courses credit to credit sum
        /// and add their day and time to reserved Lectures time.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> StartEnrollmentAndGetCurrentCreditSum()
        {
            /// start fresh
            reservedLectureTimes = new List<ReservedDayAndTime>();
            enrolledCourses = new List<Course>();
            dropedCourses = new List<Course>();
            creditSum = 0;

            StatusWithObject<List<Course>> courses =
            await BCL.Course.getStudentCourses();



           

            foreach (Course course in courses.statusObject)
            {
                creditSum += course.Cou_credits;
            }

            /// now add the reserved Lecture times
            StatusWithObject<List<Course>> coursesWithSchedule
               = await BCL.Course.getUserCoursesSchedule();

            foreach (Course c in coursesWithSchedule.statusObject)
            {
                c.TemGro_id = c.Schedule[0].Gro_id;
                addReservedLectureTime(c, c.Schedule[0].Gro_id);
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

        private static bool isCreditAtMin()
        {
            if (creditMin == creditSum || creditMin >= creditSum)
                return true;
            else
                return false;

        }

        private static Status isTimeReserved(int time, int day)
        {
            Status returnedStatus = new Status();
            if (reservedLectureTimes == null)
            {
                returnedStatus.status = false;
                return returnedStatus;
            }
            var list = reservedLectureTimes.Where(i => i.dayID.Equals(day)).Where(i => i.classTimeID.Equals(time)).GroupBy(test => test.courseID)
                   .Select(grp => grp.First())
                   .ToList();
            int count = reservedLectureTimes.Where(i => i.dayID.Equals(day)).Where(i => i.classTimeID.Equals(time)).Count();
            //foreach()

            if (count>0)
            {
                returnedStatus.status = true;
                returnedStatus.message = "(";
                    int x = 0;
                foreach(String conflictedCourse in list.Select(i=> i.courseID).ToList())
                {
                    if (x > 0 || x < list.Count() - 1) returnedStatus.message += ",";
                  //  if(x >= list.Count())
                   returnedStatus.message += " " + conflictedCourse;
                    x++;
                }
              //  returnedStatus.message += ").";
                return returnedStatus;

            }
            else
            {
                returnedStatus.status = false;
                return returnedStatus;
            }
               
        }
        // not done yet
        private static bool isGroupFull(String course_id, int group_id)
        {
            bool result = false;
            //result = SAL.getIsGroupFull();
            return result;
        }

         
        /// <summary>
        ///CHECK IF A CERTAIN COURSE IS ENROLLABLE
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
            s1.message = "Sorry, the group's lecture time conflects with another subject(s):";
            foreach (Schedule schedule in c.Schedule)
            {
                time = schedule.ClassTimeID;
                day = schedule.DayID;
              var status = isTimeReserved(time,day);
                if (status.status)
                {
                    s1.message += status.message + " in " + schedule.DayEN + " at " + FixdStrings.Time.getTimeByID(schedule.ClassTimeID);
                    s1.message += " ) \n";
                    s1.status = false;
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

        public static int getCreditSum()
        {
            return creditSum;
        }

        private static void addReservedLectureTime(Course course, int gro_id)
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
                    timeDate.courseID = course.Cou_id;
                    reservedLectureTimes.Add(timeDate);
                }
            }
        }

        private static void deleteReservedLectureTime(Course course,int gro_id)
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

        
        /// <summary>
        /// Get the courses which the student can enroll in the current semester.
        /// </summary>
        /// <returns>Return Status of process wither it succeeded or faild, and the list of courses in case it succeeded</returns>
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


        /// <summary>
        /// know wither Enrollment is Enabled or not.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// know wither DisEnrollment is Enabled or not.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> isDisEnrollmentEnabled()
        {
            bool returnedValue = false;
            StatusWithObject<bool> temp = new StatusWithObject<bool>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                temp = await SAL.EnrollmentS.disEnrollmentStatus();
                returnedValue = temp.statusObject;
            }

            return returnedValue;
        }
        /// <summary>
        /// Drop Student Course.
        /// </summary>
        /// <param name="course">Course Object</param>
        /// <param name="gro_id">Group ID</param>
        /// <returns></returns>
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
        /// <summary>
        /// Add courses with TemGro_id to the list of courses the student wants to enroll in.
        /// </summary>
        /// <param name="c">Course object</param>
        public static void addToCourseList(Course c)
        {  
            if(enrolledCourses == null)
            {
                enrolledCourses = new List<Course>();
            }
            addReservedLectureTime(c,c.TemGro_id);
            addCreditSum(c);
            enrolledCourses.Add(c);
        }
        /// <summary>
        /// Add courses with TemGro_id to the list of courses the student wants to enroll in.
        /// </summary>
        /// <param name="c">Course object</param>
        public static void addToCourseList_Enrolled(Course c)
        {
           
            addReservedLectureTime(c, c.TemGro_id);
            addCreditSum(c);
           // enrolledCourses.Add(c);
        }
        /// <summary>
        /// remove courses with TemGro_id from the list of courses the student wants to enroll in.
        /// </summary>
        /// <param name="c">Course object</param>
        public static void removeFromCourseList(Course c)
        {
            subCreditSum(c);
            deleteReservedLectureTime(c, c.TemGro_id);

          int index = enrolledCourses.IndexOf(enrolledCourses.Where(i => i.Cou_id.Equals(c.Cou_id))
                      .Where(i => i.TemGro_id.Equals(c.TemGro_id)).First());

            enrolledCourses.Remove(enrolledCourses[index]);
        }

        /// <summary>
        ///  remove an already Enrolled course with TemGro_id from reserved time and its credit from credit sum.
        ///  without removing it from the list of course becasue it will not be there.
        /// </summary>
        /// <param name="c"></param>
        public static void removeFromCourseList_Enrolled(Course c)
        {
            subCreditSum(c);
            deleteReservedLectureTime(c, c.TemGro_id);
        }

        /// <summary>
        /// Add courses with TemGro_id to the list of courses the student wants to Drop.
        /// </summary>
        /// <param name="c">Course object</param>
        public static void addToDropList(Course c)
        {
            subCreditSum(c);
            deleteReservedLectureTime(c, c.TemGro_id);
            dropedCourses.Add(c);   
        }
        /// <summary>
        /// remove courses with TemGro_id from the list of courses the student wants to Drop.
        /// </summary>
        /// <param name="c">Course object</param>
        public static void removeFromDropList(Course c)
        {
            if (dropedCourses == null)
            {
                dropedCourses = new List<Course>();
            }
            addReservedLectureTime(c, c.TemGro_id);
            addCreditSum(c);
            var w = dropedCourses.ToList();
            var k = w.Where(i => i.Cou_id.Equals(c.Cou_id)).Where(i => i.TemGro_id.Equals(c.TemGro_id)).First();
            int index = dropedCourses.IndexOf(k);
            dropedCourses.Remove(dropedCourses[index]);
           
        }

        public static void addToDropList_Enrolled(Course c)
        {
           
            dropedCourses.Add(c);
        }

        public static void removeFromDropList_Enrolled(Course c)
        {
            if (dropedCourses == null)
            {
                dropedCourses = new List<Course>();
            }
       
            var w = dropedCourses.ToList();
            var k = w.Where(i => i.Cou_id.Equals(c.Cou_id)).Where(i => i.TemGro_id.Equals(c.TemGro_id)).First();
            int index = dropedCourses.IndexOf(k);
            dropedCourses.Remove(dropedCourses[index]);

        }
    }
}
