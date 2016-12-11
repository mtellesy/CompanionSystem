using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    class ScheduleObject
    {

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

    }
}
