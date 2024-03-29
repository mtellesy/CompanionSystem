﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
   public class GradeObject
    {
        //      course
        public String courseID { set; get; }
        public String NameAR { set; get; }
        public String NameEN { set; get; }
        public float finalMark { set; get; }
        public int credit { set; get; }

        //      term
        public int termID { set; get; }
        public String termNameAR { set; get; }
        public String termNameEN { set; get; }
        public String year { set; get; }
    }
}
