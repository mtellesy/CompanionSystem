using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
  public  class Result
    {
        public String cou_id;
        public float final;
        public List<float> midExams;

        public void saveResult()
        {
            //     DAL.ResultD.saveSemesterResult(this);
        }
        /*
        public static void getAndSaveAllResults()
        {
            List < Result> r = new List<Result>();
            Status s = new Status();
            s = internetChecker();
            if (s.status)
            {
                r = SAL.ResultS.getAllResults(User.use_id);

                DAL.ResultD.saveAllResults(r);
            }
           
            r=DAL.ResultD.getAllResults()
            return r
        }*/
        /*
        public static List<Result> getSemesterResults()
        {
            List<Result> r = new List<Result>();
            Status s = new Status();
            s = internetChecker();
            if (s.status)
            {
                r = SAL.ResultS.getSemesterResults(User.use_id, Semester.ter_id);

                DAL.ResultD.saveSemesterResults(r);
            }

            r = DAL.ResultD.getSemesterResults(Semester.ter_id);
            return r;
        }*/

        public float getTotalResult()
        {
            float total = 0;
            foreach (float x in midExams)
            {
                total += x;
            }
            total += final;
            return total;
        }



    }

}
