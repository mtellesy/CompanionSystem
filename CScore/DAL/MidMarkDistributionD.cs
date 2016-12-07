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
                midMark.midMarkDistributionID = x.MidMarkDistributionID;
                midMark.cou_id = x.Cou_id;
                midMark.mid_nameAR = x.Mid_nameAR;
                midMark.mid_nameEN = x.Mid_nameEN;
                midMark.grade = x.grade;
                r.Add(midMark);
            }
            return r;
        }

        public static async Task saveSemesterMidMarkDistribution(MidMarkDistribution r)
        {
            CScore.DataLayer.Tables.MidMarkDistributionL midMarks = new MidMarkDistributionL();
            midMarks.MidMarkDistributionID = r.midMarkDistributionID;
            midMarks.Cou_id = r.cou_id;
            midMarks.Mid_nameAR = r.mid_nameAR;
            midMarks.Mid_nameEN = r.mid_nameEN;
            midMarks.grade = r.grade;
            var results = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(r.cou_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(midMarks);
            }
            else
                await DBuilder._connection.UpdateAsync(midMarks);

        }

    }
}
