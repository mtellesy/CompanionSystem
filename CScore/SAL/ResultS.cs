using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    class ResultS:Template
    {
        public static List<Result> getSemesterResult()
        {
            String Path = "/results";
            List<Result> results = new List<Result>();

            return results;
        }

        public static List<AllResult> getAllResult()
        {
            String Path = "/result/" + User.use_id + "/transcript";
            List<AllResult> results = new List<AllResult>();

            return results;
        }
    
       
        
    }
}
