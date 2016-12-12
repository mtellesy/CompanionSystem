using CScore.BCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CScore.ResponseObjects;

namespace CScore.SAL
{
  public class ResultS:Template
    {
        public static async  Task<StatusWithObject<List<Result>>> getSemesterResult()
        {
            //      arguments for the APIs      and send request method
            String Path = "/results" + String.Format("?token={0}",AuthenticatorS.token);
            String requestType = "GET";
            
            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Result>> returnedValue =  new StatusWithObject<List<Result>>();
            List<Result> results = new List<Result>();
            Status status = new Status();
            int code;

            //      use this only if the endpoint tag = security  
            //      decleration of the values tha         
            StatusWithObject<String> auth = new StatusWithObject<String>();
            StatusWithObject<String> log = new StatusWithObject<String>();

            auth = await AuthenticatorS.authenticate();
            code = auth.statusCode;

            if (auth.status.status == false)
            {
                if (code == 401)
                {
                    log = await AuthenticatorS.login(User.use_id, User.password);
                    if (log.status.status == false)
                    {
                        returnedValue.status = log.status;
                        returnedValue.statusCode = log.statusCode;
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                }
                else
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }

            req = await AuthenticatorS.sendRequest(Path, null, requestType);

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
                    List<ResultsObject> results1 = JsonConvert.DeserializeObject<List<ResultsObject>>(jsonString);
                    foreach(ResultsObject x in results1)
                    {
                        results.Add(getMyResult(x));
                    }
                    status.message = "User Profile returned";
                    status.status = true;
                    break;
    
                default:
                    results = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = results;
            return returnedValue;
        }

        public static async Task<StatusWithObject<List<AllResult>>> getAllResult()
        {
            String Path = "/result/" + User.use_id + "/transcript";
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<AllResult>> returnedValue = new StatusWithObject<List<AllResult>>();
            List<AllResult> results = new List<AllResult>();
            Status status = new Status();
            int code;

                //      use this only if the endpoint tag = security  
            //      decleration of the values tha      
               
            //          THE SECURITY TAG  PART .. AUTHENTICATION
            StatusWithObject<String> auth = new StatusWithObject<String>();
            StatusWithObject<String> log = new StatusWithObject<String>();

            auth = await AuthenticatorS.authenticate();
            code = auth.statusCode;

            if (auth.status.status == false)
            {
                if (code == 401)
                {
                    log = await AuthenticatorS.login(User.use_id, User.password);
                    if (log.status.status == false)
                    {
                        returnedValue.status = log.status;
                        returnedValue.statusCode = log.statusCode;
                        returnedValue.statusObject = null;
                        return returnedValue;
                    }
                }
                else if(code !=200)
                {
                    returnedValue.status = auth.status;
                    returnedValue.statusCode = auth.statusCode;
                    returnedValue.statusObject = null;
                    return returnedValue;
                }
            }
            //              THE GETTING DATA PART 
            req = await AuthenticatorS.sendRequest(Path, null, requestType);
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
                    List<GradeObject> results1 = JsonConvert.DeserializeObject<List<GradeObject>>(jsonString);
                    foreach (GradeObject x in results1)
                    {
                        results.Add(getAllMyResult(x));
                    }
                    status.message = "User Profile returned";
                    status.status = true;
                    break;

                default:
                    results = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = results;
            return returnedValue;
        }

        //          CONVERT TO Result
        public static Result getMyResult(ResultsObject Jresult)
        {
            Result result = new Result();
            MidMarkDistribution y = new MidMarkDistribution();
            result.cou_id = Jresult.course_id;
            result.final = Jresult.finalMark;
            int id = 0;
            result.midExams = new List<MidMarkDistribution>();
            foreach (float grade in Jresult.midMark)
            {
                y.cou_id = Jresult.course_id;
                y.mid_nameAR = null;
                y.mid_nameEN = null;
                y.midMarkDistributionID = ++id;
                y.grade = grade;
                result.midExams.Add(y);
            }
            return result;
        }
        //          CONVERTS TO AllResult
        public static AllResult getAllMyResult(GradeObject Jresult)
        {
            AllResult result = new AllResult();
            result.cou_id = Jresult.courseID;
            result.cou_nameAR = Jresult.courseNameAR;
            result.cou_nameEN = Jresult.courseNameEN;
            result.cou_credits = Jresult.credit;
            result.res_total = Jresult.finalMark;
            result.ter_id = Jresult.termID;
            result.ter_nameAR = Jresult.termNameAR;
            result.ter_nameEN = Jresult.termNameEN;
            result.year = Jresult.year;
            
            return result;
        }
    }
}
