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
        public static List<String> result;

        public static async Task<List<Result>> getSemesterResult()
        {
            List<Result> r = new List<Result>();
            var results = await DBuilder._connection.Table<StudentCoursesL>().Where(i=>i.Ter_id.Equals(Semester.current_term)).ToListAsync();//NEEDS NOT NULL OPERATOR FOR FINALMARK
               var checker = await DBuilder._connection.Table<ResultsL>().CountAsync();
            if (checker > 0)
            {
                foreach (var x in results)
                {
                    Result returnResult = new Result();
                    returnResult.cou_id = x.Cou_id;
                    returnResult.final = x.finalMark;
                    r.Add(returnResult);
                }
                return r;
            }
            else
            {
                return null;
            }
         }

        public static async Task<List<AllResult>> getAllResult()
        {
            List<AllResult> r = new List<AllResult>();
            var results = await DBuilder._connection.Table<ResultsL>().ToListAsync();
            //    var checker = await DBuilder._connection.Table<ResultsL>().CountAsync();
            foreach (var x in results)
            {
                AllResult returnResult = new AllResult();
                returnResult.cou_id= x.Cou_id;
                returnResult.cou_credits = x.Cou_credits;
                returnResult.cou_nameAR = x.Cou_nameAR;
                returnResult.cou_nameEN = x.Cou_nameEN;
                returnResult.res_total = x.Res_total;
                returnResult.ter_id = x.Ter_id;
                returnResult.ter_nameAR = x.Ter_nameAR;
                returnResult.ter_nameEN = x.Ter_nameEN;
                returnResult.year = x.year; 
                r.Add(returnResult);
            }
            return r;
        }

        public static async Task saveSemesterResult(Result r)
        {
            CScore.DataLayer.Tables.StudentCoursesL studentCourses = new StudentCoursesL();
            studentCourses.Cou_id = r.cou_id;
            studentCourses.finalMark = r.final;
            studentCourses.Ter_id = Semester.current_term;
            var results = await DBuilder._connection.Table<StudentCoursesL>().Where(i => i.Cou_id.Equals(r.cou_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(studentCourses);
            }
            else
                await DBuilder._connection.UpdateAsync(studentCourses);

        }

        public static async Task saveAllResult(AllResult r)
        {
            CScore.DataLayer.Tables.ResultsL result = new ResultsL();
            result.Cou_id = r.cou_id;
            result.Cou_nameEN = r.cou_nameEN;
            result.Cou_nameAR = r.cou_nameAR;
            result.Cou_credits = r.cou_credits;
            result.Ter_id = r.ter_id;
            result.Ter_nameAR = r.ter_nameAR;
            result.Ter_nameEN = r.ter_nameEN;
            result.year = r.year;
            result.Res_total = r.res_total;
            var results = await DBuilder._connection.Table<ResultsL>().Where(i => i.Cou_id.Equals(r.cou_id)).CountAsync();

            if (results <= 0)
            {
                await DBuilder._connection.InsertAsync(result);
            }
            else
            {
                await DBuilder._connection.UpdateAsync(result);
            }
        }
        


















































        /*





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
        /*

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

    */
    }

    
}
