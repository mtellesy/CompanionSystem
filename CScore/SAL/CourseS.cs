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
        //              done :)
        //              *** returns all information about all courses courses ***
        public static async Task<StatusWithObject<List<Course>>> getCourses(String cou_id, String dep_id, String branch)
        {
            // declaration of path and request type
            String path = "/courses?";
            if (cou_id != null)
            {
                path += "id={0}&" + cou_id;
            }
            if (dep_id != "0"&& dep_id!= null)
            {
                path += "?department={0}&" + dep_id;
            }
            if (branch != null)
            {
                path += "?branch={0}" + branch;
            }
            String requestType = "GET";

            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      declaration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            List<Course> courses = new List<Course>();
            Status status = new Status();
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
                    List<CourseObject> courseResult = JsonConvert.DeserializeObject<List<CourseObject>>(jsonString);
                    Course temp = new Course();
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
   
        //              *** returns student or lecturer courses ***
        public static async Task<StatusWithObject<List<Course>>> getEnrolledCourses()
        {
            //      declaration of path and request type
            String path = "";
            if (User.use_typeID == "L")
            {
                 path = "/users/" + User.use_id + "/courses";
            }
            else
            {
                 path = "/students/" + User.use_id + "/ courses";

            }
            path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      declaration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      declaration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            List<Course> courses = new List<Course>();
            Status status = new Status();
            Course temp = new Course();
            int code;

            //      authentication part
            StatusWithObject<List<Course>> auth = new StatusWithObject<List<Course>>();
            auth = await AuthenticatorS.autoAuthentication<List<Course>>();
            if (auth.status.status == false)
            {
                return auth;
            }

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
