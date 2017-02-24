using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.FixdStrings
{
   public static class Time
    {
        public static String getTimeByID(int id)
        {
            switch(id)
            {
                case 1: return "8:00";
                case 2: return "9:30";
                case 3: return "11:00";
                case 4: return "12:30";
                case 5: return "2:00";
                case 6: return "3:30";
                default: return "Unrecognize Time id";
            }
        }
    }
}
