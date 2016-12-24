using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public static class Major
    {
        //              done
        //              *** Methods ***

        public static async Task<bool> isMajorEnabled()
        {
            bool returnedValue = false;
            StatusWithObject<bool> temp = new StatusWithObject<bool>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                temp = await SAL.MajorS.getMajorStatus();
                returnedValue = temp.statusObject;
            }

            return returnedValue;
        }
    

       public static async Task<StatusWithObject<String>> major(Department department)
        {
            StatusWithObject<String> returnedValue = new StatusWithObject<String>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.MajorS.sendDepartment(department.Dep_id );
                if (returnedValue.status.status == true)
                {
                    User.dep_id =Convert.ToString(department.Dep_id);
                    User.dep_nameAR = department.DepNameAR;
                    User.dep_nameEN = department.Dep_nameEN;
                    await DAL.UsersD.saveUser();
                }
            }
            return returnedValue;
        }
        
        public static async Task<StatusWithObject<List<Department>>> getAvailableDepartments()
        {
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();
            returnedValue.status = new Status();
            returnedValue.status.status = false;

            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.MajorS.getAvailableDepartments();
            }
            else
            {
                returnedValue.status.status = false;
                returnedValue.statusCode = 1;
                returnedValue.status.message = SAL.FixedResponses.getResponse(1);
                returnedValue = null;

            }
            return returnedValue;
        }
    }
}
