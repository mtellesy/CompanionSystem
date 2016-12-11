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
  public class UserS : Template
    {
        
       
        public async Task<StatusWithObject<OtherUsers>> getOtherUser(int use_id)
        {
            OtherUsers user = new OtherUsers();
            Status status = new Status();
            StatusWithObject<OtherUsers> returnedValue = new StatusWithObject<OtherUsers>();

            String jsonString;
            String path = "/users/" + use_id + "?refresh";
            String requestType = "GET";

           await AuthenticatorS.authenticate();
            int code = AuthenticatorS.statusCode;

            //if user not logged in 
            if (code == 401)
            {
                //user login 
                await AuthenticatorS.login(User.use_id, User.password);

                //if anythin wrong happens
                    if(AuthenticatorS.statusCode != 200)
                {
                    user = null; // no user to return
                    status.status = false; 
                    status.message = AuthenticatorS.response;
                    returnedValue.status = status;
                    returnedValue.statusObject = user;
                    returnedValue.statusCode = AuthenticatorS.statusCode;
                    return returnedValue;
                }
            }
            else if(code != 200)
            {
                user = null; // no user to return
                status.status = false;
                status.message = AuthenticatorS.response;
                returnedValue.status = status;
                returnedValue.statusObject = user;
                returnedValue.statusCode = AuthenticatorS.statusCode;
                return returnedValue;
            }

            jsonString = await AuthenticatorS.sendRequest(path, null, requestType);
            code = AuthenticatorS.statusCode;

            switch(code)
            {
                case 0:
                case 1:
                case 2:
                    user = null;
                    status.status = false;
                    status.message = AuthenticatorS.response;
                    break;
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

        public OtherUsers getMyUser(UserObject Juser)
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
