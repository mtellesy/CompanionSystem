using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;
using CScore.DataLayer;
using CScore.BCL;
using SQLite.Net;

namespace CScore.DAL
{
    public static class ResultD
    {
        public static List<String> results;


        // NEEDS TO ASK TOTO ABOUT IT
        
        public static async  Task<List<Result>> getSemesterResults(int ter_id)
        {
            List<Result> r = new List<Result>();
            var results = await DBuilder._connection.Table<ResultsL>().Where(i => i.Ter_id.Equals(ter_id)).ToListAsync();
            var checker = await DBuilder._connection.Table<ResultsL>().Where(i => i.Ter_id.Equals(ter_id)).CountAsync();


            if (checker > 0)
            {
             
                foreach (var x in results) {
                    Result returnResult = new Result();
                    returnResult.cou_id = results.Select(i => i.Cou_id).First();
                    returnResult.final = results.Select(i => i.Res_total).First(); ;
                    var mids = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(returnResult.cou_id)).ToListAsync();
                    var checker2 = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(returnResult.cou_id)).CountAsync();

                    if (checker2 > 0)
                    {
                        List<float> midMarks = mids.Select(i => i.grade).ToList();
                        returnResult.midExams = midMarks;
                    }
                    r.Add(returnResult);
                }
                return r;
            }
            else
            {
                return null;

            }

        }*/
        /*

        public static async Task<List<Result>> getAllResults()
        {

            List<Result> r = new List<Result>();
            var results = await DBuilder._connection.Table<ResultsL>().ToListAsync();
            var checker = await DBuilder._connection.Table<ResultsL>().CountAsync();


            if (checker > 0)
            {

                foreach (var x in results)
                {
                    Result returnResult = new Result();
                    returnResult.cou_id = results.Select(i => i.Cou_id).First();
                    returnResult.final = results.Select(i => i.Res_total).First(); ;
                    var mids = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(returnResult.cou_id)).ToListAsync();
                    var checker2 = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(returnResult.cou_id)).CountAsync();

                    if (checker2 > 0)
                    {
                        List<float> midMarks = mids.Select(i => i.grade).ToList();
                        returnResult.midExams = midMarks;
                    }
                    r.Add(returnResult);
                }
                return r;
            }
            else
            {
                return null;

            }
            
        }*/

        public static async Task saveResult(Result x)
        {
            var count = await DBuilder._connection.Table<ResultsL>().Where(i => i.Cou_id.Equals(x.cou_id)).CountAsync();
            var count2 = await DBuilder._connection.Table<MidMarkDistributionL>().Where(i => i.Cou_id.Equals(x.cou_id)).CountAsync();

            var result = new Result()
            {
                cou_id = x.cou_id,
                final = x.final,
                midExams = x.midExams
            };
            if (count <= 0)
            {
                await DBuilder._connection.InsertAsync(result.cou_id);
                await DBuilder._connection.InsertAsync(result.final);
                if (count2 <= 0)
                {
                    await DBuilder._connection.InsertAsync(result.midExams);
                }
                else
                {
                    await DBuilder._connection.UpdateAsync(result.midExams);
                }
            }
            else
            {
                await DBuilder._connection.UpdateAsync(result);
                if (count2 <= 0)
                {
                    await DBuilder._connection.InsertAsync(result.midExams);
                }
                else
                {
                    await DBuilder._connection.UpdateAsync(result.midExams);
                }
            }

            await DBuilder._connection.InsertAsync(result);
        }
    }

    
}
