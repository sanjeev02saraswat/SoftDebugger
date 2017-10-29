 using SoftdebuggerWebsite.BusinessModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;
using SendMail;
using SoftLogger;

namespace SoftdebuggerWebsite.Models
{
    public class CUSTOMER_ENQUIRY
    {
        const string AssemblyName = "SoftDebuggerWebsite";
        public void InsertCustomerEnquiry(ContactUsEnquiry objContactUsEnquiry)
        {
            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["DBReady"].ToString()))
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                    {
                        using (SqlCommand sqlcmd = new SqlCommand("FSP_INSERTCONTACTDETAILS", con))
                        {
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@QUERYTYPE", objContactUsEnquiry.QueryType);
                            sqlcmd.Parameters.AddWithValue("@ENQUIRY", objContactUsEnquiry.CustomerMessage);

                            sqlcmd.Parameters.AddWithValue("@NAME", objContactUsEnquiry.CustomerName);

                            sqlcmd.Parameters.AddWithValue("@MOBILE", objContactUsEnquiry.CustomerMobile);

                            sqlcmd.Parameters.AddWithValue("@EMAIL", objContactUsEnquiry.Email);

                            //sqlcmd.Parameters.AddWithValue("@MOBILE", objContactUsEnquiry.CustomerMobile);
                            con.Open();
                            sqlcmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    DataSet ds = null;
                    using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                    {
                        using (SqlCommand scmd = new SqlCommand("GetMailTeplate", scon))
                        {
                            scmd.CommandType = CommandType.StoredProcedure;
                            scmd.Parameters.AddWithValue("@ApplicationName", "SoftDebugger");
                            scmd.Parameters.AddWithValue("@MailType", "Contact");
                            SqlDataAdapter da = new SqlDataAdapter(scmd);
                            ds = new DataSet();
                            da.Fill(ds);

                        }
                    }
                    string MailSubject = string.Empty;
                    string MailBody = string.Empty;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        MailSubject = ds.Tables[0].Rows[0]["MAILSUBJECT"].ToString();
                        MailBody = ds.Tables[0].Rows[0]["MAILBODY"].ToString();
                       
                    }
                    else
                    {
                        SoftLogger.SoftLogger.WriteLogImmediate("No Template Found", "Customer Enquiry", AssemblyName);
                        //log no ecord found for smtp
                    }
                    SendMail.SendMail objSendMail = new SendMail.SendMail();
                        bool status = objSendMail.SendMailtoUser(objContactUsEnquiry.Email, MailSubject,MailBody,"",true);
                        if (status)
                        {
                            SoftLogger.SoftLogger.WriteLogImmediate("Mail Send Successfully", "Customer Enquiry", AssemblyName);
                        }

                    
                }
                catch (Exception ex)
                {
                    SoftLogger.SoftLogger.WriteLogImmediate("Error During Insert Customer Enquiry:"+ex.ToString(), "Customer Enquiry", AssemblyName);
                }
            }


        }

        public void SaveCustomerEnquiryDB()
        {

        }

        public void SendEmailToCustomer()
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("Developer.Quadlabs@gmail.com", "Krish001,@");

            MailMessage mm = new MailMessage("Developer.Quadlabs@gmail.com", "Sanjeev02Saraswat@Yandex.com", "test", "test");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}