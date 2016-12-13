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
                    status.message = "User Profile returned";// Needs modification
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

        public static async Task<StatusWithObject<List<Department>>> getAvailableDepartments()
        {
            List<Department> departments = new List<Department>();
            String path = "/major/"+User.use_id;
            //      arguments for the APIs      and send request method
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();
            List<Department> results = new List<Department>();
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
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                }
                else if (code !=200)
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }

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
                        results.Add(convertToDepartment(x));
                    }
                    status.message = "Available departments returned";
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
            returnedValue.statusObject = results;
            return returnedValue;

        }
        
        //      NEEDS TO ASK TOTO ABOUT IT
        public static async Task<StatusWithObject<Status>> sendDepartment(int dep_id)
        {
            String Path = "major/"+dep_id+"/"+User.use_id;
            //      arguments for the APIs      and send request method
            String requestType = "SET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Status> returnedValue = new StatusWithObject<Status>();
            Status resultStatus = new Status();
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
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                }
                else if(code != 200)
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }
            Path = Path + String.Format("?token={0}", AuthenticatorS.token);

            req = await AuthenticatorS.sendRequest(Path, null, requestType);

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
                    status.status = true;
                    break;
                case 403:
                    status.message = "You enroll in this Department.";
                    status.status = true;
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

        public static Department convertToDepartment(DepartmentObject dep)
        {
            Department department = new Department();
            department.Dep_id = dep.departmentID;
            department.DepNameAR = dep.nameAR;
            department.Dep_nameEN = dep.nameEN;
            department.Dep_discription = null;
            return department;
        }
    }
}
