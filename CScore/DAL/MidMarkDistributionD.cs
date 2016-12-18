using CScore.BCL;
using CScore.DataLayer;
using CScore.DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.DAL
{
    public static class MidMarkDistributionD
    {
        public static List<String> result;

        public static async Task<List<MidMarkDistribution>> getSemeterMidMarkDistribution(String cou_id)
        {
            List<MidMarkDistribution> r = new List<BCL.MidMarkDistribution>();
            var results = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i=>i.Cou_id.Equals(cou_id)).ToListAsync();//NEEDS NOT NULL OPERATOR FOR FINALMARK
                                                                                            //    var checker = await DBuilder._connection.Table<ResultsL>().CountAsync();
            foreach (var x in results)
            {
                BCL.MidMarkDistribution midMark = new BCL.MidMarkDistribution();
                midMark.MidMarkDistributionID = x.MidMarkDistributionID;
                midMark.Cou_id = x.Cou_id;
                midMark.Mid_nameAR = x.Mid_nameAR;
                midMark.Mid_nameEN = x.Mid_nameEN;
                midMark.Grade = x.grade;
                r.Add(midMark);
            }
            return r;
        }

        public static async Task saveSemesterMidMarkDistribution(MidMarkDistribution r)
        {
            CScore.DataLayer.Tables.MidMarkDistributionL midMarks = new MidMarkDistributionL();
            midMarks.MidMarkDistributionID = r.MidMarkDistributionID;
            midMarks.Cou_id = r.Cou_id;
            midMarks.Mid_nameAR = r.Mid_nameAR;
            midMarks.Mid_nameEN = r.Mid_nameEN;
            midMarks.grade = r.Grade;
            var results = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(r.Cou_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(midMarks);
            }
            else
                await DBuilder._connection.UpdateAsync(midMarks);

        }

    }
}
