using System;
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
    class AttachmentL
    {
        [PrimaryKey]
        public long AttacmentID { get; set; }
        
        public long Mes_id { get; set; }
        
        public String path { get; set; }
        
        public String type { get; set; }

    }
}
