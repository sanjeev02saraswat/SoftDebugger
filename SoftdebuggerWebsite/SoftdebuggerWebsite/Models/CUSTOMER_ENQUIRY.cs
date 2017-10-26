 using SoftdebuggerWebsite.BusinessModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;

namespace SoftdebuggerWebsite.Models
{
    public class CUSTOMER_ENQUIRY
    {

        public void InsertCustomerEnquiry(ContactUsEnquiry objContactUsEnquiry)
        {
            using (SqlConnection con=new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaulWebsite"].ToString()))
            {

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