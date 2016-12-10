using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CScore.BCL;
using System.Net.Http;

namespace CScore.SAL
{
    public class RootObject
    {
        public int dstOffset { get; set; }
        public int rawOffset { get; set; }
        public string status { get; set; }
        public string timeZoneId { get; set; }
        public string timeZoneName { get; set; }
    }

    public static class AuthenticatorS
    { 
        public static String domain; // this must be set from Application layer
        public static List<String> response;
        private static String token;



        public static async Task<String> sendRequest(String path, Object requestObject, String requestType)
        {
            response = new List<String>();
            //String fullPath = domain + path;
            String fullPath = "https://maps.googleapis.com/maps/api/timezone/json?location=38.908133,-77.047119&timestamp=1458000000&key=AIzaSyAoVToLOAWOxSYTe_3SSHqWB3vjFXYWUtA";
            
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse;
            HttpContent content;
            String jsonString;
            if (requestObject != null)
            {
                var json = new JObject(new JProperty("json-key-name", requestObject)).ToString();
                content = new StringContent(json);
            }
            else content = null;

            if (await UpdateBox.CheckForInternetConnection() == true)
            {
                try
                  {
                    switch(requestType)
                    {
                        case "Post":
                        case "POST":
                        case "post":
                            httpResponse = await request.PostAsync(fullPath,content);
                            return null;
                            break;
                        case "Put":
                        case "PUT":
                        case "put":
                            return null;
                            break;
                            // GET 
                        case "Get":
                        case "GET":
                        case "get":

                            httpResponse = await request.GetAsync(fullPath);
                            httpResponse.EnsureSuccessStatusCode();
                            jsonString = await httpResponse.Content.ReadAsStringAsync();
                          //  returnedObject =  JsonConvert.DeserializeObject<RootObject>(body);
                            response.Add(httpResponse.StatusCode.ToString());
                            response.Add(jsonString);
                            return jsonString;
                            break;
                            
                        case "Delete":
                        case "DELETE":
                        case "delete":
                            return null;
                            break;
                        default:
                            return null;
                            break;

                            

                    }
                 
                  }
                  catch (Exception ex)
                { return "Error"; }
               


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
