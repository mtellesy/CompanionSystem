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
  public static class ResultS
    {
        //              done
        //              *** returns a list of semester results ***
        public static async  Task<StatusWithObject<List<Result>>> getSemesterResult()
        {
            //      declaration of path and request type
            String path = "/results";
            path+= String.Format("?token={0}",AuthenticatorS.token);
            String requestType = "GET";
            
            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Result>> returnedValue =  new StatusWithObject<List<Result>>();
            List<Result> results = new List<Result>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Result>> auth = new StatusWithObject<List<Result>>();
            auth = await AuthenticatorS.autoAuthentication<List<Result>>();
            if (auth.status.status == false)
            {
                return auth;
            }

            //      data retrieval  part
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
                    List<ResultsObject> results1 = JsonConvert.DeserializeObject<List<ResultsObject>>(jsonString);
                    foreach(ResultsObject x in results1)
                    {
                        results.Add(ResultsObject.convertToResult(x));
                    }
                    status.message = "Semester results returned";
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

        //              *** returns a list of all results ***
        public static async Task<StatusWithObject<List<AllResult>>> getAllResult(String ter_id)
        {
            String path = "/result/" + User.use_id + "/transcript";
            if (ter_id != null)
            {
                path += "?term_id={0}"+ Convert.ToString(ter_id);

            }
            path += String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<AllResult>> returnedValue = new StatusWithObject<List<AllResult>>();
            List<AllResult> results = new List<AllResult>();
            Status status = new Status();
            int code;
                        
            //      authentication part
            StatusWithObject<List<AllResult>> auth = new StatusWithObject<List<AllResult>>();
            auth = await AuthenticatorS.autoAuthentication<List<AllResult>>();
            if (auth.status.status == false)
            {
                return auth;
            }
            //      data retrieval  part
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
                    List<GradeObject> results1 = JsonConvert.DeserializeObject<List<GradeObject>>(jsonString);
                    foreach (GradeObject x in results1)
                    {
                        results.Add(ResultsObject.convertToAllResult(x));
                    }
                    status.message = "Transcript returned";
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
        
        
    }
}
