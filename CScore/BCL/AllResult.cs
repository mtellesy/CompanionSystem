using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
   public class AllResult
    {
        public String cou_id { get; set; }
        public String cou_nameAR { get; set; }
        public String cou_nameEN { get; set; }
        public int ter_id { get; set; }
        public String ter_nameAR { get; set; }
        public String ter_nameEN { get; set; }
        public String year { get; set; }
        public int cou_credits { get; set; }
        public float res_total { get; set; }
        /*
        public static List<AllResult> getAllResults()
        {
            List < AllResult> r = new List<AllResult>();
            Status s = new Status();
            s = internetChecker();
            if (s.status)
            {
                r = SAL.ResultS.getAllResults(User.use_id);

                DAL.ResultD.saveAllResult(r);
            }

            r = DAL.ResultD.getAllResult();
            return r;
        }*/

            /*
        public static void saveAllResults()
        {
            List<AllResult> r = new List<AllResult>();
            Status s = new Status();
            s = internetChecker();
            if (s.status)
            {
                r = SAL.ResultS.getAllResults(User.use_id);

                DAL.ResultD.saveAllResult(r);

            }

        }*/

    }
}
