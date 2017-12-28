using ConnectorAPI;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WEBAPI2.Models
{
    public class TokenManagement
    {
        private AsyncLogger _logger = null;
        public TokenManagement()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Models.TokenManagement";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();

        }
        internal bool ValidateToken(string tokenID)
        {
            bool status = false;
            try
            {
                _logger.addMessage.Add("ValidateToken", "ValidateToken Method is goint to Execute");
                using (SqlConnection con = new SqlConnection("ConnectionString"))
                {
                    _logger.addMessage.Add("ValidateToken", "Connection Open Successfully");
                    using (SqlCommand cmd = new SqlCommand("fsp_ValidateToken", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        _logger.addMessage.Add("ValidateToken", "Command Executed Succussfully for" + tokenID);
                    }

                }
                if (status)
                {
                    _logger.addMessage.Add("ValidateToken", "Login Successfully  for" + tokenID);
                }
                else
                {
                    _logger.addMessage.Add("ValidateToken", "Login Failure  for" + tokenID);
                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("ValidateToken", "Error During Validate Token for Token ID" + tokenID);
                _logger.addMessage.Add("ValidateToken", "Error During Validate Token" + ex.ToString());
            }
            finally
            {
                _logger.addMessage.Add("ValidateToken", "Finish Method Execution for Token Validation");
                AsyncLogger.LogMessage(_logger);
            }
            return status;
        }



        internal bool CreateTokenforAgent(Signupuser objSignupuser,string Tokenid)
        {
            bool LoginStatus = false;
            try
            {
                _logger.addMessage.Add("CreateTokenforAgent", "CreateTokenforAgent Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompnayID", objSignupuser.CompanyID);
                objparamlist.Add("CompnayID", objSignupuser.CompanyID);
                _logger.addMessage.Add("Email", objSignupuser.Email);
                objparamlist.Add("Email", objSignupuser.Email);
                _logger.addMessage.Add("Password", objSignupuser.Password);
                objparamlist.Add("Password", objSignupuser.Password);
                _logger.addMessage.Add("TokenID", Tokenid);
                objparamlist.Add("TokenID", Tokenid);
                DateTime CurrentTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                _logger.addMessage.Add("Token Generated TimeStamp", CurrentTime.ToString());
                objparamlist.Add("TimeStamp", CurrentTime);
                IConnector objConnector = new Connector();
                LoginStatus = Convert.ToBoolean(objConnector.ExecuteScalar("PackageModule", "FSP_Agentlogin", objparamlist));
                _logger.addMessage.Add("CreateTokenforAgent", "CreateTokenforAgent Status is"+LoginStatus);
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("CreateTokenforAgent", "Error during CreateTokenforAgent  Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return LoginStatus;
        }

        public void UpdateTimestamp(string CompanyID,string TokenID, DateTime CurrentTime)
        {
            try
            {
                _logger.addMessage.Add("UpdateTimestamp", "UpdateTimestamp Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("TokenID", TokenID);
                objparamlist.Add("TokenID", TokenID);
                _logger.addMessage.Add("TimeStamp", CurrentTime.ToString());
                objparamlist.Add("TimeStamp", CurrentTime);

                IConnector objConnector = new Connector();
                bool UpdateTokenStatus = objConnector.ExecuteNonQuery("PackageModule", "UPDATE_TIMESTAMP", objparamlist);

                _logger.addMessage.Add("UpdateTokenStatus", "Timestamp Has been updated Successfully for Token ID: "+ TokenID+ " with Timestamp  "+ CurrentTime.ToString());
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("UpdateTimestamp", "Error during UpdateTimestamp  Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
        }
        internal bool VALIDATETokenforAgent(string Tokenid,string CompanyID)
        {
            bool LoginStatus = false;
            try
            {
                int ExpireMinute = 20;
                if (System.Configuration.ConfigurationSettings.AppSettings.AllKeys.Contains("ExpireMinute"))
                {
                    ExpireMinute = Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["ExpireMinute"]);
                }
                

                _logger.addMessage.Add("VALIDATETokenforAgent", "VALIDATETokenforAgent Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("TokenID", Tokenid);
                objparamlist.Add("TokenID", Tokenid);
                _logger.addMessage.Add("ExpireMinute", ExpireMinute.ToString());
                objparamlist.Add("ExpireMinute", ExpireMinute);
              
                IConnector objConnector = new Connector();
                DataTable LoginUserDetail = objConnector.ExecuteDataTable("PackageModule", "ValidateToken", objparamlist);
                if (LoginUserDetail.Rows.Count>0)
                {
                    
                    
                    DateTime CurrentTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    double SessionMinutes= CurrentTime.Subtract(Convert.ToDateTime(LoginUserDetail.Rows[0]["TimeStamp"])).TotalMinutes;
                    _logger.addMessage.Add("SessionMinutes", SessionMinutes.ToString());

                    if (SessionMinutes< ExpireMinute)
                    {
                        UpdateTimestamp(CompanyID, Tokenid, CurrentTime);
                        LoginStatus = true;
                    }

                }else
                {
                    _logger.addMessage.Add("VALIDATETokenforAgent", "VALIDATETokenforAgent return no Login Result..Access Denied");
                }
               
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("CreateTokenforAgent", "Error during CreateTokenforAgent  Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return LoginStatus;
        }

    }
}
