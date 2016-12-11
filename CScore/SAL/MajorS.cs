using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class MajorS:Template
    {
        public static bool getMajorStatus()
        {
            bool status = false;
            String path = "/major/status";
            return status;
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
