using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class OtherUsers
    {
        public int use_id { get; set; }

        public String use_nameAR { get; set; }

        public String use_nameEN { get; set; }

        public int dep_id { get; set; }

        public String dep_nameAR { get; set; }

        public String dep_nameEN { get; set; }

        public String use_email { get; set; }

        public long use_phone { get; set; }

        public String use_gender { get; set; }

        public String use_picture { get; set; }

        public String use_avatar { get; set; }

        public int use_typeID { get; set; }

        public int academicRankID { get; set; }

        public String academicRankAR { get; set; }

        public String academicRankEN { get; set; }

        public void saveUser(OtherUsers user)
        {

        }
    }
}
