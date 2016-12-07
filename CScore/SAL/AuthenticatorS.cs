using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using CScore.BCL;

namespace CScore.SAL
{
    public static class AuthenticatorS
    { 
        public static String domain; // this must be set from Application layer
        public static List<String> response;
        private static String token;


        public static  Object sendRequest(String path, Object requestObject, String requestType)
        {
            BCL.Announcements aa = new Announcements();
            return aa;
        }


    }
}
