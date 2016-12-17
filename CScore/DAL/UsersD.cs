using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;
using CScore.DataLayer;
using CScore.BCL;
using SQLite.Net;

//using SQLite.Net.Async;
//using SQLite.Net.Interop;
//sing SQLite.Net.Attributes;

namespace CScore.DAL
{
    public static class UsersD 
    {
        
        public static List<String> results;

        public static async Task saveOtherUser(OtherUsers user)
        {
            Users DBuser = new DataLayer.Tables.Users();
            DBuser.Use_id = user.use_id;
            DBuser.Use_nameEN = user.use_nameEN;
            DBuser.Use_nameAR = user.use_nameAR;
            DBuser.Use_phone = user.use_phone;
            DBuser.Use_picture = user.use_picture;
            DBuser.Use_typeID = user.use_typeID;
            DBuser.Use_gender = user.use_gender;
            DBuser.Use_email = user.use_email;
            DBuser.Use_avatar = user.use_avatar;
            DBuser.Dep_id = user.dep_id;
            DBuser.Dep_nameAR = user.dep_nameAR;
            DBuser.Dep_nameEN = user.dep_nameEN;
            DBuser.academicRankID = user.academicRankID;
            DBuser.academicRankEN = user.academicRankEN;
            DBuser.academicRankAR = user.academicRankAR;

            // first we make suer the user not exsited already
            var results = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(user.use_id)).CountAsync();
          
            
            //if the user is not exsited
          if (results <= 0 )
            {
                await DBuilder._connection.InsertAsync(DBuser);
           }
           else 
           await DBuilder._connection.UpdateAsync(DBuser);// if the user is exsited update his info

        }

        

        public static async Task<OtherUsers> getOtherUser(String user_id)
        {
           // get data 
            var DBuser = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(user_id)).ToListAsync();

            // to check if the user we requisted is exsited or not ( if not return null) 
            var checker = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(user_id)).CountAsync();

            if (checker > 0)
            {

                OtherUsers returnUser = new OtherUsers();
                returnUser.use_id = DBuser.Select(i => i.Use_id).First();
                returnUser.use_nameEN = DBuser.Select(i => i.Use_nameEN).First(); ;
                returnUser.use_nameAR = DBuser.Select(i => i.Use_nameAR).First(); ;
                returnUser.use_phone = DBuser.Select(i => i.Use_phone).First();
                returnUser.use_picture = DBuser.Select(i => i.Use_picture).First();
                returnUser.use_typeID = DBuser.Select(i => i.Use_typeID).First();
                returnUser.use_gender = DBuser.Select(i => i.Use_gender).First();
                returnUser.use_email = DBuser.Select(i => i.Use_email).First();
                returnUser.use_avatar = DBuser.Select(i => i.Use_avatar).First();
                returnUser.dep_id = DBuser.Select(i => i.Dep_id).First();
                returnUser.dep_nameAR = DBuser.Select(i => i.Dep_nameAR).First();
                returnUser.dep_nameEN = DBuser.Select(i => i.Dep_nameEN).First();
                returnUser.academicRankID = DBuser.Select(i => i.academicRankID).First();
                returnUser.academicRankEN = DBuser.Select(i => i.academicRankEN).First();
                returnUser.academicRankAR = DBuser.Select(i => i.academicRankAR).First();

                return returnUser;
            }
            else return null;

        }

        public static async Task saveUser()
        {

            DataLayer.Tables.Users DBuser = new DataLayer.Tables.Users();
            DBuser.Use_id = User.use_id;
            DBuser.Use_nameEN = User.use_nameEN;
            DBuser.Use_nameAR = User.use_nameAR;
            DBuser.Use_phone = User.use_phone;
            DBuser.Use_picture = User.use_picture;
            DBuser.Use_typeID = User.use_typeID;
            DBuser.Use_gender = User.use_gender;
            DBuser.Use_email = User.use_email;
            DBuser.Use_avatar = User.use_avatar;
            DBuser.Dep_id = User.dep_id;
            DBuser.Dep_nameAR = User.dep_nameAR;
            DBuser.Dep_nameEN = User.dep_nameEN;
            DBuser.academicRankID = User.academicRankID;
            DBuser.academicRankEN = User.academicRankEN;
            DBuser.academicRankAR = User.academicRankAR;

            // first we make suer the user not exsited already
            var results = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(User.use_id)).CountAsync();


            //if the user is not exsited
            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(DBuser);
            }
            else
                await DBuilder._connection.UpdateAsync(DBuser);// if the user is exsited update his info

        }

       // <IEnumerable<Users>
        public static async Task<Boolean> getUsers()
        {
            // get data 
            var DBuser = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(User.use_id)).ToListAsync();

            // to check if the user we requisted is exsited or not ( if not return null) 
            var checker = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(User.use_id)).CountAsync();

            if (checker > 0)
            {

                //OtherUsers returnUser = new OtherUsers();
                User.use_id = DBuser.Select(i => i.Use_id).First();
                User.use_nameEN = DBuser.Select(i => i.Use_nameEN).First(); ;
                User.use_nameAR = DBuser.Select(i => i.Use_nameAR).First(); ;
                User.use_phone = DBuser.Select(i => i.Use_phone).First();
                User.use_picture = DBuser.Select(i => i.Use_picture).First();
                User.use_typeID = DBuser.Select(i => i.Use_typeID).First();
                User.use_gender = DBuser.Select(i => i.Use_gender).First();
                User.use_email = DBuser.Select(i => i.Use_email).First();
                User.use_avatar = DBuser.Select(i => i.Use_avatar).First();
                User.dep_id = DBuser.Select(i => i.Dep_id).First();
                User.dep_nameAR = DBuser.Select(i => i.Dep_nameAR).First();
                User.dep_nameEN = DBuser.Select(i => i.Dep_nameEN).First();
                User.academicRankID = DBuser.Select(i => i.academicRankID).First();
                User.academicRankEN = DBuser.Select(i => i.academicRankEN).First();
                User.academicRankAR = DBuser.Select(i => i.academicRankAR).First();
                return true;
                
            }
            else return false ;
        }


    }
}
