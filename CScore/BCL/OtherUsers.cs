using System;
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

        //used only to save lecturer students
        /// <summary>
        /// courseID is used only when getting lecturer studetns
        /// </summary>
        public String courseID { get; set; }
        /// <summary>
        /// termID is used only when getting lecturer studetns
        /// </summary>
        public int termID { get; set; }
        /// <summary>
        /// groupId is used only when getting lecturer studetns
        /// </summary>
        public int groupID { get; set; }

        public static async Task<StatusWithObject<OtherUsers>> getOtherUser(int userID)
        {
            StatusWithObject<OtherUsers> returndValue = new StatusWithObject<OtherUsers>();
            Status status = new Status();
            OtherUsers user = new OtherUsers();

            if (await UpdateBox.CheckForInternetConnection())
            {
             
             returndValue =  await SAL.UserS.getOtherUser(userID);
             if(returndValue.status.status == true)
                await DAL.UsersD.saveOtherUser(returndValue.statusObject);
            }
            
            user = await DAL.UsersD.getOtherUser(userID);
            returndValue.statusObject = user;
            return returndValue;
        }


        /// <summary>
        /// Get all the lecturer Students for this semester
        /// </summary>
        /// <returns></returns>
        public static async Task<StatusWithObject<List<OtherUsers>>> getLecturerStudents()
        {
            StatusWithObject<List<OtherUsers>> returndValue = new StatusWithObject<List<OtherUsers>>();
            returndValue.status = new Status();
            returndValue.status.status = false;
            returndValue.status.message = "";
            if (await UpdateBox.CheckForInternetConnection())
            {

                returndValue = await SAL.UserS.getLecturerStudents();
                if (returndValue.status.status == true)
                    await DAL.UsersD.saveLecturerStudents(returndValue.statusObject);
                returndValue.statusObject = new List<OtherUsers>();
            }
            returndValue.statusObject = await DAL.UsersD.getLecturerStudent();

            return returndValue;
        }
        /// <summary>
        /// Get lecturer Students for this semester by courseID
        /// </summary>
        /// <returns></returns>
        public static async Task<StatusWithObject<List<OtherUsers>>> getLecturerStudents(String courseID)
        {
            StatusWithObject<List<OtherUsers>> returndValue = new StatusWithObject<List<OtherUsers>>();
            returndValue.status.status = false;
            returndValue.status.message = "";
            if (await UpdateBox.CheckForInternetConnection())
            {

                returndValue = await SAL.UserS.getLecturerStudents();
                if (returndValue.status.status == true)
                    await DAL.UsersD.saveLecturerStudents(returndValue.statusObject);
                returndValue.statusObject = new List<OtherUsers>();
            }
            returndValue.statusObject = await DAL.UsersD.getLecturerStudent(courseID);

            return returndValue;
        }
        /// <summary>
        /// Get lecturer Students for this semester by courseID
        /// and GroupID
        /// </summary>
        /// <returns></returns>
        public static async Task<StatusWithObject<List<OtherUsers>>> getLecturerStudents(String courseID,int groupID)
        {
            StatusWithObject<List<OtherUsers>> returndValue = new StatusWithObject<List<OtherUsers>>();
            returndValue.status.status = false;
            returndValue.status.message = "";
            if (await UpdateBox.CheckForInternetConnection())
            {

                returndValue = await SAL.UserS.getLecturerStudents();
                if (returndValue.status.status == true)
                    await DAL.UsersD.saveLecturerStudents(returndValue.statusObject);
                returndValue.statusObject = new List<OtherUsers>();
            }
            returndValue.statusObject = await DAL.UsersD.getLecturerStudent(courseID,groupID);

            return returndValue;
        }
    }

    
    
}
