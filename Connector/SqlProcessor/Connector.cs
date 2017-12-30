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
        /// Call this function to Execute stored procedure specific Db that will return Single Value
        /// </summary>
        /// <param name="ConnectionStringName">Pass connection String Name Mention in Configuration</param>
        /// <param name="StoredProcedureName">Pass stored Procedure Name That you have created</param>
        /// <param name="Parameters">Pass List of Params if you have else you can skip</param>
        /// <returns>Single Value if operation will successfull</returns>
        public Object ExecuteScalar(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null)
        {
            DataTable dt = new DataTable();
            SqlConnection objSqlConnection = null;
            try
            {
                _logger.addMessage.Add("ExecuteScalar", "ExecuteScalar Method is goint to Execute");
                SqlContactor objSqlContactor = new SqlContactor();
                objSqlConnection = objSqlContactor.OpenConnection(ConnectionStringName);
                _logger.addMessage.Add("ExecuteScalar", "SqlContactor Open Connection Successfully for " + ConnectionStringName);
                using (SqlCommand objSqlCommand = new SqlCommand(StoredProcedureName, objSqlConnection))
                {
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    if (Parameters != null)
                    {
                        _logger.addMessage.Add("ExecuteScalar", "Parameters is going to Add");
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            if (item.Value != null)
                            {
                                _logger.addMessage.Add("ExecuteScalar", "Parameters Key:" + item.Key + "-Value:" + item.Value.ToString());
                                objSqlCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                            }

                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(objSqlCommand);
                    objSqlConnection.Open();
                    _logger.addMessage.Add("ExecuteScalar", "Connection open Successfully");
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    _logger.addMessage.Add("ExecuteScalar", "Record fetached Successfully Successfully");
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (dt.Rows.Count>0)
                        {
                            return dt.Rows[0][0];
                        }
                    }
                    else { _logger.addMessage.Add("ExecuteScalar", "No Record found against this Login"); }
                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("ExecuteScalar", "SqlContactor Error during Execution " + ex.ToString());
                return null;
            }
            finally
            {
               
                objSqlConnection.Close();
                objSqlConnection.Dispose();
                SoftLogger.WriteLogImmediateAsync(_logger);
            }
            return null;

        }


        /// <summary>
        /// Call this function to Execute stored procedure specific Db that will return datatable
        /// </summary>
        /// <param name="ConnectionStringName">Pass connection String Name Mention in Configuration</param>
        /// <param name="StoredProcedureName">Pass stored Procedure Name That you have created</param>
        /// <param name="Parameters">Pass List of Params if you have else you can skip</param>
        /// <returns>DataTable Raw if operation will successfull</returns>
        public DataTable ExecuteDataTable(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null)
        {
            DataTable dt=new DataTable();
            SqlConnection objSqlConnection = null;
            try
            {
                _logger.addMessage.Add("ExecuteDataTable", "ExecuteDataTable Method is goint to Execute");
                SqlContactor objSqlContactor = new SqlContactor();
                objSqlConnection = objSqlContactor.OpenConnection(ConnectionStringName);
                _logger.addMessage.Add("ExecuteDataTable", "SqlContactor Open Connection Successfully for " + ConnectionStringName);
                using (SqlCommand objSqlCommand = new SqlCommand(StoredProcedureName, objSqlConnection))
                {
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    if (Parameters != null)
                    {
                        _logger.addMessage.Add("ExecuteDataTable", "Parameters is going to Add");
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            if (item.Value != null)
                            {
                                _logger.addMessage.Add("ExecuteDataTable", "Parameters Key:" + item.Key + "-Value:" + item.Value.ToString());
                                objSqlCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                            }

                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(objSqlCommand);
                    objSqlConnection.Open();
                    _logger.addMessage.Add("ExecuteDataTable", "Connection open Successfully");
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    _logger.addMessage.Add("ExecuteDataTable", "Record fetached Successfully Successfully");
                    if (ds.Tables.Count>0)
                    {
                        dt = ds.Tables[0];
                    }else { _logger.addMessage.Add("ExecuteDataTable", "No Record found against this Login"); }
                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("ExecuteDataTable", "SqlContactor Error during Execution " + ex.ToString());
                return dt;
            }
            finally
            {
                SoftLogger.WriteLogImmediateAsync(_logger);
                objSqlConnection.Close();
                objSqlConnection.Dispose();
            }
            return dt;

        }


        /// <summary>
        /// Call this function to Execute stored procedure specific Db that will return DataSet
        /// </summary>
        /// <param name="ConnectionStringName">Pass connection String Name Mention in Configuration</param>
        /// <param name="StoredProcedureName">Pass stored Procedure Name That you have created</param>
        /// <param name="Parameters">Pass List of Params if you have else you can skip</param>
        /// <returns>DataSet  if operation will successfull</returns>
        public DataSet ExecuteDataSet(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null)
        {
            DataSet ds = new DataSet();
            SqlConnection objSqlConnection = null;
            try
            {
                _logger.addMessage.Add("ExecuteDataSet", "ExecuteDataSet Method is goint to Execute");
                SqlContactor objSqlContactor = new SqlContactor();
                objSqlConnection = objSqlContactor.OpenConnection(ConnectionStringName);
                _logger.addMessage.Add("ExecuteDataSet", "SqlContactor Open Connection Successfully for " + ConnectionStringName);
                using (SqlCommand objSqlCommand = new SqlCommand(StoredProcedureName, objSqlConnection))
                {
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    if (Parameters != null)
                    {
                        _logger.addMessage.Add("ExecuteDataSet", "Parameters is going to Add");
                        foreach (KeyValuePair<string, object> item in Parameters)
                        {
                            if (item.Value != null)
                            {
                                _logger.addMessage.Add("ExecuteDataSet", "Parameters Key:" + item.Key + "-Value:" + item.Value.ToString());
                                objSqlCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                            }

                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(objSqlCommand);
                    objSqlConnection.Open();
                    _logger.addMessage.Add("ExecuteDataSet", "Connection open Successfully");
                   
                    da.Fill(ds);
                    if (ds.Tables.Count>0)
                    {
                        _logger.addMessage.Add("ExecuteDataSet", "Record fetached Successfully Successfully");
                    }
                    
                    else { _logger.addMessage.Add("ExecuteDataSet", "No Record found against this Login"); }
                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("ExecuteDataSet", "SqlContactor Error during Execution " + ex.ToString());
                
            }
            finally
            {
                SoftLogger.WriteLogImmediateAsync(_logger);
                objSqlConnection.Close();
                objSqlConnection.Dispose();
            }
            return ds;

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
                            if (item.Value!=null)
                            {
                                _logger.addMessage.Add("ExecuteNonQuery", "Parameters Key:" + item.Key + "-Value:" + item.Value.ToString());
                                objSqlCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
                            }
                           
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
