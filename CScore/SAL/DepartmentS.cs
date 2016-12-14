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
                    List<DepartmentObject> results1 = JsonConvert.DeserializeObject<List<DepartmentObject>>(jsonString);
                    foreach (DepartmentObject x in results1)
                    {
                        results.Add(convertToDepartment(x));
                    }
                    status.message = "Departments returned";
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
