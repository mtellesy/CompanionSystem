using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Schedule
    {
        //              *** Properties ***
        int tea_id { get; set; }
         String dayAR { get; set; }
         String dayEN { get; set; }
         int dayID { get; set; }
         String gro_NameAR { get; set; }
         String gro_NameEN { get; set; }
         int gro_id { get; set; }
         String classRoomAR { get; set; }
         String classRoomEN { get; set; }
         int classRoomID { get; set; }
         int classTimeID { get; set; }
         String classStart { get; set; } // maybe it will be changed
         double classDuration { get; set; }

        //              *** setters and getters ***
        //      tea_id
        public int Tea_id
        {
            set
            {
                tea_id = value;
            }
            get
            {
                return tea_id;
            }
        }
        //      dayAR
        public String DayAR
        {
            set
            {
                dayAR = value;
            }
            get
            {
                return dayAR;
            }
        }
        //      dayEN
        public String DayEN
        {
            set
            {
                dayEN = value;
            }
            get
            {
                return dayEN;
            }
        }
        //      dayID
        public int DayID
        {
            set
            {
                dayID = value;
            }
            get
            {
                return dayID;
            }
        }
        //      gro_NameAR
        public String Gro_NameAR
        {
            set
            {
                gro_NameAR = value;
            }
            get
            {
                return gro_NameAR;
            }
        }
        //      gro_NameEN
        public String Gro_NameEN
        {
            set
            {
                gro_NameEN = value;
            }
            get
            {
                return gro_NameEN;
            }
        }
        //      gro_id
        public int Gro_id
        {
            set
            {
                gro_id = value;
            }
            get
            {
                return gro_id;
            }
        }
        //      classRoomAR
        public String ClassRoomAR
        {
            set
            {
                classRoomAR = value;
            }
            get
            {
                return classRoomAR;
            }
        }
        //      classRoomEN
        public String ClassRoomEN
        {
            set
            {
                classRoomEN = value;
            }
            get
            {
                return classRoomEN;
            }
        }
        //      classRoomID
        public int ClassRoomID
        {
            set
            {
                classRoomID = value;
            }
            get
            {
                return classRoomID;
            }
        }
        //      classTimeID
        public int ClassTimeID
        {
            set
            {
                classTimeID = value;
            }
            get
            {
                return classTimeID;
            }
        }
        //      classStart
        public String ClassStart
        {
            set
            {
                classStart = value;
            }
            get
            {
                return classStart;
            }
        }
        //      classDuration
        public double ClassDuration
        {
            set
            {
                classDuration = value;
            }
            get
            {
                return classDuration;
            }
        }
    }
}
