using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
  public  class ResultsObject
    {   
        public String course_id { set; get; }
        public List<float> midMark { set; get; }
        public float finalMark { set; get; }

        public static BCL.Result convertToResult(ResultsObject Jresult)
        {
            BCL.Result result = new BCL.Result();
            BCL.MidMarkDistribution y = new BCL.MidMarkDistribution();
            result.cou_id = Jresult.course_id;
            result.final = Jresult.finalMark;
            int id = 0;
            result.midExams = new List<BCL.MidMarkDistribution>();
            foreach (float grade in Jresult.midMark)
            {
                y.cou_id = Jresult.course_id;
                y.mid_nameAR = null;
                y.mid_nameEN = null;
                y.midMarkDistributionID = ++id;
                y.grade = grade;
                result.midExams.Add(y);
            }
            return result;
        }

        public static BCL.AllResult convertToAllResult(GradeObject Jresult)
        {
            BCL.AllResult result = new BCL.AllResult();
            result.Cou_id = Jresult.courseID;
            result.Cou_nameAR = Jresult.courseNameAR;
            result.Cou_nameEN = Jresult.courseNameEN;
            result.Cou_credits = Jresult.credit;
            result.Res_total = Jresult.finalMark;
            result.Ter_id = Jresult.termID;
            result.Ter_nameAR = Jresult.termNameAR;
            result.Ter_nameEN = Jresult.termNameEN;
            result.Year = Jresult.year;

            return result;
        }
    }
}
