using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class UserS
    {
        public static void getUser(int use_id)
        {
            String path = "/user/" + use_id;
        }
        public static OtherUsers getOtherUser(int use_id)
        {
            OtherUsers user = new OtherUsers();
            String path = "/user/" + use_id;
            return user;
        }
    }
}
