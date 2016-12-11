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
        public List<MidMarkDistribution> midExams;

     
    
        
        public static async  Task<List<Result>> getSemesterResults()
        {
            List<Result> r = new List<Result>();
      
            if (await UpdateBox.CheckForInternetConnection())
            {
             //   r = SAL.ResultS.getSemesterResults(User.use_id, Semester.current_term);
                foreach(Result x in r)
                {
                    await DAL.ResultD.saveSemesterResult(x);
                    foreach (MidMarkDistribution y in x.midExams)
                    {
                       await DAL.MidMarkDistributionD.saveSemesterMidMarkDistribution(y);
                    }
                }
         
                foreach(Result x in r)
                {
                    await DAL.ResultD.saveSemesterResult(x);
                    foreach (MidMarkDistribution y in x.midExams)
                    {
                        await DAL.MidMarkDistributionD.saveSemesterMidMarkDistribution(y);
                    }
                }
                return r;
            }
            List<Result> r2 = new List<Result>();
            r2 =  
              await  DAL.ResultD.getSemesterResult();

            foreach (Result x in r2)
            {
                //foreach (MidMarkDistribution y in x.midExams)
                {
                    x.midExams=await DAL.MidMarkDistributionD.getSemeterMidMarkDistribution(x.cou_id);
                }
            }
          //  r = DAL.ResultD.getSemeterResult(Semester.ter_id);
            return r2;
        }

        public float getTotalResult()
        {
            float total = 0;
            foreach (MidMarkDistribution x in midExams)
            {
                total += x.grade;
            }
            total += final;
            return total;
        }



    }

}
