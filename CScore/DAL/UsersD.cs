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

        public static async Task<OtherUsers> getOtherUser(int user_id)
        {
           // get out data 
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

        public static async Task saveUser(String name)
        {
            
            var user = new Users()
            {
                Use_nameEN = name
            };
      
           
          await DBuilder._connection.InsertAsync(user);

        }

       // <IEnumerable<Users>
        public static async Task<List<String>> getUsers()
        {
            var entities = await DBuilder._connection.Table<Users>().ToListAsync();
         List<String>   results = entities.Select(i => i.Use_nameEN).ToList();
            return results;
        }


    }
}
