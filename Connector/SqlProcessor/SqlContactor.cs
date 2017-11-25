using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorAPI.SqlProcessor
{
    class SqlContactor
    {
        private SoftLogger _logger = null;

        public SqlContactor()
        {
            _logger = new SoftLogger();
            _logger.FileCollector = "Connector.SqlProcessor.SqlContactor";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();

        }
        internal SqlConnection OpenConnection(string connectionStringName)
        {
            SqlConnection objCon = null;
            try
            {
                _logger.addMessage.Add("OpenConnection", "OpenConnection Method is goint to Execute");

                 objCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ToString());
                _logger.addMessage.Add("OpenConnection", "Sql Connection Open Successfully Against"+connectionStringName);

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("OpenConnection", "Sql Connection Error  Against" + connectionStringName + "Error:-" + ex.ToString());
                return null;
            }
            finally
            {
                SoftLogger.WriteLogImmediateAsync(_logger);
            }
            return objCon;
        }
    }
}
