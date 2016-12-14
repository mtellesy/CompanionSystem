using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    class AnnouncementsObject
    {
        //          JSON2C#
        public int postID { get; set; }
        public int postPrivacyID { get; set; }
        public string postPrivacyNameAR { get; set; }
        public string postPrivacyNameEN { get; set; }
        public string postTypeID { get; set; }
        public string postTypeNameAR { get; set; }
        public string postTypeNameEN { get; set; }
        public string content { get; set; }
        public string postTime { get; set; }
        public int postBy { get; set; }
        public string postByName { get; set; }
    }
}
