using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace RESTHeper
{
    public static class RESTHeper
    {
        public static string Get(string Url)
        {
            try
            {
                HttpWebRequest request;
                request = WebRequest.Create(Url) as HttpWebRequest;
                request.Timeout = 10 * 1000;
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
                else
                    throw new Exception("Error to proccess webservice methode.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Post(string Url, string DataJson)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(DataJson);
                HttpWebRequest request;
                request = WebRequest.Create(Url) as HttpWebRequest;
                request.Timeout = 10 * 1000;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = data.Length;
                Stream postStream = request.GetRequestStream();
                postStream.Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
                else
                    throw new Exception("Error to proccess webservice methode.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
