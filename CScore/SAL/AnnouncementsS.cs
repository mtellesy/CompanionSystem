using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CScore.BCL;
using CScore.ResponseObjects;
using Newtonsoft.Json;

namespace CScore.SAL
{
    public static class AnnouncementsS
    {
       

        public static async Task<StatusWithObject<List<Announcements>>> getLatestAnnouncements(String state)
        {
            List<Announcements> announcements = new List<Announcements>();
            String path = "/posts/announcements";
            String requestType = "GET";
            path = path + String.Format("?state={0}", state);
            path = path + String.Format("?token={0}", AuthenticatorS.token);




            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            Status status = new Status();

            int code;
            StatusWithObject<List<Announcements>> auth = new StatusWithObject<List<Announcements>>();
            auth = await AuthenticatorS.autoAuthentication<List<Announcements>>();
            if (auth.status.status == false)
            {
                return auth;
            }


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
                    List<AnnouncementsObject> messagesResult = JsonConvert.DeserializeObject<List<AnnouncementsObject>>(jsonString);
                    Announcements temp = new Announcements();
                    foreach (AnnouncementsObject x in messagesResult)
                    {
                        temp = AnnouncementsObject.convertToAnnouncement(x);
                        announcements.Add(temp);
                    }
                    status.message = "Announcements retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    announcements = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;

            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = announcements;
            return returnedValue;
        }

        public static async Task<StatusWithObject<List<Announcements>>> getAnnouncements(int display, int start)
        {
            List<Announcements> announcements = new List<Announcements>();
            String path = "/posts/announcements";
            String requestType = "GET";
            path = path + String.Format("?display={0}", display);
            path = path + String.Format("?start={0}", start);
            path = path + String.Format("?token={0}", AuthenticatorS.token);




            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            Status status = new Status();

            int code;
            StatusWithObject<List<Announcements>> auth = new StatusWithObject<List<Announcements>>();
            auth = await AuthenticatorS.autoAuthentication<List<Announcements>>();
            if (auth.status.status == false)
            {
                return auth;
            }


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
                    List<AnnouncementsObject> announcementsResult = JsonConvert.DeserializeObject<List<AnnouncementsObject>>(jsonString);
                    Announcements temp = new Announcements();
                    foreach (AnnouncementsObject x in announcementsResult)
                    {
                        temp = AnnouncementsObject.convertToAnnouncement(x);
                        announcements.Add(temp);
                    }
                    status.message = "Announcements retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    announcements = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = announcements;
            return returnedValue;
        }

        public static async Task<StatusWithObject<Announcements>> getAnnouncement(int ano_id)
        {
            String path = "/posts/announcements/" + ano_id;
            String requestType = "GET";
            path = path + String.Format("?token={0}", AuthenticatorS.token);

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();
            Status status = new Status();
            Announcements announcement = new Announcements();

            int code;
            StatusWithObject<Announcements> auth = new StatusWithObject<Announcements>();
            auth = await AuthenticatorS.autoAuthentication<Announcements>();
            if (auth.status.status == false)
            {
                return auth;
            }

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
                    AnnouncementsObject announcementResult = JsonConvert.DeserializeObject<AnnouncementsObject>(jsonString);
                    announcement = AnnouncementsObject.convertToAnnouncement(announcementResult);
                    status.message = "Announcement retrieved successfully.";
                    status.status = true;
                    break;

                default:
                    announcement = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    break;


            }
            returnedValue.status = status;
            returnedValue.statusCode = code;
            returnedValue.statusObject = announcement;
            return returnedValue;
        }

        public static async Task<StatusWithObject<Announcements>> sendMessage(Announcements announcement)
        {
            Announcements announcementResult = new Announcements();
            String path = "/posts";
            path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "SET";
            //      arguments for the APIs      and send request method

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            AnnouncementsObject x = new AnnouncementsObject();
            x = AnnouncementsObject.convertToAnnouncementObject(announcement);
            String jsonString;
            jsonString = JsonConvert.SerializeObject(x);

            //      decleration of the returned value and its contents
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();
            Status status = new Status();
            int code;

            //      use this only if the endpoint tag = security  
            //      decleration of the values tha         
            StatusWithObject<Announcements> auth = new StatusWithObject<Announcements>();
            auth = await AuthenticatorS.autoAuthentication<Announcements>();
            if (auth.status.status == false)
            {
                return auth;
            }

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
                    status.message = "Announcement sent successfully. ";
                    status.status = true;
                    AnnouncementsObject res = JsonConvert.DeserializeObject<AnnouncementsObject>(jsonString);
                    announcementResult = AnnouncementsObject.convertToAnnouncement(res);
                    break;

                default:
                    announcementResult = null;
                    status.status = false;
                    status.message = FixedResponses.getResponse(code);
                    returnedValue.statusObject = null;

                    break;


            }
            returnedValue.statusObject = announcementResult;
            returnedValue.status = status;
            returnedValue.statusCode = code;
            return returnedValue;

        }

    }
}
