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
            if (string.IsNullOrEmpty(txtFirstContent.Text.ToString()))
            {
                MessageBox.Show("Please fill all required details..");
            }
            else
            {

                string bodyhtml = @"<html>
<head>
<style type='text/css'>
div, p, a, li, td {
	-webkit-text-size-adjust:none;
}
.ReadMsgBody {
	width: 100%;
	background-color: #d1d1d1;
}
.ExternalClass {
	width: 100%;
	background-color: #d1d1d1;
	line-height:100%;
}
body {
	width: 100%;
	height: 100%;
	background-color: #d1d1d1;
	margin:0;
	padding:0;
	-webkit-font-smoothing: antialiased;
	-webkit-text-size-adjust:100%;
}
html {
	width: 100%;
}
img {
	-ms-interpolation-mode:bicubic;
}
table[class=full] {
	padding:0 !important;
	border:none !important;
}
table td img[class=imgresponsive] {
	width:100% !important;
	height:auto !important;
	display:block !important;
}
@media only screen and (max-width: 800px) {
body {
 width:auto!important;
}
table[class=full] {
 width:100%!important;
}
table[class=devicewidth] {
 width:100% !important;
 padding-left:20px !important;
 padding-right: 20px!important;
}
table td img.responsiveimg {
 width:100% !important;
 height:auto !important;
 display:block !important;
}
}
@media only screen and (max-width: 640px) {
table[class=devicewidth] {
 width:100% !important;
}
table[class=inner] {
 width:100%!important;
 text-align: center!important;
 clear: both;
}
table td a[class=top-button] {
 width:160px !important;
  font-size:14px !important;
 line-height:37px !important;
}
table td[class=readmore-button] {
 text-align:center !important;
}
table td[class=readmore-button] a {
 float:none !important;
 display:inline-block !important;
}
.hide {
 display:none !important;
}
table td[class=smallfont] {
 border:none !important;
 font-size:26px !important;
}
table td[class=sidespace] {
 width:10px !important;
}
}
 @media only screen and (max-width: 520px) {
}
@media only screen and (max-width: 480px) {

 table {
 border-collapse: collapse;
}
table td[class=template-img] img {
 width:100% !important;
 display:block !important;
}
}
@media only screen and (max-width: 320px) {
}
</style>
</head>

<body>
<table width='100%' border='0' cellspacing='0' cellpadding='0' class='full'>
  <tbody><tr>
    <td align='center'><table width='600' border='0' cellspacing='0' cellpadding='0' align='center' class='devicewidth'>
        <tbody><tr>
          <td><table width='100%' bgcolor='#ffffff' border='0' cellspacing='0' cellpadding='0' align='center' class='full' style='background-color:#ffffff;'>
              <tbody><tr>
                <td height='23'>&nbsp;</td>
              </tr>
              <tr>
                <td><table width='100%' border='0' cellspacing='0' cellpadding='0' align='center'>
                    <tbody><tr>
                      <td width='23' class='sidespace'>&nbsp;</td>
                      <td><table width='76%' border='0' cellspacing='0' cellpadding='0' align='left' class='inner' id='banner' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
                          <tbody>
						  <tr><td><a href='http://www.SoftDebugger.Com/'><img src='https://4.downloader.disk.yandex.ru/preview/7406790c0fe271af3cc851e2172dc72cdca67c34b7c48dd0d08df0dd52cce1e9/inf/33Jr3Ua0Z_0VfnnL-WhbfiTPqRoQqkbFhWYiPJiauDJVDs0GAgIRMpqHn5UL9bSbAcK_csl8MVz0h8o7od380g%3D%3D?uid=0&filename=logo.JPG&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&size=XXL&crop=0' height='100px' width='100px' /></a></td></tr>
						  <tr>
                            <td style='font:bold 27px Arial, Helvetica, sans-serif; border-right:1px solid #dbdbdb;' class='smallfont'>SoftDebugger Ticketing Notification-"+txtFirstContent.Text+@"</td>
                          </tr>
                          <tr>
                            <td height='20'>&nbsp;</td>
                          </tr>
                        </tbody></table>
                        <table width='22%' border='0' cellspacing='0' cellpadding='0' align='right' class='inner' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;'>
                          <tbody><tr>
                               <td align='center'><a href='#' style='margin-top:5px; display:inline-block;'><img src='https://s1.postimg.org/9en7r4vlfj/facebook.png' width='32' height='atuo' alt='Social Media'></a></td>
                            <td align='center'><a href='#' style='margin-top:5px; display:inline-block;'><img src='https://s1.postimg.org/65o3uh8bin/google.png' width='32' height='atuo' alt='Social Media'></a></td>
                            <td align='center'><a href='#' style='margin-top:5px; display:inline-block;'><img src='https://s1.postimg.org/20siidaq0f/twitter.png' width='32' height='atuo' alt='Social Media'></a></td>
                          </tr>
                          <tr>
                            <td height='20'>&nbsp;</td>
                            <td height='20'>&nbsp;</td>
                            <td height='20'>&nbsp;</td>
                          </tr>
                        </tbody></table></td>
                      <td width='23' class='sidespace'>&nbsp;</td>
                    </tr>
                  </tbody></table>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0' align='center'>
                    <tbody><tr>
                      <td width='3.33%' class='sidespace'>&nbsp;</td>
                      <td width='93.33%'><img class='imgresponsive' src='https://s1.postimg.org/8iqqbol9u7/banner.jpg' width='554' height='atuo' alt='Banner'></td>
                      <td width='3.33%' class='sidespace'>&nbsp;</td>
                    </tr>
                    <tr>
                      <td height='20'>&nbsp;</td>
                      <td height='20'>&nbsp;</td>
                      <td height='20'>&nbsp;</td>
                    </tr>
                  </tbody></table>
                  <table width='100%' border='0' cellspacing='0' cellpadding='0' align='center'>
                    <tbody><tr>
                      <td width='23' class='sidespace'>&nbsp;</td>
                      <td>
                        <table width='100%' border='0' cellspacing='0' cellpadding='0' align='right' class='inner'>
                          <tbody><tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>
							
							Dear "+cmbAssignTo.SelectedItem.ToString()+@",<br/><br/>
							Below Ticket has been "+ cmbTicketMainStatus.SelectedItem.ToString()+@" for You.
							Please find Ticket Description.
							</td>
                          </tr>
						  <tr>
                             <td height='20'>&nbsp;</td>
                          </tr>
						  <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Ticket ID
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+txtFirstContent.Text+@"</td>
                          </tr>
						  <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Task Name
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+txtTaskName.Text+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Project Name
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbProjectName.SelectedItem.ToString()+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Assign To
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbAssignTo.SelectedItem.ToString()+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Priority
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbPriority.SelectedItem.ToString()+@"
							</td>
                          </tr>
						     <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Start Date
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+tskStartDate.Value.ToString()+@"
							</td>
                          </tr>
						     <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>End Date
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+tskEndDate.Value.ToString()+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>DB Changes
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbDBChanges.SelectedItem.ToString()+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Meeting Required
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbMeeting.SelectedItem.ToString()+@"
							</td>
                          </tr>
						   <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Ticket Status
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+cmbTicketMainStatus.SelectedItem.ToString()+@"
							</td>
                          </tr>
						   <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Close Date
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+ DateTicketCloseddate.Value.ToString()+ @"
							</td>
                          </tr>
						     <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Task Estimation
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+txtEstimateDays.Text.ToString()+@"
							</td>
                          </tr>
						    <tr>
                            <td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>Task Feedback
							</td><td style='font:14px/19px Arial, Helvetica, sans-serif; color:#333332;'>"+txtTaskFeedback.Text.ToString()+@"
							</td>
                          </tr>
                          <tr>
                            <td height='20'>&nbsp;</td>
                          </tr>
                          <tr>
                            <td align='left' class='readmore-button'><a href='#' style='font:bold 12px/29px Arial, Helvetica, sans-serif; color:#ffffff; text-decoration:none; background:#16c4a9; float:left; padding:0 19px; border-radius:24px; text-transform:uppercase;'>Thanks<br/>SoftDebugger Team</a></td>
                          </tr>
                        </tbody></table></td>
                      <td width='23' class='sidespace'>&nbsp;</td>
                    </tr>
                    <tr>
                      <td height='16'>&nbsp;</td>
                      <td height='16'>&nbsp;</td>
                      <td height='16'>&nbsp;</td>
                    </tr>
                  </tbody></table></td>
              </tr>
              <tr>
                <td style='border-bottom:1px solid #dbdbdb;'>&nbsp;</td>
              </tr>
            </tbody></table></td>
        </tr>
      </tbody></table></td>
  </tr>
</tbody></table>
</body>
</html>";
                //DataSet ds = null;
                //using (SqlConnection scon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWebsite"].ToString()))
                //{
                //    using (SqlCommand scmd = new SqlCommand("GetMailTeplate", scon))
                //    {
                //        scmd.CommandType = CommandType.StoredProcedure;
                //        scmd.Parameters.AddWithValue("@ApplicationName", "SoftDebugger");
                //        scmd.Parameters.AddWithValue("@MailType", "TicketSender");
                //        SqlDataAdapter da = new SqlDataAdapter(scmd);
                //        ds = new DataSet();
                //        da.Fill(ds);

                //    }
                //}
                string MailSubject ="Ticket-"+txtFirstContent.Text.ToString()+" has been "+cmbTicketMainStatus.SelectedItem.ToString()+".";
                string MailBody = bodyhtml;
                //if (ds != null && ds.Tables.Count > 0)
                //{
                //    MailSubject = ds.Tables[0].Rows[0]["MAILSUBJECT"].ToString();
                //    MailBody = ds.Tables[0].Rows[0]["MAILBODY"].ToString();
                //    string updatedMailBody = "";// MailBody.Replace("MailFirst", txtFirstContent.Text).Replace("MailSecound", txtSecondContent.Text).Replace("MailThird", txtcontent3.Text);
                    SendMail.SendMail objSendMail = new SendMail.SendMail();
                    bool status = objSendMail.SendMailtoUser(cmbmailto.SelectedItem.ToString(), MailSubject, MailBody, txtCCMail.Text,true);
                    if (status)
                    {
                        MessageBox.Show("Message sent successfully...");

                    }else { MessageBox.Show("Message could not sent successfully..."); }
                //}
                //else
                //{
                //   // SoftLogger.SoftLogger.WriteLogImmediate("No Template Found", "Customer Enquiry", AssemblyName);
                //    //log no ecord found for smtp
                //}
              
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbmailto.Items.Add("Sanjeev02Saraswat@Yandex.Com");
            cmbmailto.Items.Add("RaghwendraSingh10@gmail.com");
            cmbmailto.Items.Add("Amit.Dwhfcl@gmail.com");
            cmbmailto.Items.Add("Developer.SoftDebugger@gmail.com");
            txtCCMail.Text = "Sanjeev02Saraswat@Yandex.com;Raghwendrasingh10@gmail.com;Amit.dwhfcl@gmail.com";
        }

       
    }
}
