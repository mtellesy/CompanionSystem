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
        //              done
        //              *** returns the current semester ***
        public static async Task<StatusWithObject<Semester>> getCurrentSemester()
        {
            //      declaration of path and request type
            String path = "/term";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();            
            Status status = new Status();
            Semester semester = new Semester();
            int code;

            //      data retrieval  part
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
                    semester = SemesterObject.convertToSemester(semesterResult);
                    status.message = "current semester retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    semester = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = semester;
            return returnedValue;

        }

        //              *** returns  semester schedule ***

        public static async Task<StatusWithObject<Semester>> getSemesterSchedule()
        {
            //      declaration of path and request type
            String path = "/term/schedule";            
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();
            Status status = new Status();
            Semester semester = new Semester();
            int code;

            //      data retrieval  part
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
                    semester = SemesterObject.convertToSemester(semesterResult);
                    status.message = "Term schedule retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    semester = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = semester;
            return returnedValue;
        }

        //              *** returns a list of all courses and their schedule ***
        public static async Task<StatusWithObject<List<Course>>> getCoursesTimetable()
        {
            //      declaration of path and request type
            String path = "/schedule";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            Status status = new Status();
            Course temp = new Course();
            int code;

            //      data retrieval  part
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            List<Course> courses = new List<Course>();
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
