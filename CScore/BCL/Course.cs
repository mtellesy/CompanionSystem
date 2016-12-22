using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer;

namespace CScore.BCL
{
    public  class Course
    {
        //          done
        //              *** Properties ***
        String cou_id { get; set; }
         String cou_nameAR { get; set; }
         String cou_nameEN { get; set; }
         int ter_id { get; set; }
         int cou_credits { get; set; }
         List<Schedule> schedule { get; set; }
         int temGro_id { set; get; }// temporary group id that is used only for enrollment
         bool flag;//to know if it has been enrolled or not
        bool groupFull;// only when the group is full flag __ read only when false
        int tea_id;
        //              *** setters and getters ***
        //      cou_id
        public String Cou_id
        {
            set
            {
                cou_id = value;
            }
            get
            {
                return cou_id;
            }
        }
        //      cou_nameAR
        public String Cou_nameAR
        {
            set
            {
                cou_nameAR = value;
            }
            get
            {
                return cou_nameAR;
            }
        }
        //      cou_nameEN
        public String Cou_nameEN
        {
            set
            {
                cou_nameEN = value;
            }
            get
            {
                return cou_nameEN;
            }
        }
        //      ter_id
        public int Ter_id
        {
            set
            {
                ter_id = value;
            }
            get
            {
                return ter_id;
            }
        }
        //      cou_credits
        public int Cou_credits
        {
            set
            {
                cou_credits = value;
            }
            get
            {
                return cou_credits;
            }
        }
        //      schedule
        public List<Schedule> Schedule
        {
            set
            {
                schedule = value;
            }
            get
            {
                return schedule; 
            }
        }
        //      tempGro_id
        public int TemGro_id
        {
            set
            {
                temGro_id = value;
            }
            get
            {
                return temGro_id;
            }
        }
        //      flag
        public bool Flag
        {
            set
            {
                flag = value;
            }
            get
            {
                return flag;
            }
        }
        //      groupFull
        public bool GroupFull
        {
            set
            {
                groupFull = value;
            }
            get
            {
                return groupFull;
            }
        }
        //      tea_id
        public int Tea_id
        {
            set
            {
                tea_id = value;
            }
            get
            {
                return tea_id;
            }
        }

        //              *** Methods ***

        public static async Task<StatusWithObject<List<Course>>> getCourses(String courseID)
        {
            Course result = new Course();
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.CourseS.getCourses(courseID, null, null);
              
            }
            else
            {
                returnedValue.statusObject = null;
                returnedValue.statusCode = 1;
                returnedValue.status.message = SAL.FixedResponses.getResponse(returnedValue.statusCode);
                returnedValue.status.status = false;
            }
          
            return returnedValue;
        }
        //  overload
        public static async Task<StatusWithObject<List<Course>>> getCourses( int dep_id)
        {
            Course result = new Course();
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.CourseS.getCourses(null, dep_id.ToString(), null);

            }
            else
            {
                returnedValue.statusObject = null;
                returnedValue.statusCode = 1;
                returnedValue.status.message = SAL.FixedResponses.getResponse(returnedValue.statusCode);
                returnedValue.status.status = false;
            }
            return returnedValue;
        }
        //  overload
        public static async Task<StatusWithObject<List<Course>>> getCourses(int dep_id, int branch)
        {
            Course result = new Course();
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.CourseS.getCourses(null,dep_id.ToString(), branch.ToString());

            }
            else
            {
                returnedValue.statusObject = null;
                returnedValue.statusCode = 1;
                returnedValue.status.message = SAL.FixedResponses.getResponse(returnedValue.statusCode);
                returnedValue.status.status = false;
            }

            return returnedValue;
        }
        //  overload
        public static async Task<StatusWithObject<List<Course>>> getCourses()
        {
            Course result = new Course();
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.CourseS.getCourses(null, null, null);

            }
            else
            {
                returnedValue.statusObject = null;
                returnedValue.statusCode = 1;
                returnedValue.status.message = SAL.FixedResponses.getResponse(returnedValue.statusCode);
                returnedValue.status.status = false;
            }

            return returnedValue;
        }


        public static async Task<StatusWithObject<List<Course>>> getUserCoursesSchedule()
        {
            Course result = new Course();
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.CourseS.getEnrolledCourses();
                if (returnedValue.status.status == true)
                {
                    await DAL.CourseD.saveUserCoursesSchedule(returnedValue.statusObject);
                }
                returnedValue.statusObject = new List<Course>();
            }
            returnedValue.statusObject = await DAL.CourseD.getUserCoursesSchedule(BCL.Semester.current_term);
           

            return returnedValue;

        }


    }
}
