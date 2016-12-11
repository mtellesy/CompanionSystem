using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
  public class MessagesObject
    {
        //      message
        public int messageID { set; get; }
        public int messageFrom { set; get; }
        public int messageTo { set; get; }
        public String messageTitle { set; get; }
        public String messageText { set; get; }
        public String messageTime { set; get; }
        //      attatchement
        public string attachementID { set; get; }
        public string attachementPath { set; get; }
        public string attachementType { set; get; }
        //      others
        public bool seenState { set; get; }
    }
}
