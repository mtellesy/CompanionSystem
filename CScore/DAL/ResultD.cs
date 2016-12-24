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
              
            if (results.Count > 0)
            {
                foreach (var x in results)
                {
                    Result returnResult = new Result();
                    returnResult.Cou_id = x.Cou_id;
                    returnResult.Final = x.finalMark;                    
                    returnResult.MidExams = await DAL.MidMarkDistributionD.getSemeterMidMarkDistribution(returnResult.Cou_id);
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
                returnResult.Cou_id= x.Cou_id;
                returnResult.Cou_credits = x.Cou_credits;
                returnResult.Cou_nameAR = x.Cou_nameAR;
                returnResult.Cou_nameEN = x.Cou_nameEN;
                returnResult.Res_total = x.Res_total;
                returnResult.Ter_id = x.Ter_id;
                returnResult.Ter_nameAR = x.Ter_nameAR;
                returnResult.Ter_nameEN = x.Ter_nameEN;
                returnResult.Year = x.year; 
                r.Add(returnResult);
            }
            return r;
        }

        public static async Task saveSemesterResult(Result r)
        {
            CScore.DataLayer.Tables.StudentCoursesL studentCourses = new StudentCoursesL();
            studentCourses.Cou_id = r.Cou_id;
            studentCourses.finalMark = r.Final;
            studentCourses.Ter_id = Semester.current_term;
            var results = DBuilder._connection.Table<StudentCoursesL>().Where(i => i.Cou_id.Equals(r.Cou_id)).Where(
                i => i.Ter_id.Equals(studentCourses.Ter_id));
            

            if (await results.CountAsync() <= 0)
            {
                await DBuilder._connection.InsertAsync(studentCourses);
            }
            else
            {
                await DBuilder._connection.UpdateAsync(studentCourses);
            }

            foreach (MidMarkDistribution x in r.MidExams)
            {
                await MidMarkDistributionD.saveSemesterMidMarkDistribution(x);
            }
        }

        public static async Task saveAllResult(AllResult r)
        {
            CScore.DataLayer.Tables.ResultsL result = new ResultsL();
            result.Cou_id = r.Cou_id;
            result.Cou_nameEN = r.Cou_nameEN;
            result.Cou_nameAR = r.Cou_nameAR;
            result.Cou_credits = r.Cou_credits;
            result.Ter_id = r.Ter_id;
            result.Ter_nameAR = r.Ter_nameAR;
            result.Ter_nameEN = r.Ter_nameEN;
            result.year = r.Year;
            result.Res_total = r.Res_total;
            var results = await DBuilder._connection.Table<ResultsL>().Where(i => i.Cou_id.Equals(r.Cou_id)).CountAsync();

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
