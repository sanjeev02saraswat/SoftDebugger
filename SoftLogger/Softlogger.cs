using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SoftLoggerAPI
{
  public   class SoftLogger
    {
        private static object _synRoot = new object();

        public  NameValueCollection addMessage { get; set; }

        public bool ExceptionError { get; set; }
        public  string FileCollector { get; set; }

        /// <summary>
        /// It will used to write Async Log
        /// </summary>
        /// <param name="Logger">List of Key value Log Collection  </param>
        public static void WriteLogImmediateAsync(SoftLogger Logger,string Token="")
        {
            if (!Logger.ExceptionError)
            {
                Logger.ExceptionError = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ExceptionErrorMail"]);
            }
            StringBuilder strlog = new StringBuilder();
            NameValueCollection LoggerCollection = null;
            if (Logger != null)
            {
                LoggerCollection = Logger.addMessage;


                Task.Factory.StartNew(() =>
                {
                    lock (_synRoot)
                    {
                        var doc = new XDocument();
                        try
                        {
                            if (LoggerCollection != null)
                            {
                                var i = 0;
                                foreach (var item in LoggerCollection.AllKeys)
                                {
                                    doc.Add(new XElement("ApiLog",
                             new XElement("Request", item.ToString().Replace(" ", "") + "" + i++ + ""),
                             new XElement("Response", XDocument.Parse(LoggerCollection["" + item + ""].ToString()).Root)));
                                }
                            }
                            strlog.Append( doc.ToString());
                        }
                        catch (XmlException)
                        {
                           
                            var i = 0;
                            // JSon or other non-xml format
                            foreach (var item in LoggerCollection.AllKeys)
                            {
                                strlog.Append(item.ToString().Replace(" ", "") +"  :  "+ Convert.ToString(LoggerCollection["" + item + ""]) +Environment.NewLine);                               
                            }
                        }
                        if (Logger.ExceptionError)
                        {
                            SendMail.SendMail objSendMail = new SendMail.SendMail();
                            bool status = objSendMail.SendMailtoUser("Sanjeev02Saraswat@Yandex.com", "Exception Error", strlog.ToString(), "", true);
                            if (status)
                            {                                
                                SoftLogger.WriteLogImmediate("Error Mail Send Successfully", Logger.FileCollector + Token, "Listener");
                            }
                        }
                        SoftLogger.WriteLogImmediate(strlog.ToString(), Logger.FileCollector+ Token, "Listener");
                    }
                });

            }

        }





        /// <summary>
        /// Called for Log Write
        /// </summary>
        /// <param name="logfile">Text String message</param>
        /// <param name="logFileName">Funcation Name</param>
        public static void WriteLogImmediate(string logfile, string logFileName, string AssemblyName)
        {
            string path = string.Empty;
            if (System.Configuration.ConfigurationSettings.AppSettings.AllKeys.Contains("LogPath"))
            {
                 path = System.Configuration.ConfigurationSettings.AppSettings["LogPath"].ToString();
            }
            else
            {
                throw new Exception("Kindly configure LogPath in Web.Config..If it is not there!!!!");
                // Key doesn't exist
            }
         
            
            path = path + DateTime.Now.ToString("MMM-yyyy") + "\\" + AssemblyName + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            path += logFileName + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logfile);
                writer.Close();
            }

        }

    }
}
