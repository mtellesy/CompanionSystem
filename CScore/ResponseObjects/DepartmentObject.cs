using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class DepartmentObject
    {
        public int departmentID { set; get; }
        public String nameAR { set; get; }
        public String nameEN { set; get; }
        public int managerID { set; get; }
        public bool enrollment { set; get; }
        public bool status { set; get; }

        public static BCL.Department convertToDepartment(DepartmentObject dep)
        {
            BCL.Department department = new BCL.Department();
            department.Dep_id = dep.departmentID;
            department.DepNameAR = dep.nameAR;
            department.Dep_nameEN = dep.nameEN;
            department.Dep_discription = null;
            return department;
        }
        // propably wont be used
        public static DepartmentObject convertToDepartmentObject(BCL.Department dep)
        {
            DepartmentObject department = new DepartmentObject();
            department.departmentID = dep.Dep_id;
            department.nameAR = dep.Dep_nameEN;
            department.nameEN = dep.Dep_nameEN;
            return department;
        }
    }
    
}
