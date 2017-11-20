using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}
