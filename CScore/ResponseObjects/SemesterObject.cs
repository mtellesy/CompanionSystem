using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
 public class SemesterObject
    {
       
        public int termID { set; get; }
        public String nameAR { set; get; }
        public String nameEN { set; get; }
        public String year { set; get; }
        public String termStart { set; get; }
        public String termEnd { set; get; }
        public String lastStudyingDate { get; set; }
        public String courseEnrollmentStart { get; set; }
        public String courseEnrollmentDuration { get; set; }
        public String courseDisEnrollmentStart { get; set; }
        public List<ExamsObject> exam { set; get; }

        //      converters
        public static Semester convertToSemester(SemesterObject sem)
        {
            Semester semester = new Semester();
            
            semester.Ter_id = sem.termID;
            semester.Ter_nameAR = sem.nameAR;
            semester.Ter_nameEN = sem.nameEN;
            semester.Ter_start = sem.termStart;
            semester.Ter_end = sem.termEnd;
            semester.Ter_lastStudyDate = sem.lastStudyingDate;
            semester.Ter_enrollment = sem.courseEnrollmentStart;
            semester.Ter_dropCourses = sem.courseDisEnrollmentStart;

            semester.Year = sem.year;
            semester.Exam = new List<Exams>();
            if (sem.exam != null)
            {
                foreach (ExamsObject x in sem.exam)
                {
                    Exams ex = new Exams();
                    ex.ExamTypeAR = x.examTypeAR;
                    ex.ExamTypeEN = x.examTypeEN;
                    ex.Duration = x.duration;
                    ex.StartDate = x.startDate;
                    ex.EndDate = x.endDate;
                    
                    semester.Exam.Add(ex);
                }
            }
           
            return semester;
        }

    }
}
