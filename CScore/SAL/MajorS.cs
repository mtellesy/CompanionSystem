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
    public static class MajorS
    {
        public static async Task<StatusWithObject<Status>>  getMajorStatus()
        {
            String path = "/major/status";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Status> returnedValue = new StatusWithObject<Status>();
            Status status = new Status();
            Status result = new Status();

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
                    MajorObject result1 = JsonConvert.DeserializeObject <MajorObject>(jsonString);
                    result.status = result1.status;
                    if (result.status == true)
                    {
                        result.message = "Majorment is available.";
                    }
                    else
                    {
                        result.message = "Majorment is not available.";
                    }
                    status.message = "User Profile returned";
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
        public static List<Department> getAvailableDepartments()
        {
            List<Department> departments = new List<Department>();
            String path = "/major/"+User.use_id;

            return departments;
        }

        public static void sendDepartment(int dep_id)
        {
            String path = "major/"+dep_id+"/"+User.use_id;
        }
    }
}
