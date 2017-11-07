using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMailTo.Text==""||txtCCMail.Text==""||txtFirstContent.Text==""||txtSecondContent.Text==""||txtcontent3.Text=="")
            {
                MessageBox.Show("Please fill all required details..");
            }
            else
            {
                DataSet ds = null;
                using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                {
                    using (SqlCommand scmd = new SqlCommand("GetMailTeplate", scon))
                    {
                        scmd.CommandType = CommandType.StoredProcedure;
                        scmd.Parameters.AddWithValue("@ApplicationName", "SoftDebugger");
                        scmd.Parameters.AddWithValue("@MailType", "MailSender");
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
                    string updatedMailBody = MailBody.Replace("MailFirst", txtFirstContent.Text).Replace("MailSecound", txtSecondContent.Text).Replace("MailThird", txtcontent3.Text);
                    SendMail.SendMail objSendMail = new SendMail.SendMail();
                    bool status = objSendMail.SendMailtoUser(txtMailTo.Text, MailSubject, updatedMailBody, txtCCMail.Text,true);
                    if (status)
                    {
                        MessageBox.Show("Message sent successfully...");

                    }else { MessageBox.Show("Message could not sent successfully..."); }
                }
                else
                {
                   // SoftLogger.SoftLogger.WriteLogImmediate("No Template Found", "Customer Enquiry", AssemblyName);
                    //log no ecord found for smtp
                }
              
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCCMail.Text = "Sanjeev02Saraswat@Yandex.com;Raghwendrasingh10@gmail.com;Amit.dwhfcl@gmail.com";
        }
    }
}
