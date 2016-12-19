using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CScore.ResponseObjects;


namespace CScore.SAL
{
  public static class UserS 
    {
        
       
        public static async Task<StatusWithObject<OtherUsers>> getOtherUser(int use_id)
        {
            OtherUsers user = new OtherUsers();
            Status status = new Status();
            StatusWithObject<OtherUsers> returnedValue = new StatusWithObject<OtherUsers>();
            StatusWithObject<String> auth = new StatusWithObject<String>();
            StatusWithObject<String> log = new StatusWithObject<String>();

            String jsonString;
            String path = "/users/" + use_id.ToString() + "&refresh";
            String requestType = "GET";
            int code; 

            auth = await AuthenticatorS.authenticate();
            code = auth.statusCode;

            if(auth.status.status == false)
            {
               if(code == 401)
                {
                  log =  await AuthenticatorS.login(User.use_id, User.password);
                    if(log.status.status == false)
                    {
                        returnedValue.status = log.status;
                        returnedValue.statusCode = log.statusCode;
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                } 
               else
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }

            StatusWithObject<String> req = new StatusWithObject<String>();
            //start from here baby
            req = await AuthenticatorS.sendRequest(path, null, requestType);

            jsonString = req.statusObject;
            code = req.statusCode;
            
            if(req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch(code)
            {
                case 200:
                    UserObject JUser = JsonConvert.DeserializeObject<UserObject>(jsonString);
                    user = getMyUser(JUser);
                    status.message = "User Profile returned";
                    status.status = true; 
                    break;
                case 401:
                    user = null;
                    status.status = false;
                    status.message = "Unauthorized action";
                    break;
                case 403:
                    user = null;
                    status.status = false;
                    status.message = "User not found";
                    break;
                default:
                    user = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = user;
            return returnedValue;
        }

        public static OtherUsers getMyUser(UserObject Juser)
        {
            OtherUsers user = new OtherUsers();
            user.academicRankAR = Juser.academicRankAR;
            user.academicRankEN = Juser.academicRankEN;
            user.academicRankID = Juser.academicRankID;
            user.dep_id = Juser.departmentID;
            user.dep_nameAR = Juser.departmentAR;
            user.dep_nameEN = Juser.departmentEN;
            user.use_avatar = Juser.avatar;
            user.use_email = Juser.email;
            user.use_gender = Juser.gender;
            user.use_id = Juser.userID;
            user.use_nameAR = Juser.nameAR;
            user.use_nameEN = Juser.nameEN;
            user.use_phone = Juser.phoneNumber;
            user.use_typeID = Juser.userTypeID;
           
            return user; 
        }
    }
}
