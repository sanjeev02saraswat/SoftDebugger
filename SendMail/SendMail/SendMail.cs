using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using SoftLoggerAPI;

namespace SendMail
{
    public class SendMail
    {
        const string AssemblyName = "SendMail";
        public SqlConnection Softdebugger { get; private set; }

        /// <summary>
        /// This Function will called which fetch your Email Subject and body from DB
        /// Written By:Amit Pratap Singh
        /// written Date:28-OCT-2017
        /// </summary>
        /// <param name="mailto">Send Email To</param>
        /// <param name="mailtype">Mail Template Name</param>
        /// <returns>Mail Send Successfully or Not Boolean</returns>
        public bool SendMailtoUser(string mailto, string mailtype,string CCAddress="", bool bodyhtml=true)
        {

            string frommail = "", DisplayName=string.Empty;
            string mailsubject = "";
            string mailbody = "";
            string smtp_user = "";
            string smtp_password = "";
            string App_name = "Softdebugger";
            string mail_type = "Softdebugger";
            string smtp_server = "";
            int smtpport=0;
            bool isactive = false;
            bool TLS_SSL = false;
            mailtype = "ENQUIRY";
            string BCCAddress = "";

            //This contains the sender,retriever,subject and the body of the mail component
            try
            {
                DataSet ds = null;
                using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                {
                    using (SqlCommand scmd = new SqlCommand("GET_SMTPDETAILS",scon))
                    {
                        scmd.CommandType = CommandType.StoredProcedure;
                        scmd.Parameters.AddWithValue("@Application_Name", App_name);
                        scmd.Parameters.AddWithValue("@Mail_Type", mail_type);
                        SqlDataAdapter da = new SqlDataAdapter(scmd);
                        ds = new DataSet();
                        da.Fill(ds);

                    }
                }

                //after getting data check for credential

                if (ds!=null && ds.Tables.Count>0)
                {
                    frommail = ds.Tables[0].Rows[0]["mail_from"].ToString();
                    smtp_user = ds.Tables[0].Rows[0]["smtp_user"].ToString();
                    smtp_password = ds.Tables[0].Rows[0]["smtp_password"].ToString();
                    smtp_server = ds.Tables[0].Rows[0]["smtp_server"].ToString();
                    smtpport = Convert.ToInt32(ds.Tables[0].Rows[0]["smtp_port"]);
                    TLS_SSL = Convert.ToBoolean(ds.Tables[0].Rows[0]["SSL_TLS"]);
                    isactive = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"]);
                    DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                }
                else
                {

                    //log no ecord found for smtp
                }

                using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                {
                    using (SqlCommand scmd = new SqlCommand("GetMailTeplate", scon))
                    {
                        scmd.CommandType = CommandType.StoredProcedure;
                        scmd.Parameters.AddWithValue("@MailType", mailtype);
                        scmd.Parameters.AddWithValue("@ApplicationName", App_name);
                        SqlDataAdapter da = new SqlDataAdapter(scmd);
                        ds = new DataSet();
                        da.Fill(ds);

                    }
                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    mailbody = ds.Tables[0].Rows[0]["MAILBODY"].ToString();
                    mailsubject = ds.Tables[0].Rows[0]["MAILSUBJECT"].ToString();
                    
                    
                }
                else
                {

                    //log no ecord found for smtp
                }

                if (isactive==true)
                {

                    MailAddress FromAddress = new MailAddress(frommail, DisplayName);
                    MailAddress ToAddress = new MailAddress(mailto);

                    MailMessage objmsg = new MailMessage(FromAddress, ToAddress);
                    objmsg.Subject = mailsubject;
                    objmsg.Body = mailbody;
                    objmsg.IsBodyHtml = bodyhtml;
if(System.Configuration.ConfigurationSettings.AppSettings.AllKeys.Contains("BCCEMAILADDRESS")){
BCCAddress = System.Configuration.ConfigurationManager.AppSettings["BCCEMAILADDRESS"].ToString();}
                        if (!string.IsNullOrEmpty(CCAddress))
                        {
                            string[] CCId = CCAddress.Split(';');

                            foreach (string CCEmail in CCId)
                            {

                                objmsg.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            }


                        }
                    if (!string.IsNullOrEmpty(BCCAddress))
                    {
                        string[] BCCId = BCCAddress.Split(';');

                        foreach (string BCCEmail in BCCId)
                        {

                            objmsg.Bcc.Add(new MailAddress(BCCEmail)); //Adding Multiple BCC email Id
                        }


                    }


                    //This part contains the smtp server details
                    SmtpClient Client_Server_Name = new SmtpClient(smtp_server);

                    //this part contains the port number of server
                    Client_Server_Name.Port = smtpport;

                    //this part contains the smtp login credentials
                    Client_Server_Name.Credentials = new System.Net.NetworkCredential(smtp_user, smtp_password);

                    //check tls/ssl value
                    Client_Server_Name.EnableSsl = TLS_SSL;

                    Client_Server_Name.Send(objmsg);
                    SoftLogger.WriteLogImmediate("Mail Status : "+"Mail Type :"+mailsubject+" ,Mail Sent Successfully to : "+mailto+", CC TO :"+CCAddress+ ", BCC TO :"+BCCAddress, "SendMail", AssemblyName);
                }
                else
                {
                    SoftLogger.WriteLogImmediate("  //SMTP DETAILS IS NOT ACTIVE YET !!", "SendMail", AssemblyName);
                }
                
            }
            catch (Exception ex)
            {
                SoftLogger.WriteLogImmediate(ex.ToString(), "SendMail", AssemblyName);
                return false;
            }
            return true;
        }


        /// <summary>
        /// This Function will call when you have already mail body and subject
        /// </summary>
        /// <param name="mailto">Send Email To</param>

        /// <param name="mailsubject">send Mail Subject</param>
        /// <param name="mailbody">Send Mail Body</param>
        /// <returns>Mail Send Successfully or Not Boolean</returns>
        public bool SendMailtoUser(string mailto, string  mailsubject,string mailbody,string CCAddress="", bool bodyhtml = true)
        {

            string frommail = "", DisplayName="SoftDebugger Team";            
            string smtp_user = "";
            string smtp_password = "";
            string App_name = "Softdebugger";
            string mail_type = "";
            string smtp_server = "";
            int smtpport = 0;
            bool isactive = false;
            bool TLS_SSL = false;

            //This contains the sender,retriever,subject and the body of the mail component
            try
            {
                DataSet ds = null;
                using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                {
                    using (SqlCommand scmd = new SqlCommand("GET_SMTPDETAILS", scon))
                    {
                        scmd.CommandType = CommandType.StoredProcedure;
                        scmd.Parameters.AddWithValue("@Application_Name", App_name);
                        scmd.Parameters.AddWithValue("@Mail_Type", mail_type);
                        SqlDataAdapter da = new SqlDataAdapter(scmd);
                        ds = new DataSet();
                        da.Fill(ds);

                    }
                }

                //after getting data check for credential

                if (ds != null && ds.Tables.Count > 0)
                {
                    frommail = ds.Tables[0].Rows[0]["mail_from"].ToString();
                    smtp_user = ds.Tables[0].Rows[0]["smtp_user"].ToString();
                    smtp_password = ds.Tables[0].Rows[0]["smtp_password"].ToString();
                    smtp_server = ds.Tables[0].Rows[0]["smtp_server"].ToString();
                    smtpport = Convert.ToInt32(ds.Tables[0].Rows[0]["smtp_port"]);
                    TLS_SSL = Convert.ToBoolean(ds.Tables[0].Rows[0]["SSL_TLS"]);
                    isactive = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"]);
                    DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();

                }
                else
                {

                    //log no ecord found for smtp
                }

                if (isactive == true)
                {

                    MailAddress FromAddress = new MailAddress(frommail, DisplayName);
                    MailAddress ToAddress = new MailAddress(mailto);
                    
                    MailMessage objmsg = new MailMessage(FromAddress, ToAddress);
                    objmsg.Subject = mailsubject;
                    objmsg.Body = mailbody;
                    objmsg.IsBodyHtml = bodyhtml;
                    if (!string.IsNullOrEmpty(CCAddress))
                    {
                        string[] CCId = CCAddress.Split(';');

                        foreach (string CCEmail in CCId)
                        {
                            objmsg.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                        }
                       
                       
                    }
                   
                    //This part contains the smtp server details
                    SmtpClient Client_Server_Name = new SmtpClient(smtp_server);

                    //this part contains the port number of server
                    Client_Server_Name.Port = smtpport;

                    //this part contains the smtp login credentials
                    Client_Server_Name.Credentials = new System.Net.NetworkCredential(smtp_user, smtp_password);

                    //check tls/ssl value
                    Client_Server_Name.EnableSsl = TLS_SSL;

                    Client_Server_Name.Send(objmsg);
                    SoftLogger.WriteLogImmediate("Mail Sent Successfully", "SendMail", AssemblyName);
                }
                else
                {
                    SoftLogger.WriteLogImmediate("  //SMTP DETAILS IS NOT ACTIVE YET !!", "SendMail", AssemblyName);
                }
            

            }
            catch (Exception ex)
            {
                SoftLogger.WriteLogImmediate(ex.ToString(), "SendMail", AssemblyName);

                return false;
            }
            return true;
        }

    }
}
