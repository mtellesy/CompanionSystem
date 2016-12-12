using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Department
    {
        public int dep_id { set; get; }
        public String  dep_nameAR { set; get; }
        public String dep_nameEN { set; get; }
        public String dep_description { set; get; }

        public void saveDepartment()
        {
          //  DAL.UsersD.editUserDepartment(this.dep_id, this.dep_nameAR,this.dep_nameEN);
        }


    }
}
