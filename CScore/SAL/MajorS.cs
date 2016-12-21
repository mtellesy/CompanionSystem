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
        //              done
        //              *** returns major status ***
        public static async Task<StatusWithObject<bool>>  getMajorStatus()
        {
            //      declaration of path and request type
            String path = "/major/status";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<bool> returnedValue = new StatusWithObject<bool>();
            Status status = new Status();
            bool major = new bool();
            int code;

            //      data retrieval  part
            req = await AuthenticatorS.sendRequest(path, null, requestType);
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
                    MajorObject result1 = JsonConvert.DeserializeObject <MajorObject>(jsonString);
                    major = result1.status;
                    if (major == true)
                    {
                        status.message = "Majorment is available.";
                    }
                    else
                    {
                        status.message = "Majorment is not available.";
                    }
                    status.status = true;
                    break;

                default:
                    major = false;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = major;
            return returnedValue;
        }

        //              *** returns list of departments that are available to major ***
        public static async Task<StatusWithObject<List<Department>>> getAvailableDepartments()
        {
            //      declaration of path and request type
            String path = "/major/"+User.use_id;
           
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();
            List<Department> departments = new List<Department>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Department>> auth = new StatusWithObject<List<Department>>();
            auth = await AuthenticatorS.autoAuthentication<List<Department>>();
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
                    List<DepartmentObject> results1 = JsonConvert.DeserializeObject<List<DepartmentObject>>(jsonString);
                    foreach (DepartmentObject x in results1)
                    {
                        departments.Add(DepartmentObject.convertToDepartment(x));
                    }
                    status.message = "Available departments returned";
                    status.status = true;
                    break;

                default:
                    departments = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;
                    
            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = departments;
            return returnedValue;

        }

        //              *** returns sends the user's wanted deparment to server ***
        public static async Task<StatusWithObject<String>> sendDepartment(int dep_id)
        {
            //  add this in the real test String path = "major/"+dep_id+"/"+User.use_id;
            String path = "/major/major.php?departmentid="+dep_id + "&studentid=" + User.use_id;

            String requestType = "POST";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<String> returnedValue = new StatusWithObject<String>();
            Status resultStatus = new Status();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<String> auth = new StatusWithObject<String>();
            auth = await AuthenticatorS.autoAuthentication<String>();
            if (auth.status.status == false)
            {
                return auth;
            }

           // please add it in the real test path += String.Format("?token={0}", AuthenticatorS.token);

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
                case 201:
                    status.message = "Major Process Succeeded.";
                    status.status = true;
                    break;
                case 202:
                    status.message = "Accepted but not done.";
                    status.status = false;
                    break;
                case 403:
                    status.message = "You enroll in this Department.";
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

        
    }
}
