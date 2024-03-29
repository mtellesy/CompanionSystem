﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Attributes;

namespace CScore.DataLayer.Tables
{
    public class MidMarkDistributionL
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public int MidMarkDistributionID { get; set; }

        public int ter_id { set; get; }

        public String Cou_id { get; set; }

        public String Mid_nameAR { get; set; }

        public String Mid_nameEN { get; set; }

        public float grade { get; set; }
    }
}
