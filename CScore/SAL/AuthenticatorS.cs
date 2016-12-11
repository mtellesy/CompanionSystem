using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using CScore.BCL;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;



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
        public static String response;
        public static int statusCode;
        private static String token;


        //requestObject is a JsonString
        // use this code on with yours to convert Object to String 
        //
        // var json = new JObject(new JProperty("json-key-name", requestObject)).ToString();
        // String content = new StringContent(json);
        //
        // and use this code to convert jsonString to Object
        // returnedObject =  JsonConvert.DeserializeObject<Object Type>(jsonString);

        public static async Task<String> sendRequest(String path, String jsonString, String requestType)
        {

            //String fullPath = domain + path;
            String fullPath = "https://maps.googleapis.com/maps/api/timezone/json?location=38.908133,-77.047119&timestamp=1458000000&key=AIzaSyAoVToLOAWOxSYTe_3SSHqWB3vjFXYWUtA";
            // httpClient stuff
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            HttpContent content = null;

            //return String 
            String responseJson;

            // if there is no jsonString to send then keep it null;
            if (jsonString != null)
            {
                content = new StringContent(jsonString);
            }


            if (await UpdateBox.CheckForInternetConnection() == true)
            {
                try
                {
                    switch (requestType)
                    {
                        //POST
                        case "Post":
                        case "POST":
                        case "post":
                            httpResponse = await request.PostAsync(fullPath, content);
                            break;

                        //PUT
                        case "Put":
                        case "PUT":
                        case "put":
                            httpResponse = await request.PutAsync(fullPath, content);
                            break;

                        // GET 
                        case "Get":
                        case "GET":
                        case "get":
                            httpResponse = await request.GetAsync(fullPath);
                            break;

                        // DELETE
                        case "Delete":
                        case "DELETE":
                        case "delete":
                            httpResponse = await request.DeleteAsync(fullPath);
                            break;

                        default:
                            httpResponse = null;
                            break;

                    }

                    if (httpResponse != null)
                    {
                        //  httpResponse.EnsureSuccessStatusCode();
                        responseJson = await httpResponse.Content.ReadAsStringAsync();
                        //save the code so we could use it later
                        statusCode = (int)httpResponse.StatusCode;
                        response = responseJson;
                        //return the jsonString
                        return responseJson;
                    }
                    else
                    {
                        statusCode = 0; // zero 0 means Error
                        response = "ERROR";
                        return response;
                    }

                }
                catch (Exception ex)
                {
                    statusCode = 0; // zero 0 means Error
                    response = "ERROR";
                    return response;
                }
            }

            else
            {
                statusCode = 1; // one 1 means There is no Internet connection
                response = "Can't reach the Server, check you Internet connection";
                return response;
            }//end of internet checker
        }//end of method

        public static async Task<String> login(int UserID, String password)
        {
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            HttpContent content = null;
            String path = String.Format("/users/authenticate?user={0}?password={1}", UserID, password);
            String fullPath = domain + path;

            //return String 
           // String responseJson;

            if (await UpdateBox.CheckForInternetConnection())
            {
                try
                {
                    httpResponse = await request.PostAsync(fullPath, null);
                    if (httpResponse != null)
                    {
                        statusCode = (int)httpResponse.StatusCode;
                        response = await httpResponse.Content.ReadAsStringAsync();
                        return response;


                    }
                    else
                    {
                        statusCode = 0; // zero 0 means Error
                        response = "ERROR";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    statusCode = 0; // zero 0 means Error
                    response = "ERROR";
                    return response;
                }


            }
            else
            {
                statusCode = 1; // one 1 means There is no Internet connection
                response = "Can't reach the Server, check you Internet connection";
                return response;
            }

        }

    }//end of class
}//end of namespace 
