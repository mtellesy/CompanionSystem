using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Schedule
    {
        public String lecturerNameAR { get; set; }
        public String lecturerNameEN { get; set; }
        public int lecturerID { get; set; }
        public String dayAR { get; set; }
        public String dayEN { get; set; }
        public int dayID { get; set; }
        public String groupNameAR { get; set; }
        public String groupNameEN { get; set; }
        public int groupID { get; set; }
        public String classRoomAR { get; set; }
        public String classRoomEN { get; set; }
        public int classRoomID { get; set; }
        public int classTimeID { get; set; }
        public float classStart { get; set; } // maybe it will be changed
        public float classDuration { get; set; }
    }
}
