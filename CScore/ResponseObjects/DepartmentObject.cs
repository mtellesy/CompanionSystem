using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class DepartmentObject
    {
        public String departmentID { set; get; }
        public String nameAR { set; get; }
        public String nameEN { set; get; }
        public int managerID { set; get; }
        public bool enrollment { set; get; }
        public bool status { set; get; }

    }
}
