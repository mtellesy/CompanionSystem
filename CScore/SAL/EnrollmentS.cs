using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class EnrollmentS
    {
        //              done ^.^
        //              *** returns enrollment status***
        public static async Task<StatusWithObject<bool>> enrollmentStatus()
        {
            // declaration of path and request type

            String path = "/enrollment/status";
           

            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      declaration of the returned value and its contents
            StatusWithObject<bool> returnedValue = new StatusWithObject<bool>();
            bool enrollment = false;
            Status status = new Status();
            int code;

            //      use this only if the endpoint tag = security  

            //      authentication part
            StatusWithObject<bool> auth = new StatusWithObject<bool>();
            auth = await AuthenticatorS.autoAuthentication<bool>();
            if (auth.status.status == false)
            {
                return auth;
            }

            String Path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      data retrieval  part
            req = await AuthenticatorS.sendRequest(Path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = false;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    EnrollmentObject results = JsonConvert.DeserializeObject<EnrollmentObject>(jsonString);
                    BCL.Enrollment.creditMax = results.allowed_credits;
                    enrollment = results.status;
                    status.message = "Enrollment status returned";
                    status.status = true;
                    break;

                default:
                    results = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = enrollment;
            return returnedValue;

        }

        //              *** returns the courses that are available for the student to enroll***
        public static async Task<StatusWithObject<List<Course>>> getAvailableCourses()
        {
            //      declaration of path and request type
            String path = "/enrollment/" + User.use_id;
            String requestType = "GET";
           

            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      declaration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            List<Course> courses = new List<Course>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Course>> auth = new StatusWithObject<List<Course>>();
            auth = await AuthenticatorS.autoAuthentication<List<Course>>();
            if (auth.status.status == false)
            {
                return auth;
            }
            path = path + String.Format("?token={0}", AuthenticatorS.token);
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
                    List<CourseObject> courseResult = JsonConvert.DeserializeObject<List<CourseObject>>(jsonString);
                    Course temp = new Course();
                    foreach(CourseObject x in courseResult)
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

        //              *** sends courses that student wants to enroll in, returns an object ***
        public static async Task<StatusWithObject<Object>> sendEnrolledCourses(List<Course> courses, String forse)
        {
            //      declaration of path and request type
            String path = "/enrollment/" + User.use_id+"?";            
            if (forse != null)
            {
                path += "forse={0}&" + forse;
            }
           


            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            List<CourseObject> coursesToEnroll = new List<CourseObject>();
            foreach (Course x in courses)
            {
                coursesToEnroll.Add(CourseObject.convertToCourseObjectForEnrollment(x));
            }
            String jsonString;
            jsonString = JsonConvert.SerializeObject(coursesToEnroll);


            //      declaration of the returned value and its contents
            StatusWithObject<Object> returnedValue = new StatusWithObject<Object>();
            Status resultStatus = new Status();
            Status status = new Status();
            int code;


            //      authentication part
            StatusWithObject<object> auth = new StatusWithObject<object>();
            auth = await AuthenticatorS.autoAuthentication<Object>();
            if (auth.status.status == false)
            {
                return auth;
            }

            path = path + String.Format("token={0}", AuthenticatorS.token);
            String requestType = "POST";

            //      data retrieval  part (request and response)
            req = await AuthenticatorS.sendRequest(path, jsonString, requestType);

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
                case 201:
                    status.message = "Courses Enrollment Succeeded.";
                    status.status = true;
                    if (Convert.ToBoolean(forse))// only if forse flag true return list of courses 
                    { 

                       List<CourseObject> res = JsonConvert.DeserializeObject<List<CourseObject>>(jsonString);
                        List<Course> result = new List<Course>();
                        Course temp = new Course();
                        foreach (CourseObject x in res)
                        {
                            temp = CourseObject.convertToCourse(x);
                            result.Add(temp);
                         }
                        returnedValue.statusObject = result;
                    }
                    else
                    {
                        returnedValue.statusObject = null ;
                    }
                    break;
                case 401:
                    status.message = "Failed attempt.";
                    status.status = false;
                    MessageObject result2 = JsonConvert.DeserializeObject<MessageObject>(jsonString);
                    returnedValue.statusObject = result2;
                    break;
                case 409:
                    status.message = "Conflict.";
                    status.status = false;
                    returnedValue.statusObject = null;
                    break;
                case 422:
                    status.message = "Rejected entity.";
                    status.status = false;
                    returnedValue.statusObject = null;

                    break;

                default:
                    resultStatus = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    returnedValue.statusObject = null;

                    break;

            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            return returnedValue;

        }

        //              *** sends courses that student wants to drop in, returns a status ***
        public static async Task<StatusWithObject<Status>> sendDroppedCourses(Course course)
        {
            //      declaration of path and request type
            String path = "/enrollment/drop.php?studentid=" + User.use_id;
           

            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            CourseObject coursesToEnroll = new CourseObject();            
            coursesToEnroll=CourseObject.convertToCourseObjectForEnrollment(course);
           
            String jsonString;
            jsonString = JsonConvert.SerializeObject(coursesToEnroll);


            //      declaration of the returned value and its contents
            StatusWithObject<Status> returnedValue = new StatusWithObject<Status>();
            Status resultStatus = new Status();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<Status> auth = new StatusWithObject<Status>();
            auth = await AuthenticatorS.autoAuthentication<Status>();
            if (auth.status.status == false)
            {
                return auth;
            }

          // Please remove it in the real test  path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "POST";

            //      data retrieval  part( request and response)
            req = await AuthenticatorS.sendRequest(path, jsonString, requestType);
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
                    status.message = "Course drop Succeeded.";
                    status.status = true;
                    break;
                case 403:
                    status.message = "Forbidden.";
                    status.status = false;
                    break;
                case 404:
                    status.message = "Course not Found.";
                    status.status = false;
                    break;

                default:
                    resultStatus = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = null;
            return returnedValue;


        }

       
        //  TOTO NEEDS TO KNOW ABOUT ADDING IS GROUP FULL API
    }
}
