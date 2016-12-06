using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public static class Major
    {
       
        /*
        public static bool isMajorEnabled()
        {
            return SAL.MajorS.getMajorStatus();
        }*/
        /*
        public static bool isAllowedToMajor()
        {
            return SAL.MajorS.isAllowedToMajor(User.use_id);
        }*/

       public static Status major(Department d)
        {
            Status s1 = new Status();
            // s1 = SAL.MajorS.sendDepartment(User.use_id, d.dep_id);
            d.saveDepartment();
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
