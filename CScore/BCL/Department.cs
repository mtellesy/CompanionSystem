using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Department
    {
        //              done
        //              *** Properties ***
        private int dep_id ;
        private String dep_nameAR { set; get; }
        private  String dep_nameEN { set; get; }
        private  String dep_description { set; get; }

        //              *** setters and getters ***

        //      dep_id
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
        //    depNameAR
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
        //      dep_description
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

        //              *** Methods ***

        public static async Task<StatusWithObject<List<Department>>> getDepartments(int dep_id)
        {
            List<Department> department = new List<Department>();
            StatusWithObject<List<Department>> returnedValue = new StatusWithObject<List<Department>>();

            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.DepartmentS.getDepartments( dep_id);
               
            }
         
            return returnedValue;
        }


    }
}
