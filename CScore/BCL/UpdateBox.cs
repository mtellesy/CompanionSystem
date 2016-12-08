using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;



namespace CScore.BCL
{

 
  public class UpdateBox
    {
      
        public static async Task<bool> CheckForInternetConnection()
        {
            try
            {
                HttpClient request = new HttpClient();
                request.Timeout = TimeSpan.FromMilliseconds(11500);
                Uri uri = new Uri("https://www.google.com");
                var response = await request.GetAsync(uri);

                if ((int)response.StatusCode == 200)
                    return true;
                else return false;
            } catch 
            {
                return false;
            }
           


            /*
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.google.com");
                //request.ContinueTimeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response =(HttpWebResponse) await request.GetResponseAsync();

                if (response.StatusCode == HttpStatusCode.OK) return true;
                else return false;
            }
            catch
            {
                return false;
            }
            */
        }
    }

    /*
    private static ManualResetEvent evt = new ManualResetEvent(false);

    public static bool CheckForInternetConnection()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            request.UseDefaultCredentials = true;
            request.BeginGetResponse(new AsyncCallback(FinishRequest), request);
            evt.WaitOne();
            return request.HaveResponse;

        }
        catch
        {
            return false;
        }
    }

    private static void FinishRequest(IAsyncResult result)
    {
        HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
        evt.Set();
    }

    */
}

