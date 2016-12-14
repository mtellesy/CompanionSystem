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
                termSchedule.Ter_start = Convert.ToString(DateTime.Parse(terms.Select(i => i.Ter_start).First()));
                termSchedule.Ter_end = Convert.ToString(DateTime.Parse(terms.Select(i => i.Ter_end).First()));
                termSchedule.Ter_enrollment = Convert.ToString(DateTime.Parse(terms.Select(i => i.Ter_enrollment).First()));
                termSchedule.Ter_dropCourses = Convert.ToString(DateTime.Parse(terms.Select(i => i.Ter_dropCourses).First()));
                termSchedule.Ter_lastStudyDate = Convert.ToString(DateTime.Parse(terms.Select(i => i.Ter_lastStudyDate).First()));
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
