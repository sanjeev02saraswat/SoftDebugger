using SoftLoggerAPI;
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

        public string FileCollector { get; set; }
        public static void LogMessage(AsyncLogger Logger,string TokenID="")
        {
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
                            var i = 0;
                            // JSon or other non-xml format
                            foreach (var item in LoggerCollection.AllKeys)
                            {
                                strlog.Append(item.ToString().Replace(" ", "") + ":" + LoggerCollection["" + item + ""].ToString());
                            }
                        }
                        SoftLogger.WriteLogImmediate(strlog.ToString(), Logger.FileCollector, "Listener");
                    }
                });

            }

        }
    }
}

