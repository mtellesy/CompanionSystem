using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
  public  class Result
    {
        //              *** Properties ***
         String cou_id;
         float final;
         List<MidMarkDistribution> midExams;

        //              *** setters and getters ***

        //        cou_id
        public String Cou_id
        {
            set
            {
                cou_id = value;
            }
            get
            {
                return cou_id;
            }
        }
        //        final
        public float Final
        {
            set
            {
                final = value;
            }
            get
            {
                return final;
            }
        }
        //        midExams
        public List<MidMarkDistribution> MidExams
        {
            set
            {
                midExams = value;
            }
            get
            {
                return midExams;
            }
        }


        //              *** Methods ***

        public static async  Task<StatusWithObject<List<Result>>> getSemesterResults()
        {
            StatusWithObject<List<Result>> returnedValue = new StatusWithObject<List<Result>>();
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.ResultS.getSemesterResult();
                if (returnedValue.status.status == true)
                {
                    foreach (Result x in returnedValue.statusObject)
                    {
                        await DAL.ResultD.saveSemesterResult(x);                        
                    }

                }                                
            }
            returnedValue.statusObject= await  DAL.ResultD.getSemesterResult();

            return returnedValue;
        }

        public float getTotalResult()
        {
            float total = 0;
            foreach (MidMarkDistribution x in midExams)
            {
                total += x.Grade;
            }
            total += final;
            return total;
        }



    }

}
