﻿using SoftdebuggerWebsite.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Web;

namespace PackageModule.Utility
{
    public class CommonFunction
    {

        /// <summary>
        /// we will npot create object of utility classes
        /// </summary>
        private CommonFunction()
        {

        }
        public static string HITAPI(string jsonRequest, string URL, string RequestMethod)
        {
            string strTemp = "";
            HttpWebRequest lWebRequest;
            byte[] lPostData; string err = "";
            //lWebRequest.Headers.Add("Accept-Encoding", "deflate,gzip");         

            try
            {
                lWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                lWebRequest.Method = RequestMethod;
                lWebRequest.Timeout = 300000;
                lWebRequest.Accept = "application/json, text/javascript";
                lWebRequest.ContentType = "application/json";
                lWebRequest.ConnectionGroupName = Guid.NewGuid().ToString();
                lWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                if (!string.IsNullOrEmpty(jsonRequest) && RequestMethod == "POST")
                {
                    lPostData = new System.Text.ASCIIEncoding().GetBytes(jsonRequest);
                    lWebRequest.ContentLength = lPostData.Length;
                    var reqStream = lWebRequest.GetRequestStream();
                    reqStream.Write(lPostData, 0, lPostData.Length);
                    reqStream.Close();
                }
                using (HttpWebResponse lWebResponse = (HttpWebResponse)lWebRequest.GetResponse())
                {
                    if (lWebResponse.Headers.Get("Content-Encoding") == "gzip")
                    {
                        Stream abc; StreamReader sr1; abc = new GZipStream(lWebResponse.GetResponseStream(), CompressionMode.Decompress, false);
                        sr1 = new System.IO.StreamReader(abc);
                        strTemp = sr1.ReadToEnd();
                    }
                    else
                    {
                        using (StreamReader sr = new StreamReader(lWebResponse.GetResponseStream()))
                        {
                            strTemp = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException rx)
            {
                using (HttpWebResponse rn = (HttpWebResponse)rx.Response)
                {
                    if (rn != null)
                    {
                        using (StreamReader sr = new StreamReader(rn.GetResponseStream()))
                        {
                            err = sr.ReadToEnd();
                        }
                    }
                    return ((HttpWebResponse)rx.Response).StatusDescription + ((HttpWebResponse)rx.Response).StatusCode + err + rx.ToString();
                }
            }
            return strTemp;
        }

        public static string GetFileCulture()
        {
            if (HttpContext.Current.Session["objWrapper"] != null)
            {
                Languages objLanguages = new Languages();
                objLanguages = (Languages)HttpContext.Current.Session["objWrapper"];
                return objLanguages.CultureCode;
            }
            return "en-US";
        }
    }
}
