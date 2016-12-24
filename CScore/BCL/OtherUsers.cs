﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class OtherUsers
    {
        public int use_id { get; set; }

        public String use_nameAR { get; set; }

        public String use_nameEN { get; set; }

        public String dep_id { get; set; }

        public String dep_nameAR { get; set; }

        public String dep_nameEN { get; set; }

        public String use_email { get; set; }

        public long use_phone { get; set; }

        public String use_gender { get; set; }

        public String use_picture { get; set; }

        public String use_avatar { get; set; }

        public String use_typeID { get; set; }

        public int academicRankID { get; set; }

        public String academicRankAR { get; set; }

        public String academicRankEN { get; set; }

        public static async Task<StatusWithObject<OtherUsers>> getOtherUser(int userID)
        {
            StatusWithObject<OtherUsers> returndValue = new StatusWithObject<OtherUsers>();
            Status status = new Status();
            OtherUsers user = new OtherUsers();

            if (await UpdateBox.CheckForInternetConnection())
            {
               // SAL.UserS userCatcher = new SAL.UserS();
             returndValue =  await SAL.UserS.getOtherUser(userID);
             if(returndValue.status.status == true)
                await DAL.UsersD.saveOtherUser(returndValue.statusObject);
            }
            
            user = await DAL.UsersD.getOtherUser(userID);
            returndValue.statusObject = user;
            return returndValue;
        }
    }
}
