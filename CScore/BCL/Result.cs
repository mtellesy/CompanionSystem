using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    class Result
    {
        private String cou_id;
        private float final;
        private List<float> midExams;

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
            else
           {
               
            }

        }*/

        public float getTotalResult()
        {
            float total = 0;
            foreach(float x in midExams)
            {
                total += x;
            }
            total += final;
            return total;
        }

      



}
