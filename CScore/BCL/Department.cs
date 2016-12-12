using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Department
    {
        private int dep_id ;
        private String dep_nameAR { set; get; }
        private  String dep_nameEN { set; get; }
        private  String dep_description { set; get; }

        //  getters and setters

        //  dep_id
        public int Dep_id
        {
            set
            {
                dep_id = value;
            }
            get
            {
                return dep_id;
            }
        }
        //  depNameAR
        public String DepNameAR
        {
            set
            {
                dep_nameAR = value;
            }
            get
            {
                return dep_nameAR;
            }
        }

        //      dep_nameEN
        public String Dep_nameEN
        {
            set
            {
                dep_nameEN = value;
            }
            get
            {
                return dep_nameEN;
            }
        }

        public String Dep_discription
        {
            set
            {
                dep_description = value;
            }
            get
            {
                return dep_description;
            }
        }
        public void saveDepartment()
        {
          //  DAL.UsersD.editUserDepartment(this.dep_id, this.dep_nameAR,this.dep_nameEN);
      
        }


    }
}
