using ConnectorAPI.SqlProcessor;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorAPI
{
  public  class Connector : IConnector
    {
        private SoftLogger _logger = null;
        public Connector()
        {
            _logger = new SoftLogger();
            _logger.FileCollector = "Connector.SqlProcessor.Connector";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();


        }

        /// <summary>
        /// Call this function to Insert Data into specific Db
        /// </summary>
        /// <param name="ConnectionStringName">Pass connection String Name Mention in Configuration</param>
        /// <param name="StoredProcedureName">Pass stored Procedure Name That you have created</param>
        /// <param name="Parameters">Pass List of Params if you have else you can skip</param>
        /// <returns>True if operation will successfull</returns>
        public bool ExecuteNonQuery(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null)
        {
            SqlConnection objSqlConnection = null;
            try
            {
                _logger.addMessage.Add("ExecuteNonQuery", "ExecuteNonQuery Method is goint to Execute");
                SqlContactor objSqlContactor = new SqlContactor();
                 objSqlConnection= objSqlContactor.OpenConnection(ConnectionStringName);
                _logger.addMessage.Add("ExecuteNonQuery", "SqlContactor Open Connection Successfully for "+ConnectionStringName);
                using (SqlCommand objSqlCommand=new SqlCommand(StoredProcedureName, objSqlConnection))
                {
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    if (Parameters!=null)
                    {
                        _logger.addMessage.Add("ExecuteNonQuery", "Parameters is going to Add");
                        foreach (KeyValuePair<string,object> item in Parameters)
                        {
                            _logger.addMessage.Add("ExecuteNonQuery", "Parameters Key:"+item.Key+"-Value:"+item.Value.ToString());
                            objSqlCommand.Parameters.AddWithValue("@"+item.Key,item.Value);
                        }
                    }
                    objSqlConnection.Open();
                    _logger.addMessage.Add("ExecuteNonQuery", "Connection open Successfully");
                    objSqlCommand.ExecuteNonQuery();
                    _logger.addMessage.Add("ExecuteNonQuery", "Record Insetered Successfully");
                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("ExecuteNonQuery", "SqlContactor Error during Execution " + ex.ToString());
                return false;
            }
            finally
            {
                SoftLogger.WriteLogImmediateAsync(_logger);
                objSqlConnection.Close();
                objSqlConnection.Dispose();
            }
            return true;
        }
    }
}
