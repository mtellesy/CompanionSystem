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
        public static List<Department> getDepartments()
        {
            List<Department> departments = new List<Department>();
            String path = "/departments";
            return departments;
        }
    }
}
