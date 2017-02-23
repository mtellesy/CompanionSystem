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
  public static  class SemesterD
    {

        // get the last semester schedule based on the first one on the desc order
        public static async Task<Semester> getSemesterSchedule()
        {
           Semester termSchedule = new BCL.Semester() ;
            var countOfTerms = await DBuilder._connection.Table<SemesterL>().CountAsync();
            if( countOfTerms > 0)
            {
                var terms = await DBuilder._connection.Table<SemesterL>().OrderByDescending(i => i.Ter_id).ToListAsync();
                termSchedule.Ter_id = terms.Select(i => i.Ter_id).First();
                termSchedule.Ter_nameAR = terms.Select(i => i.Ter_nameAR).First();
                termSchedule.Ter_nameEN = terms.Select(i => i.Ter_nameEN).First();
                termSchedule.Ter_start = terms.Select(i => i.Ter_start).First();
                termSchedule.Ter_end = terms.Select(i => i.Ter_end).First();
                termSchedule.Ter_enrollment = terms.Select(i => i.Ter_enrollment).First();
                termSchedule.Ter_dropCourses = terms.Select(i => i.Ter_dropCourses).First();
                termSchedule.Ter_lastStudyDate = terms.Select(i => i.Ter_lastStudyDate).First();
                termSchedule.Year = terms.Select(i => i.year).First();
                
                return termSchedule;

            }
            
            else 
            return null;
        }
        

        //save user Schedule
        public static async Task saveSemesterSchedule(Semester termSchedule)
        {
            var count = await DBuilder._connection.Table<SemesterL>().Where(i => i.Ter_id.Equals(termSchedule.Ter_id)).CountAsync();

            SemesterL term = new SemesterL();
            term.Ter_id = termSchedule.Ter_id;
            term.Ter_nameAR = termSchedule.Ter_nameAR;
            term.Ter_nameEN = termSchedule.Ter_nameEN; 
            term.Ter_start = termSchedule.Ter_start.ToString();
            term.Ter_end = termSchedule.Ter_end.ToString();
            term.Ter_enrollment = termSchedule.Ter_enrollment.ToString();
            term.Ter_dropCourses = termSchedule.Ter_dropCourses.ToString();
            term.Ter_lastStudyDate = termSchedule.Ter_lastStudyDate.ToString();
            term.year = termSchedule.Year.ToString();
            if (count <= 0)
            {
                await DBuilder._connection.InsertAsync(term);
            }
            else
            {
                await DBuilder._connection.UpdateAsync(term);
            }
        }

        //public static async Task<Semester> getCurrentSemester()
        //{
        //    var semester = await DBuilder._connection.Table<SemesterL>().OrderByDescending(i => i.Ter_id).FirstAsync();

        //    Semester newSem = new Semester();

        //    newSem.Ter_id = semester.Ter_id;
        //    newSem.Ter_nameAR = semester.Ter_nameAR;
        //    newSem.Ter_nameEN = semester.Ter_nameEN;
        //    newSem.Ter_start = semester.Ter_start;
        //    newSem.Ter_end = semester.Ter_end;
        //    newSem.Ter_enrollment = semester.Ter_enrollment;
        //    newSem.Ter_dropCourses = semester.Ter_dropCourses;
        //    newSem.Ter_lastStudyDate = semester.Ter_lastStudyDate;
        //    newSem.Year = semester.year;
        //    newSem.Exam = new List<Exams>();
        //    return newSem;
            
        //}
    }
}
