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
    public static class DepartmentS
    {

        //              *** returns all information about all courses courses ***
        public static async Task<StatusWithObject<List<Department>>> getDepartments(String id)
        {
            // decleration of path and request type
            String path = "/departments";
            if (id != null)
            {
                path += "?id={0}" + id;
            }
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();
            List<Department> departments = new List<Department>();
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
                    List<DepartmentObject> results1 = JsonConvert.DeserializeObject<List<DepartmentObject>>(jsonString);
                    foreach (DepartmentObject x in results1)
                    {
                        departments.Add(DepartmentObject.convertToDepartment(x));
                    }
                    status.message = "Departments returned";
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

    }
}
