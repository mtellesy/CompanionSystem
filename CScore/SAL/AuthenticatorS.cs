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
            //String fullPath = domain + path;
            String fullPath = "https://maps.googleapis.com/maps/api/timezone/json?location=38.908133,-77.047119&timestamp=1458000000&key=AIzaSyAoVToLOAWOxSYTe_3SSHqWB3vjFXYWUtA";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(fullPath);
            HttpClient request = new HttpClient();
            if (await UpdateBox.CheckForInternetConnection() == true)
            {
                /*  try
                  {
                      HttpResponseMessage httpResponse = request.PostAsync(fullPath, null).Result;
                      var code = httpResponse.StatusCode;
                      if ((int)code == 200)
                      {
                          return "okay";
                      }
                      else
                      { return "not okay"; }
                  }
                  catch (Exception ex)
                  { return "ddd"; }*/
                return "there is internet";


            }
            else {
                return "you're offline";
                  }


            //httpResponse
            //  BCL.Announcements aa = new Announcements();
            //return aa;
        }


    }
}
