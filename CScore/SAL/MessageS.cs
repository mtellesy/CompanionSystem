using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
    public static class MessageS
    {
        //              done
        //              *** returns a list of not seen messages ***
        public static async Task<StatusWithObject<List<Messages>>> getLatestMessages(String state)
        {
            //      declaration of path and request type
            String path = "/messages?";
            path = path + String.Format("state={0}&", state);
            path = path + String.Format("token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Messages>> returnedValue = new StatusWithObject<List<Messages>>();
            List<Messages> messages = new List<Messages>();
            Status status = new Status();  
            int code;

            //      authentication part
            StatusWithObject<List<Messages>> auth = new StatusWithObject<List<Messages>>();
            auth = await AuthenticatorS.autoAuthentication<List<Messages>>();
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
                    List<MessagesObject> messagesResult = JsonConvert.DeserializeObject<List<MessagesObject>>(jsonString);
                    foreach (MessagesObject x in messagesResult)
                    {                 
                        messages.Add(MessagesObject.convertToMessage(x));
                    }
                    status.message = "Messages retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    messages = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;
                    
            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = messages;
            return returnedValue;
        }

        //              *** returns a list of defined number of messages***
        public static async Task<StatusWithObject<List<Messages>>>  getMessages(int display,int start)
        {

            //      declaration of path and request type
            String path = "/messages.php?";
            /* Remove this for the real test
            String path = "/messages?";
            path = path + String.Format("display={0}&", display);
            path = path + String.Format("start={0}&", start);
            */
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Messages>> returnedValue = new StatusWithObject<List<Messages>>();
            List<Messages> messages = new List<Messages>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Messages>> auth = new StatusWithObject<List<Messages>>();
            auth = await AuthenticatorS.autoAuthentication<List<Messages>>();
            if (auth.status.status == false)
            {
                return auth;
            }
            path = path + String.Format("token={0}", AuthenticatorS.token);
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
                    List<MessagesObject> messagesResult = JsonConvert.DeserializeObject<List<MessagesObject>>(jsonString);
                    Messages temp = new Messages();
                    foreach (MessagesObject x in messagesResult)
                    {                      
                        messages.Add(MessagesObject.convertToMessage(x));
                    }
                    status.message = "Messages retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    messages = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = messages;
            return returnedValue;
        }

        //              *** returns certain message details***
        public static async Task<StatusWithObject<Messages>> getMessage(int mes_id)
        {
            //      declaration of path and request type
            String path = "/message/"+mes_id;
            path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Messages> returnedValue = new StatusWithObject<Messages>();
            Messages message = new Messages();
            Status status = new Status();
            int code;

            //      authentication  part
            StatusWithObject<Messages> auth = new StatusWithObject<Messages>();
            auth = await AuthenticatorS.autoAuthentication<Messages>();
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
                    MessagesObject messagesResult = JsonConvert.DeserializeObject<MessagesObject>(jsonString);
                     message = MessagesObject.convertToMessage(messagesResult);
                    status.message = "Message retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    message = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = message;
            return returnedValue;
        }

        //              *** sends a message, returns its status**
        public static async Task<StatusWithObject<Messages>> sendMessage(Messages message)
        {
            //      declaration of path and request type
            //String path = "/messages"; # the real endpoint
            String path = "/messages/get.php";//for testing only
            path = path + String.Format("?token={0}", AuthenticatorS.token);
            path = path + String.Format("&userid={0}", User.use_id); //for testing only
            String requestType = "POST";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            MessagesObject x =  MessagesObject.convertToMessagesObject(message);
            String jsonString;
            jsonString = JsonConvert.SerializeObject(x);

            //      decleration of the returned value and its contents
            StatusWithObject<Messages>returnedValue = new StatusWithObject<Messages>();
            Messages messageResult = new Messages();
            Status resultStatus = new Status();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<Messages>auth = new StatusWithObject<Messages>();
            auth = await AuthenticatorS.autoAuthentication<Messages>();
            if (auth.status.status == false)
            {
                return auth;
            }

            //      data retrieval  part
            req = await AuthenticatorS.sendRequest(path, jsonString, requestType);
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
                case 201:
                    status.message = "Message sent successfully. .";
                    status.status = true;
                    MessagesObject res = JsonConvert.DeserializeObject<MessagesObject>(jsonString);
                    messageResult = MessagesObject.convertToMessage(res);                    
                    returnedValue.statusObject = messageResult;
                    break;
              
                default:
                    resultStatus = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    returnedValue.statusObject = null;
                    break;

            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            return returnedValue;

        }

    }
}
