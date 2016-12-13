﻿using CScore.BCL;
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
        public List<ExamsObject> exam { set; get; }

        public static Semester convertToSemester(SemesterObject sem)
        {
            Semester semester = new Semester();
            Exams ex = new Exams();
            semester.Ter_id = sem.termID;
            semester.Ter_nameAR = sem.nameAR;
            semester.Ter_nameEN = sem.nameEN;
            semester.Ter_start = sem.termStart;
            semester.Ter_end = sem.termEnd;
            semester.Year = sem.year;
            if (sem.exam != null)
            {
                foreach (ExamsObject x in sem.exam)
                {
                    ex.ExamTypeAR = x.examTypeAR;
                    ex.ExamTypeEN = x.examTypeEN;
                    ex.Duration = x.duration;
                    ex.StartDate = x.startDate;
                    ex.EndDate = x.endDate;
                    semester.Exam.Add(ex);
                }
            }
            semester.Ter_enrollment = null;
            semester.Ter_dropCourses = null;
            semester.Ter_lastStudyDate = null;
            return semester;
        }

    }
}
