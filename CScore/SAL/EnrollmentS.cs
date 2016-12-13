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
        public static async Task<StatusWithObject<bool>> enrollmentStatus()
        {
            bool enrollment = false;
            String path = "enrollment/status/";
            //      arguments for the APIs      and send request method
            String Path =path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<bool> returnedValue = new StatusWithObject<bool>();
          //  Status results = new Status();
            Status status = new Status();
            int code;

            //      use this only if the endpoint tag = security  
            //      decleration of the values tha         
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
                        returnedValue.statusObject = false;// should be null but boolean is non nullable datatype
                        return returnedValue;
                    }
                }
                else if(code !=200)
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = false;
                    return returnedValue;
                }
            }

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

        public static List<Course> getAvailableCourses()
        {
            List<Course> courses = new List<Course>();
            String path = "/enrollment/" + User.use_id;


            return courses;
        }
        public static void sendEnrolledCourses(List<Course> courses)
        {
            String path = "/enrollment/" + User.use_id;

        }

        public static void sendDroppedCourses(List<Course> couses)
        {
            String path = "/enrollment/" + User.use_id;
        }
        //  TOTO NEEDS TO KNOW ABOUT ADDING IS GROUP FULL API
    }
}
