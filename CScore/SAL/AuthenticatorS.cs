using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using CScore.BCL;
using System.Net.Http;

namespace CScore.SAL
{
    public static class AuthenticatorS
    { 
        public static String domain; // this must be set from Application layer
        public static List<String> response;
        private static String token;



        public static async Task<Object> sendRequest(String path, Object requestObject, String requestType)
        {
            String fullPath = domain + path;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(fullPath);
            HttpClient request = new HttpClient();
            HttpResponseMessage httpResponse = await request.PostAsync(fullPath,null);
           //httpResponse
            BCL.Announcements aa = new Announcements();
            return aa;
        }


    }
}
