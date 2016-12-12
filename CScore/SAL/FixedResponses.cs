using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class FixedResponses
    {
     

        public static String getResponse(int code)
        {
            switch(code)
            {
                case 403:
                    return "User is not autherized";
                case 500:
                    return "Unknown Error";
                case 0:
                    return "System ERROR!";
                case 1:
                    return "Can't reach the Server.Please check your Internet connection fss";
                case 2:
                    return "Please Change your Password";
                default:
                    return "Error";
                    
            }
        }
        
    }
}
