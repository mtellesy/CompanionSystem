using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CScore.SAL
{
  public static class CourseS 
    {        

        public static async Task<StatusWithObject<List<Course>>> getCourses()
        {

            String path = "/courses";            
            List<Course> courses = new List<Course>();
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
                    foreach (CourseObject x in courseResult)
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

        // get ENROLLED COURSES
        public static async Task<StatusWithObject<List<Course>>> getEnrolledCourses()
        {

            String path = "";
            if (User.use_typeID == 0)
            {
                 path = "/users/" + User.use_id + "/courses";
            }
            else
            {
                 path = "/students/" + User.use_id + "/ courses";

            }
            List<Course> courses = new List<Course>();
            Schedule schedules = new Schedule();
            String requestType = "GET";
            path = path + String.Format("?token={0}", AuthenticatorS.token);

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            Status status = new Status();
            Course temp = new Course();
            int code;
            StatusWithObject<String> auth = new StatusWithObject<String>();
            StatusWithObject<String> log = new StatusWithObject<String>();

            auth = await AuthenticatorS.authenticate();
            code = auth.statusCode;

            if (auth.status.status == false)
            {
                if (code == 401)
                {
                    log = await AuthenticatorS.login(User.use_id, User.password);
                    if (log.status.status == false)
                    {
                        returnedValue.status = log.status;
                        returnedValue.statusCode = log.statusCode;
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                }
                else
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }
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
                    foreach (CourseObject x in courseResult)
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
