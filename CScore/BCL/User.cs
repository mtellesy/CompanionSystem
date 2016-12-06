using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
  public static class User
    {
        public static int use_id { get; set; }
        public static String use_nameAR { get; set; }
        public static String use_nameEN { get; set; }
        public static int dep_id { get; set; }
        public static String dep_nameAR { get; set; }
        public static String dep_nameEN { get; set; }
        public static String use_email { get; set; }
        public static long use_phone { get; set; }
        public static String use_gender { get; set; }
        public static String use_picture { get; set; }
        public static String use_avatar { get; set; }
        public static int use_typeID { get; set; }
        public static int academicRankID { get; set; }
        public static String academicRankAR { get; set; }
        public static String academicRankEN { get; set; }

        //ASK TOTO how to do it
      /*
        public static Status login(int use_id, String password)
        {
            Status s = new Status();
            s = internetChecker();
            if (s.status)
            {
                SAL.UserS.getUser(use_id);
                saveUser();
            }
            else
            {
                
            }

        }
        */

      /*
        public static void saveUser()
        {
            await DAL.UsersD.saveUser(; 
        }

  */
     //  public static OtherUsers getUser()
      //  {
          //  OtherUsers ou = new OtherUsers();
        //
//        }

    }
}
