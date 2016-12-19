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
        //              done
        //              *** returns a list of not seen announcemnts ***
        public static async Task<StatusWithObject<List<Announcements>>> getLatestAnnouncements(String state)
        {
            //      declaration of path and request type
            String path = "/posts";
            String requestType = "GET";
            path += "/announcement?";
            if (state != null)
            {
                path += String.Format("state={0}&", state);
            }
            path += String.Format("token={0}", AuthenticatorS.token);
                        
            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            List<Announcements> announcements = new List<Announcements>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Announcements>> auth = new StatusWithObject<List<Announcements>>();
            auth = await AuthenticatorS.autoAuthentication<List<Announcements>>();
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
                    List<AnnouncementsObject> messagesResult = JsonConvert.DeserializeObject<List<AnnouncementsObject>>(jsonString);
                    foreach (AnnouncementsObject x in messagesResult)
                    {                        
                        announcements.Add(AnnouncementsObject.convertToAnnouncement(x));
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

        //              *** returns a list of defined number of announcements***
        public static async Task<StatusWithObject<List<Announcements>>> getAnnouncements(int display, int start, bool sent, String privacy)
        {
            //      declaration of path and request type
            String path = "/posts";            
            path += "/announcement";
            if (sent != false)
            {
                path += String.Format("/sent");

            }
            path += "?";
            if (display != 0)
            {
                path += String.Format("display={0}&", display);
            }
            if (start != 0)
            {
                path += String.Format("start={0}&", start);
            }
            
            if (privacy != null)
            {
                path += String.Format("privacy={0}&", privacy);
            }
            path += String.Format("token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<List<Announcements>> returnedValue = new StatusWithObject<List<Announcements>>();
            List<Announcements> announcements = new List<Announcements>();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<List<Announcements>> auth = new StatusWithObject<List<Announcements>>();
            auth = await AuthenticatorS.autoAuthentication<List<Announcements>>();
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
                    List<AnnouncementsObject> announcementsResult = JsonConvert.DeserializeObject<List<AnnouncementsObject>>(jsonString);
                    foreach (AnnouncementsObject x in announcementsResult)
                    {
                        announcements.Add(AnnouncementsObject.convertToAnnouncement(x));
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

        //              *** returns certain announcement details***
        public static async Task<StatusWithObject<Announcements>> getAnnouncement(int ano_id)
        {
            //      declaration of path and request type
            String path = "/posts";
            path += "/announcement/";
            path+=  Convert.ToString(ano_id)+"?";
            path = path + String.Format("token={0}", AuthenticatorS.token);
            String requestType = "GET";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            String jsonString;

            //      decleration of the returned value and its contents
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();
            Announcements announcement = new Announcements();
            Status status = new Status();
            int code;

            //      authentication  part
            StatusWithObject<Announcements> auth = new StatusWithObject<Announcements>();
            auth = await AuthenticatorS.autoAuthentication<Announcements>();
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

        //              *** sends an announcement, returns its status**
        public static async Task<StatusWithObject<Announcements>> sendAnnouncement(Announcements announcement)
        {
            //      declaration of path and request type
            String path = "/posts";
            //path += "/announcement/sent";
            path = path + String.Format("?token={0}", AuthenticatorS.token);
            String requestType = "POST";

            //      decleration of the status with its object that will be returned from send request method
            StatusWithObject<String> req = new StatusWithObject<String>();
            AnnouncementsObject x = AnnouncementsObject.convertToAnnouncementObject(announcement);
            String jsonString;
            jsonString = JsonConvert.SerializeObject(x);

            //      decleration of the returned value and its contents
            StatusWithObject<Announcements> returnedValue = new StatusWithObject<Announcements>();
            Announcements announcementResult = new Announcements();
            Status status = new Status();
            int code;

            //      authentication part
            StatusWithObject<Announcements> auth = new StatusWithObject<Announcements>();
            auth = await AuthenticatorS.autoAuthentication<Announcements>();
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
