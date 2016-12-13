using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class SemesterS
    {
        
        public static async Task<StatusWithObject<Semester>> getCurrentSemester()
        {
            Semester semester = new Semester();
            String path = "/term";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();
            Status status = new Status();
            Semester result = new Semester();
            int code;

            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    SemesterObject semesterResult = JsonConvert.DeserializeObject<SemesterObject>(jsonString);
         
                    result= SemesterObject.convertToSemester(semesterResult);
                    status.message = "Course current semester retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    result = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = result;
            return returnedValue;

        }
        // not yet done
        public static  async Task<StatusWithObject<List<Course>>> getUserSchedule()
        {
            StatusWithObject<List<Course>> courses = new StatusWithObject<List<Course>>();
            List<Course> enrolleCourses = new List<Course>();
            String path = "/schedule";
            courses =await getCoursesTimetable();
            if (courses.status.status == true)
            {
                return courses;

            }else
            {
                return null;
            }

            
            // calls for the same path as get courses schedule but only courses the user enrolled in 
        }


        public static async Task<StatusWithObject<Semester>> getSemesterSchedule()
        {
            String path = "/term/schedule";            
            Semester semester = new Semester();
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();
            Status status = new Status();
            Semester result = new Semester();
            int code;
                       
            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    SemesterObject semesterResult = JsonConvert.DeserializeObject<SemesterObject>(jsonString);
         
                    result= SemesterObject.convertToSemester(semesterResult);
                    status.message = "Term schedule retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    result = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = result;
            return returnedValue;
        }

        public static async Task<StatusWithObject<List<Course>>> getCoursesTimetable()
        {
            List<Course> courses = new List<Course>();
            String path = "/schedule";
            Schedule schedules = new Schedule();
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            Status status = new Status();
            Course temp = new Course();
            int code;

            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    List<CourseObject> courseResult = JsonConvert.DeserializeObject<List<CourseObject>>(jsonString);
                    foreach( CourseObject x in courseResult)
                    {
                        temp = CourseObject.convertToCourse(x);
                        courses.Add(temp);
                    }
                    status.message = "Courses retrieved successfully ";
                    status.status = true;
                    break;

                default:
                    courses = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = courses;
            return returnedValue;
        }

      
    }
}
