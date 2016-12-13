using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class Semester
    {
        // Current term id must be set from Application layer from the start of the APP
         public static int current_term {get; set;}    
         int ter_id { get; set; }
         String ter_nameAR { get; set; }
         String ter_nameEN { get; set; }
         String year { get; set; }
         String ter_start { get; set; }
         String ter_end { get; set; }
         String ter_lastStudyDate { get; set; }
         String ter_enrollment { get; set; }
         String ter_dropCourses { get; set; }
         List<Exams> exam { set; get; }
        //      current_term

        //     ter_id 
        public int Ter_id
        {
            get
            {
                return ter_id;
            }
            set
            {
                ter_id= value;
            }
        }
        //     ter_nameAR
        public String Ter_nameAR
        {
            get
            {
                return ter_nameAR;
            }
            set
            {
                ter_nameAR = value;
            }
        }
        //     ter_nameEN 
        public String Ter_nameEN
        {
            get
            {
                return ter_nameEN;
            }
            set
            {
                ter_nameEN = value;
            }
        }
        //     year 
        public String Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        //     ter_start 
        public String Ter_start
        {
            get
            {
                return ter_start;
            }
            set
            {
                ter_start = value;
            }
        }
        //     ter_end
        public String Ter_end
        {
            get
            {
                return ter_end;
            }
            set
            {
                ter_end = value;
            }
        }
        //     ter_lastStudyDate
        public String Ter_lastStudyDate
        {
            get
            {
                return ter_lastStudyDate;
            }
            set
            {
                ter_lastStudyDate = value;
            }
        }
        //     ter_enrollment 
        public String Ter_enrollment
        {
            get
            {
                return ter_enrollment;
            }
            set
            {
                ter_enrollment = value;
            }
        }
        //     ter_dropCourses 
        public String Ter_dropCourses
        {
            get
            {
                return ter_dropCourses;
            }
            set
            {
                ter_dropCourses = value;
            }
        }
        //      exams
        public List<Exams> Exam
        {
            get
            {
                return exam;
            }
            set
            {
                exam = value;
            }
        }
    }
}
