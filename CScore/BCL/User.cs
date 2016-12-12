using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.SAL;

namespace CScore.BCL
{
  public static class User
    {
        // do i need to login again?
        public static int loginStatus; // 1 means i need to login
        // this shluld be set from Application layer 
        public static String use_type { get; set; } // S for student and L for Lecturer

        public static String username { get; set; }
        public static String password { get; set; } // save it here when you start the application layer
        public static int use_id { get; set; }
        public static String use_nameAR { get; set; }
        public static String use_nameEN { get; set; }
        public static String dep_id { get; set; }
        public static String dep_nameAR { get; set; }
        public static String dep_nameEN { get; set; }
        public static String use_email { get; set; }
        public static long use_phone { get; set; }
        public static String use_gender { get; set; }
        public static String use_picture { get; set; }
        public static String use_avatar { get; set; }
        public static int use_typeID { get; set; }
        public static int academicRankID { get; set; }
        public static String academicRankAR { get; set; }
        public static String academicRankEN { get; set; }


      /*  public static async Task<Status> login(int userID , String password)
        {
            loginStatus = 0;
            //here we use status object to give user a feedback of what happend
            Status message = new Status();
            

            if(await UpdateBox.CheckForInternetConnection())
            {
                
             String response = await AuthenticatorS.login(userID, password);
             switch(AuthenticatorS.statusCode)
                {
                    case 0:
                    case 1:
                    case 2:
                        message.status = false;
                        message.message = response;
                        break;
                    case 200:
                        message.status = true;
                        message.message = "You have been successfully logged in";
                        break;
                    default:
                        message.status = false;
                        message.message = AuthenticatorS.statusCode.ToString();
                        break;
                }
                return message;
                }
            else
            {
                message.status = false;
                message.message = "Can't reach the Server, check your Internet connection";
                return message;
            }

            }
        
        public static async Task<Status> logout()
        {
            Status message = new Status();
            await AuthenticatorS.logout();
            if (AuthenticatorS.statusCode == 0 || AuthenticatorS.statusCode == 1 ||
                 AuthenticatorS.statusCode == 2)
                message.status = false;
            else
                message.status = true;
            message.message = AuthenticatorS.response;
            return message;

        }

        public static async Task<Status> getUser()
        {
            Status message = new Status();

            if(await UpdateBox.CheckForInternetConnection())
            {
                //bring data from server if you're online
              String response =  await AuthenticatorS.authenticate();
                // if it find out that you're not logged in it will give you 401
                if(AuthenticatorS.statusCode == 401)
                {
                    // try to re login
                Status loginMessage = await User.login(User.use_id, User.password);
                    //if there is a problem it will return an error message telling you what to do
                    if(loginMessage.status != true)
                    {
                        message.status = false;
                        message.message = loginMessage.message;
                        return message;
                    }
                    
                }
                // if every thing above went perfectly it will save the returned data
                await DAL.UsersD.saveUser();

            }
            // now getting your data
            message.status = await DAL.UsersD.getUsers();
            if(message.status == true)
            {
                message.message = "User Data has been successefully retrived";
                
            }
            else
            {
                message.message = "Somthing wrong!. There is no data";
            }
            return message;
        }

     
        */
        }
    

    }

