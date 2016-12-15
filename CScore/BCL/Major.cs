using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public static class Major
    {

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
        /*
        public static bool isAllowedToMajor()
        {
            return SAL.MajorS.isAllowedToMajor(User.use_id);
        }*/

       public static Status major(Department d)
        {
            Status s1 = new Status();
            // s1 = SAL.MajorS.sendDepartment(User.use_id, d.dep_id);
//            User.dep_id=Department
  //              user.depName=KeyNotFoundException[';
    //               user,depnameEN
    // saveUser()

            return s1;
        }
        /*
        public static List<Department> getAvailableDepartments()
        {
            List<Department> availableDepartments = new List<Department>;
            availableDepartments = SAL.MajorS.getDepartments(User.use_id,dep_id);
            return availableDepartments;
        }*/
    }
}
