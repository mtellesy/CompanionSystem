using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
  public class UserObject
    {
        //      ID
        public int userID { set; get; }
        public String username { set; get; }
        public int userTypeID { set; get; }
        public String userType { set; get; }
        //      Arabic name
        public String firstNameAR { set; get; }
        public String secondNameAR { set; get; }
        public String thirdNameAR { set; get; }
        public String lastNameAR { set; get; }
        public String nameAR { set; get; }
        //      English name
        public String firstNameEN { set; get; }
        public String secondNameEN { set; get; }
        public String thirdNameEN { set; get; }
        public String lastNameEN { set; get; }
        public String nameEN { set; get; }
        //      contact information
        public String email { set; get; }
        public int phoneNumber { set; get; }
        public String address { set; get; }
        //      other
        public String birthdate { set; get; }
        //      department
        public String departmentID { set; get; }
        public String departmentAR { set; get; }
        public String departmentEN { set; get; }
        //      nationality
        public String nationalityID { set; get; }
        public String nationalityAR { set; get; }
        public String nationalityEN { set; get; }
        public int nationalID { set; get; }
        //      other
        public String gender { set; get; }
        public String avatar { set; get; }
        public String specialization { set; get; }
        //      qualification
        public int qualificationID { set; get; }
        public String qualificationAR { set; get; }
        public String qualificationEN { set; get; }
        //      prefix
        public String prefixAR { set; get; }
        public String prefixEN { set; get; }
        //      academic rank
        public int academicRankID { set; get; }
        public String academicRankAR { set; get; }
        public String academicRankEN { set; get; }
        //      position
        public int positionID { set; get; }
        public String positionAR { set; get; }
        public String positionEN { set; get; }
        //      others
        public String lastLogin { set; get; }
        public String interests { set; get; }
        public String certification { set; get; }

    }
}
