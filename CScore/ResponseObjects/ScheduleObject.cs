using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
   public class ScheduleObject
    {
        /*
        //      lecturer
        public String lecturerNameAR { set; get; }
        public String lecturerNameEN { set; get; }
        public int lecturerID { set; get; }
        //      group
        public String groupNameAR { set; get; }
        public String groupNameEN { set; get; }
        public int groupID { set; get; }
        //      day
        public String dayAR { set; get; }
        public String dayEN { set; get; }
        public int dayID { set; get; }
        //      classroom
        public String classRoomAR { set; get; }
        public String classRoomEN { set; get; }
        public int classRoomID { set; get; }
        //      time
        public int classTimeID { set; get; }
        public String timeStart { set; get; }
        public float timeDuration { set; get; }
     
        */

        //      as creatd by json2charp
        public int lecturerID { get; set; }
        public string lecturerNameAR { get; set; }
        public string lecturerNameEN { get; set; }
        public int dayID { get; set; }
        public string dayAR { get; set; }
        public string dayEN { get; set; }
        public int groupID { get; set; }
        public string groupNameAR { get; set; }
        public string groupNameEN { get; set; }
        public int classTimeID { get; set; }
        public string timeStart { get; set; }
        public double timeDuration { get; set; }
        public double duration { get; set; }
        public int classRoomID { get; set; }
        public string classRoomAR { get; set; }
        public string classRoomEN { get; set; }
        public int price { get; set; }
        public string Name { get; set; }

    }
}
