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
               
              
                Random r = new Random();

                DBuser.color_r = r.Next(10, 250);
                DBuser.color_g = r.Next(10, 250);
                DBuser.color_b = r.Next(10, 250);
                await DBuilder._connection.InsertAsync(DBuser);
            }
           else
            {
                var t = await DBuilder._connection.Table<Users>().Where(i => i.Use_id.Equals(user.use_id)).FirstAsync();
                DBuser.color_r = t.color_r;
                DBuser.color_g = t.color_g;
                DBuser.color_b = t.color_r;
                await DBuilder._connection.UpdateAsync(DBuser);// if the user is exsited update his info

            }

        }

        

        public static async Task<OtherUsers> getOtherUser(int user_id)
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
                returnUser.color_r = DBuser.Select(i => i.color_r).First();
                returnUser.color_g = DBuser.Select(i => i.color_g).First();
                returnUser.color_b = DBuser.Select(i => i.color_b).First();

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


        /// <summary>
        /// Get Lecturer Students ( all of them )
        /// in the current term
        /// </summary>
        /// <returns></returns>
        public static async Task<List<OtherUsers>> getLecturerStudent()
        {
            // get data 
            var Students = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term)).ToListAsync();

            // to check if the user we requisted is exsited or not ( if not return null) 
            var checker = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term)).CountAsync();

            var returnedStudents = new List<OtherUsers>();
            if (checker > 0)
            {
                foreach(var stu in Students)
                {
                    OtherUsers student = new OtherUsers();
                    student.use_id = stu.Stu_id;
                    student.use_nameEN = stu.Stu_nameEN;
                    student.use_nameAR = stu.Stu_nameAR;
                    student.courseID = stu.Cou_id;
                    student.groupID = stu.Gro_id;
                    student.termID = stu.Ter_id;
                    returnedStudents.Add(student);

                }

                return returnedStudents;
            }
            else return null;

        }

        /// <summary>
        /// Get Lecturer Students ( based on courseID)
        /// in the current term
        /// </summary>
        /// <returns></returns>
        public static async  Task<List<OtherUsers>> getLecturerStudent(String courseID)
        {
            // get data 
            var Students = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term))
                .Where(i=>i.Cou_id.Equals(courseID)).ToListAsync();

            // to check if the user we requisted is exsited or not ( if not return null) 
            var checker = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term))
                 .Where(i => i.Cou_id.Equals(courseID)).CountAsync();

            var returnedStudents = new List<OtherUsers>();
            if (checker > 0)
            {
                foreach (var stu in Students)
                {
                    OtherUsers student = new OtherUsers();
                    student.use_id = stu.Stu_id;
                    student.use_nameEN = stu.Stu_nameEN;
                    student.use_nameAR = stu.Stu_nameAR;
                    student.courseID = stu.Cou_id;
                    student.groupID = stu.Gro_id;
                    student.termID = stu.Ter_id;
                    returnedStudents.Add(student);

                }

                return returnedStudents;
            }
            else return null;

        }
    /// <summary>
    /// Get Lecturer Students ( based on courseID and groupID)
    /// in the current term
    /// </summary>
    /// <returns></returns>
    public static async Task<List<OtherUsers>> getLecturerStudent(String courseID,int groupID)
    {
        // get data 
        var Students = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term))
            .Where(i => i.Cou_id.Equals(courseID)).Where(i => i.Gro_id.Equals(groupID)).ToListAsync();

        // to check if the user we requisted is exsited or not ( if not return null) 
        var checker = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Ter_id.Equals(Semester.current_term))
             .Where(i => i.Cou_id.Equals(courseID)).Where(i => i.Gro_id.Equals(groupID)).CountAsync();

        var returnedStudents = new List<OtherUsers>();
        if (checker > 0)
        {
            foreach (var stu in Students)
            {
                OtherUsers student = new OtherUsers();
                student.use_id = stu.Stu_id;
                student.use_nameEN = stu.Stu_nameEN;
                student.use_nameAR = stu.Stu_nameAR;
                student.courseID = stu.Cou_id;
                student.groupID = stu.Gro_id;
                student.termID = stu.Ter_id;
                returnedStudents.Add(student);

            }

            return returnedStudents;
        }
        else return null;
    }

        public static async Task saveLecturerStudents(List<OtherUsers> students)
        {
            
            if(students !=null)
            foreach(var stu in students)
                {
                    DataLayer.Tables.LecturerStudentsL DBuser = new DataLayer.Tables.LecturerStudentsL();
                    DBuser.Cou_id = stu.courseID;
                    DBuser.Gro_id = stu.groupID;
                    DBuser.Stu_nameAR = stu.use_nameAR;
                    DBuser.Stu_nameEN = stu.use_nameEN;
                    DBuser.Stu_id = stu.use_id;
                    DBuser.Ter_id = stu.termID;

                    // first we make suer the user not exsited already
                    var results = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Stu_id.Equals(DBuser.Stu_id))
                    .Where(i=> i.Cou_id.Equals(DBuser.Cou_id))
                    .Where(i=> i.Gro_id.Equals(DBuser.Gro_id))
                    .Where(i=> i.Ter_id.Equals(DBuser.Ter_id)).CountAsync();


                    //if the user is not exsited
                    if (results <= 0)
                    {
                        await DBuilder._connection.InsertAsync(DBuser);
                    }
                    else
                    {
                        var userID = await DBuilder._connection.Table<LecturerStudentsL>().Where(i => i.Stu_id.Equals(DBuser.Stu_id))
                        .Where(i => i.Cou_id.Equals(DBuser.Cou_id))
                        .Where(i => i.Gro_id.Equals(DBuser.Gro_id))
                        .Where(i => i.Ter_id.Equals(DBuser.Ter_id)).FirstAsync();
                        DBuser.id = userID.id;
                        await DBuilder._connection.UpdateAsync(DBuser);// if the user is existed update his info

                    }

                }

        }
    }
}
