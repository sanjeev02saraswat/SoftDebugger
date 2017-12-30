using SoftLoggerAPI;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PackageModule.Filters
{
    public class AsyncLogger
    {
        private static object _synRoot = new object();

        public NameValueCollection addMessage { get; set; }

        public bool ExceptionError { get; set; }
        public string FileCollector { get; set; }
        public static void LogMessage(AsyncLogger Logger,string TokenID="")
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
                            strlog.Append(doc.ToString());
                        }
                        catch (XmlException)
                        {
                          
                            foreach (var item in LoggerCollection.AllKeys)
                            {
                                strlog.Append(item.ToString().Replace(" ", "") + "  :  " + Convert.ToString(LoggerCollection["" + item + ""]) + Environment.NewLine);
                            }
                        }
                        if (Logger.ExceptionError)
                        {
                            SendMail.SendMail objSendMail = new SendMail.SendMail();
                            bool status = objSendMail.SendMailtoUser("Sanjeev02Saraswat@Yandex.com", "Exception Error", strlog.ToString(), "", true);
                            if (status)
                            {
                                SoftLogger.WriteLogImmediate("Error Mail Send Successfully", Logger.FileCollector, "Listener");
                            }
                        }
                        SoftLogger.WriteLogImmediate(strlog.ToString(), Logger.FileCollector, "Listener");
                    }
                });

            }

        }
    }
}

