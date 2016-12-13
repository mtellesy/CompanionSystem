using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class SemesterS
    {
        
        public static async Task<StatusWithObject<Semester>> getCurrentSemester()
        {
            Semester semester = new Semester();
            String path = "/term";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();
            Status status = new Status();
            Semester result = new Semester();
            int code;

            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    SemesterObject semesterResult = JsonConvert.DeserializeObject<SemesterObject>(jsonString);
         
                    result= convertToSemester(semesterResult);
                    status.message = "Course current semester retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    result = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = result;
            return returnedValue;

        }
        // not yet done
        public static List<Schedule> getUserSchedule()
        {
            List<Schedule> schedule = new List<Schedule>();
            String path = "/schedule";
            return schedule;
            // calls for the same path as get courses schedule but omly courses the user enrolled in 
        }


        public static async Task<StatusWithObject<Semester>> getSemesterSchedule()
        {
            String path = "/term/schedule";            
            Semester semester = new Semester();
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Semester> returnedValue = new StatusWithObject<Semester>();
            Status status = new Status();
            Semester result = new Semester();
            int code;
                       
            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    SemesterObject semesterResult = JsonConvert.DeserializeObject<SemesterObject>(jsonString);
         
                    result= convertToSemester(semesterResult);
                    status.message = "Term schedule retrieved successfully";
                    status.status = true;
                    break;
                   
                default:
                    result = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = result;
            return returnedValue;
        }

        public static async Task<StatusWithObject<List<Course>>> getCoursesTimetable()
        {
            List<Course> courses = new List<Course>();
            String path = "/schedule";
            Schedule schedules = new Schedule();
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Course>> returnedValue = new StatusWithObject<List<Course>>();
            Status status = new Status();
            Course temp = new Course();
            int code;

            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(path, null, requestType);
            jsonString = req.statusObject;
            code = req.statusCode;

            if (req.status.status == false)
            {
                returnedValue.status = req.status;
                returnedValue.statusCode = req.statusCode;
                returnedValue.statusObject = null;
                return returnedValue;
            }
            switch (code)
            {
                case 200:
                    List<CourseObject> courseResult = JsonConvert.DeserializeObject<List<CourseObject>>(jsonString);
                    foreach( CourseObject x in courseResult)
                    {
                        temp = convertToCourse(x);
                        courses.Add(temp);
                    }
                    status.message = "Courses retrieved successfully ";
                    status.status = true;
                    break;

                default:
                    courses = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = courses;
            return returnedValue;
        }

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
            if (sem.exam != null) {
                foreach(ExamsObject x in sem.exam)
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

        public static Course convertToCourse(CourseObject cou)
        {
            Course course = new Course();
            Schedule ex = new Schedule();
            course.Cou_id = cou.courseID;
            course.Cou_nameAR = cou.groupNameAR;
            course.Cou_nameEN = cou.groupNameEN;
            course.Cou_credits = cou.credit;
            course.Ter_id = cou.semester;
            if (cou.schedule != null)
            {
                foreach (ScheduleObject x in cou.schedule)
                {
                    ex.Tea_id = x.lecturerID;
                    ex.Gro_id = x.groupID;
                    ex.Gro_NameAR = x.groupNameAR;
                    ex.Gro_NameEN = x.groupNameEN;
                    ex.ClassDuration = x.timeDuration;
                    ex.ClassRoomAR = x.classRoomAR;
                    ex.ClassRoomEN = x.classRoomEN;
                    ex.ClassRoomID = x.classRoomID;
                    ex.ClassStart = x.timeStart;
                    ex.ClassTimeID = x.classTimeID;
                    ex.DayID = x.dayID;
                    ex.DayAR = x.dayAR;
                    ex.DayEN = x.dayEN;
                    course.Schedule.Add(ex);

                }
            }
            return course;
            
        }
    }
}
