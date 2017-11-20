using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEBAPI2.Models
{
    public class SignUpUserModel
    {
        private AsyncLogger _logger = null;
        public SignUpUserModel()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "SignUpUserModels";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        public bool Registeruser(Signupuser objSignupuser)
        {
            bool signupstatus = true;
            try
            {
                _logger.addMessage.Add("Registeruser", "Registeruser Method is goint to Execute");
                using (SqlConnection con = new SqlConnection("Test"))
                {

                }

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("Registeruser", "Error during Register user Method Execution:" + ex.ToString());
                signupstatus = false;
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return signupstatus;
        }
    }
}
