using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class DepartmentS:Template
    {
        public static async Task<StatusWithObject<List<Department>>> getDepartments()
        {
            List<Department> departments = new List<Department>();
            String path = "/departments";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();
            List<Department> results = new List<Department>();
            Status status = new Status();
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
                    List<GradeObject> results1 = JsonConvert.DeserializeObject<List<GradeObject>>(jsonString);
                    foreach (GradeObject x in results1)
                    {
                        results.Add(getAllMyResult(x));
                    }
                    status.message = "User Profile returned";
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

            return departments;
        }
    }
}
