using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;




namespace CScore.SAL
{
    //HOW TO USE IT:
    //YOU NEED sendRequest method to send any request and login method for login
    //but always use authenticate method to make sure that you're loged in and you can send any request
    // if not login and then sendRequest
    // For any one of these Methods always remember to read statusCode before you read the respons
    // status Code values:
    // 0 means Error | in this case response = "error" 
    // 1 means no connection | in this case response = "check your internet connection"
    // 2 in Login method means that the server asking you to change you password first
    // any other code means it's a code from the API (200,2001, etc), you act based on the API doc
    // example if an API is responding with 200 means it success and it returnd a JSON string
    // means you will find you JSON string in the response or just read the returnd vaule

    public static class AuthenticatorS
    { 
        public static String domain; // this must be set from Application layer
        public static String response;
        public static int statusCode;
        public static String token;
        


        //requestObject is a JsonString
        // use this code on with yours to convert Object to String 
        //
        // var json = new JObject(new JProperty("json-key-name", requestObject)).ToString();
        // String content = new StringContent(json);
        //
        // and use this code to convert jsonString to Object
        // returnedObject =  JsonConvert.DeserializeObject<Object Type>(jsonString);

        public static async Task<StatusWithObject<String>> sendRequest(String path, String jsonString, String requestType)
        {

            String fullPath = domain + path;
            StatusWithObject<String> responseObject = new StatusWithObject<String>();
            Status status = new Status();

              //String fullPath = "https://maps.googleapis.com/maps/api/timezone/json?location=38.908133,-77.047119&timestamp=1458000000&key=AIzaSyAoVToLOAWOxSYTe_3SSHqWB3vjFXYWUtA";

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
                        responseObject.statusCode = (int)httpResponse.StatusCode;
                        status.status = true;
                       
                        responseObject.status = status;
                        responseObject.statusObject = responseJson;
                        //return the jsonString
                        return responseObject;
                    }
                    else
                    {
                        responseObject.statusCode = 0; // zero 0 means Error
                        status.message = FixedResponses.getResponse(responseObject.statusCode);
                        status.status = false;
                        responseObject.status = status;
                        responseObject.statusObject = null;
                      
                        return responseObject;
                    }

                }
                catch (Exception ex)
                {
                    responseObject.statusCode = 0; // zero 0 means Error
                    status.message = FixedResponses.getResponse(responseObject.statusCode);
                    status.status = false;
                    responseObject.status = status;
                    responseObject.statusObject = null;

                    return responseObject;
                }
            }

            else
            {
                responseObject.statusCode = 1; // zero 0 means Error
               
                status.message = FixedResponses.getResponse(responseObject.statusCode);
                status.status = false;
                responseObject.status = status;
                responseObject.statusObject = null;

                return responseObject;
            
            }//end of internet checker
        }//end of method

        public static async Task<StatusWithObject<String>> login(int UserID, String password)
        {
           // Task<StatusWithObject<String>>
            StatusWithObject<String> responseObject = new StatusWithObject<String>();
            Status status = new BCL.Status();
            
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
          //  HttpContent content = null;
            String path = String.Format("/users/authenticate?user={0}&password={1}", UserID, password);

            String fullPath = domain + path;
           
           

            //return String 
            // String responseJson;

            if (await UpdateBox.CheckForInternetConnection())
            {
                try
                {
                    httpResponse = await request.PostAsync(fullPath, null);

                    
                    if(httpResponse != null)
                    {
                        statusCode = (int)httpResponse.StatusCode;
                        response = await httpResponse.Content.ReadAsStringAsync();

                        

                        // if Login successed read token and see if user need to change his password or not
                        switch (statusCode)
                        {
                            case 200:
                                AuthenticationObject auth = new AuthenticationObject();
                                auth = await JsonConvert.DeserializeObjectAsync<AuthenticationObject>(response);
                                token = auth.accessToken;
                                status.message = "Authenticatin succeeded";
                                if (auth.forceResetPassword)
                                {
                                    responseObject.statusCode = 2;
                                    status.message = FixedResponses.getResponse(responseObject.statusCode);
                                }
                                status.status = true;
                                responseObject.status = status;
                                responseObject.statusObject = null;
                                return responseObject;
                              
                            case 401:
                                status.message = "User and/or Password are not correct";
                                status.status = false;
                                responseObject.statusCode = statusCode;
                                responseObject.statusObject = null;
                                responseObject.status = status;
                                return responseObject;

                            case 403:
                                status.message = "User is not authorized to create a session, Login aborted";
                                status.status = false;
                                responseObject.statusCode = statusCode;
                                responseObject.statusObject = null;
                                responseObject.status = status;
                                return responseObject;
                                
                            default:
                                status.message = FixedResponses.getResponse(statusCode);
                                status.status = false;
                                responseObject.statusCode = statusCode;
                                responseObject.statusObject = null;
                                responseObject.status = status;
                                return responseObject;

                        }
                            
                    }
                    else
                    {
                        statusCode = 0; // zero 0 means Error
                        status.message = FixedResponses.getResponse(statusCode);
                        status.status = false;
                        responseObject.statusCode = statusCode;
                        responseObject.statusObject = null;
                        responseObject.status = status;
                        return responseObject;
                    }
                }
                catch (Exception ex)
                {
                    statusCode = 0; // zero 0 means Error
                    status.message = FixedResponses.getResponse(statusCode);
                    status.status = false;
                    responseObject.statusCode = statusCode;
                    responseObject.statusObject = null;
                    responseObject.status = status;
                    return responseObject;
                }


            }
            else
            {
                statusCode = 1; // one 1 means There is no Internet connection
                status.message = FixedResponses.getResponse(statusCode);
                status.status = false;
                responseObject.statusCode = statusCode;
                responseObject.statusObject = null;
                responseObject.status = status;
                return responseObject;
            }

        }

        //this method is used also to return user data
        public static async Task<StatusWithObject<String>> authenticate()
        {
            String path = "/users/authenticate" + String.Format("?token={0}", token);
            String fullPath = domain + path;

            Status status = new Status();
            StatusWithObject<String> responseObject = new StatusWithObject<String>();

            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            if(await UpdateBox.CheckForInternetConnection())
            {
                try
                {
                    httpResponse = await request.GetAsync(fullPath);
                    statusCode = (int) httpResponse.StatusCode;
                    response = await httpResponse.Content.ReadAsStringAsync();
                    switch(statusCode)
                    {
                        case 200:
                            UserObject user = new UserObject();
                            user = JsonConvert.DeserializeObject<UserObject>(response);
                            BCL.User.use_id = user.userID;
                            User.username = user.username;
                            User.use_nameAR = user.nameAR;
                            User.use_nameEN = user.nameEN;
                            User.use_typeID = user.userTypeID;
                            User.use_type = user.userType;
                            User.use_gender = user.gender;
                            User.use_email = user.email;
                            User.use_avatar = user.avatar;
                            User.use_phone = user.phoneNumber;
                            User.dep_id = user.departmentID;
                            User.dep_nameAR = user.departmentAR;
                            User.dep_nameEN = user.departmentEN;
                            User.academicRankID = user.academicRankID;
                            User.academicRankAR = user.academicRankAR;
                            User.academicRankEN = user.academicRankEN;
                            status.message = "User data restored successfully";
                            status.status = true;
                            responseObject.statusCode = statusCode;
                            responseObject.status = status;
                            responseObject.statusObject = response;
                            return responseObject;

                        case 401:
                            status.message = "Session failed, you need to login";
                            status.status = false;
                            responseObject.statusCode = statusCode;
                            responseObject.status = status;
                            responseObject.statusObject = null;
                            return responseObject;
                          

                        default:
                            status.message = FixedResponses.getResponse(statusCode);
                            status.status = false;
                            responseObject.statusCode = statusCode;
                            responseObject.status = status;
                            responseObject.statusObject = null;
                            return responseObject;

                    }
                   
                }
                catch
                {
                    statusCode = 0; // zero 0 means Error
                    status.message = FixedResponses.getResponse(statusCode);
                    status.status = false;
                    responseObject.statusCode = statusCode;
                    responseObject.status = status;
                    responseObject.statusObject = null;
                    return responseObject;
                }

            }
            else
            {
                statusCode = 1; // one 1 means There is no Internet connection
                status.message = FixedResponses.getResponse(statusCode);
                status.status = false;
                responseObject.statusCode = statusCode;
                responseObject.status = status;
                responseObject.statusObject = null;
                return responseObject;
            }
            
        }

        public static async Task logout()
        {
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(5000);
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            String  path = "/users/authenticate" + String.Format("?token={0}", token);
            String fullPath = domain + path;

            if(await UpdateBox.CheckForInternetConnection())
            {
                try
                {
                   httpResponse = await request.DeleteAsync(fullPath);
                    if(httpResponse != null)
                    {
                        statusCode = (int)httpResponse.StatusCode;
                        response = await httpResponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        statusCode = 0; // zero 0 means Error
                        response = response = FixedResponses.getResponse(statusCode);

                    }
                }
                catch
                {
                    statusCode = 0; // zero 0 means Error
                    response = response = FixedResponses.getResponse(statusCode);
                }
            }
            else
            {
                statusCode = 1; // one 1 means There is no Internet connection
                response = response = FixedResponses.getResponse(statusCode);
            }


        }

        public static async Task<StatusWithObject<T>> autoAuthentication<T>()
        {
            StatusWithObject<T> returnedValue = new StatusWithObject<T>();
            Status status = new Status();
           
            int code;
            StatusWithObject<String> auth = new StatusWithObject<String>();
            StatusWithObject<String> log = new StatusWithObject<String>();

            auth = await AuthenticatorS.authenticate();
            code = auth.statusCode;
          //  returnedValue.status = auth.

            if (auth.status.status == false)
            {
                if (code == 401)
                {
                    log = await AuthenticatorS.login(User.use_id, User.password);
                    
                        returnedValue.status = log.status;
                        returnedValue.statusCode = log.statusCode;
                       // returnedValue.statusObject;
                        return returnedValue;
                    
                }
             

            }
            
                returnedValue.status = auth.status;
                returnedValue.statusCode = auth.statusCode;
                return returnedValue;

            
        } 

    }//end of class
}//end of namespace 
