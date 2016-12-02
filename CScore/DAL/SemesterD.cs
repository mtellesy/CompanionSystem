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
        public static async Task<Semester> getSemesterSchedule()
        {
           Semester termSchedule = new BCL.Semester() ;
            var countOfTerms = await DBuilder._connection.Table<SemesterL>().CountAsync();
            if( countOfTerms > 0)
            {
                var terms = await DBuilder._connection.Table<SemesterL>().OrderByDescending(i => i.Ter_id).ToListAsync();
                termSchedule.ter_id = terms.Select(i => i.Ter_id).First();
                termSchedule.ter_nameAR = terms.Select(i => i.Ter_nameAR).First();
                termSchedule.ter_nameEN = terms.Select(i => i.Ter_nameEN).First();
                termSchedule.ter_start = DateTime.Parse(terms.Select(i => i.Ter_start).First());
                termSchedule.ter_end = DateTime.Parse(terms.Select(i => i.Ter_end).First());
                termSchedule.ter_enrollment = DateTime.Parse(terms.Select(i => i.Ter_enrollment).First());
                termSchedule.ter_dropCourses = DateTime.Parse(terms.Select(i => i.Ter_dropCourses).First());
                termSchedule.ter_lastStudyDate = DateTime.Parse(terms.Select(i => i.Ter_lastStudyDate).First());
                return termSchedule;

            }
            
            else 
            return null;
        }

        public static async Task saveSemesterSchedule(Semester termSchedule)
        {
            var count = await DBuilder._connection.Table<SemesterL>().Where(i => i.Ter_id.Equals(termSchedule.ter_id)).CountAsync();

            SemesterL term = new SemesterL();
            term.Ter_id = termSchedule.ter_id;
            term.Ter_nameAR = termSchedule.ter_nameAR;
            term.Ter_nameEN = termSchedule.ter_nameEN; 
            term.Ter_start = termSchedule.ter_start.ToString();
            term.Ter_end = termSchedule.ter_end.ToString();
            term.Ter_enrollment = termSchedule.ter_enrollment.ToString();
            term.Ter_dropCourses = termSchedule.ter_dropCourses.ToString();
            term.Ter_lastStudyDate = termSchedule.ter_lastStudyDate.ToString();

            if (count <= 0)
            {
                await DBuilder._connection.InsertAsync(term);
            }
            else
            {
                await DBuilder._connection.UpdateAsync(term);
            }
        }
    }
}
