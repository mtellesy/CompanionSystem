using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
    public class Notification
    {
        public int notificationID { set; get; }
        public String notificationText { set; get; }
        public int postID { set; get; }
        public String courseID { set; get; }
    }
}
