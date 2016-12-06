using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public static class Enrollment
    {
        private static int creditSum{ get; set; }
        private static int creditMax { get; set; }
        private static List<int> reservedLectureTimes{ get; set; }
        private static List<Course> enrollableCourses { get; set; }
        private static List<Course> enrolledCourses { get; set; }

        private static bool isCreditAtMax()
        {
            if (creditMax == creditSum || creditMax>= creditSum)
                return true;
            else 
                return false;
            
        }

        private static bool isTimeReserved(int time)
        {
            if (reservedLectureTimes.Contains(time))
                return true;
            else
                return false;
        }

        private static bool isGroupFull(String course_id, int group_id)
        {
            bool result = false;
            //result = SAL.getIsGroupFull();
            return result;
        }

        //      CHECK IF A CERTAIN COURSE IS ENROLLABLE
        private static Status isEnrollable(Course c)
        {
            Status s1 = new Status();
            s1.status = true;
            s1.message = "";
            int time = 0;
            bool res1, res2, res3;
            res1= isCreditAtMax();
            if (res1)
            {
                s1.message += "Sorry, you have reached the maximum limit of credit for this semester.";
            }
            res2 = isGroupFull(c.cou_id, c.gro_id);
            if (res2)
            {
                s1.message += "Sorry, the group is full.";                
            }
            res3=isTimeReserved(time);
            if (res3)
            {
                s1.message += "Sorry, the group's lecture time conflects with another subject.";                
            }
            if (res1 || res2 || res3)
            {
                s1.status = false;
            }
            return s1;
        }

        private static void addCreditSum(Course c)
        {
            creditSum += c.cou_credits;
        }

        private static void subCreditSum(Course c)
        {
            creditSum -= c.cou_credits;
        }

        private static void addReservedLectureTime(Course c)
        {
            reservedLectureTimes.Add(c.classTimeID);
            reservedLectureTimes.Add(c.classTimeID2);
        }

        private static void deleteReservedLectureTime(Course c)
        {
            reservedLectureTimes.Remove(c.classTimeID);
            reservedLectureTimes.Remove(c.classTimeID2);
        }

        
        public static List<Course> getEnrollableCourses()
        {

           //  enrollableCourses= SAL.getAvailableCourses(User.use_id);
            return enrollableCourses;
        }

        /*
        public static List<Courses> getEnrolledCourses()
        {

            // enrolledCourses= SAL.EnrollmentS.getEnrolledCourses(User.use_id);
            return enrolledCourses;
        }*/
        /*
        public static Status enrollCourse(String cou_id, int cou_group)
        {
            return SAL.EmrollmentS.sendEnrolledCourse(User.use_id,cou_id,cou_group);
        }*/
        /*
        public static bool isEnrollmentEnabled()
        {
            return SAL.EnrollmentS.enrollmentStatus()
        }*/

      /*  public static Status dropCourse(String cou_id)
        {
            Course c1 = new Course();
       //     c1.getCourse(cou_id);
            subCreditSum(c1);
            deleteReservedLectureTime(c1);
            deleteReservedLectureTime(c1);
            //    c1.deleteCourse();
            return SAL.EnrollmentS.sendDroppedCourses(User.use_id, c1.cou_id);
        }*/
        public static void saveEnrolledCourses()
        {
            foreach ( Course x in enrolledCourses)
            {
            //    x.deleteCourse();
            }
        }
    }
}
