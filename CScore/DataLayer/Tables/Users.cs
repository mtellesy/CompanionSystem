using System;
using SQLite.Net;
//using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Attributes;


namespace CScore.DataLayer.Tables
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey]
        public int Use_id { get; set; }

       public String Use_nameAR { get; set; }

        public String Use_nameEN { get; set; }
        
        public String Dep_id { get; set; }
        
        public String Dep_nameAR { get; set; }

        public String Dep_nameEN { get; set; }

        public String Use_email { get; set; }

        public long Use_phone { get; set; }

        public String Use_gender { get; set; }

        public String Use_picture { get; set; }

        public String Use_avatar { get; set; }

        public String Use_typeID { get; set; }

        public int academicRankID { get; set; }

        public String academicRankAR { get; set; }

        public String academicRankEN { get; set; }
        
        public int color_r { set; get; }

        public int color_g { set; get; }

        public int color_b { set; get; }

    }
}
