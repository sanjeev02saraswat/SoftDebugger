namespace MailSender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCCMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstContent = new System.Windows.Forms.TextBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbmailto = new System.Windows.Forms.ComboBox();
            this.cmbProjectName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAssignTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tskStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tskEndDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDBChanges = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTaskFeedback = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTicketMainStatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DateTicketCloseddate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEstimateDays = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Send To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CC Mail(;)";
            // 
            // txtCCMail
            // 
            this.txtCCMail.Location = new System.Drawing.Point(248, 77);
            this.txtCCMail.Name = "txtCCMail";
            this.txtCCMail.Size = new System.Drawing.Size(222, 20);
            this.txtCCMail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ticket ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Task Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Project Name";
            // 
            // txtFirstContent
            // 
            this.txtFirstContent.Location = new System.Drawing.Point(248, 138);
            this.txtFirstContent.Multiline = true;
            this.txtFirstContent.Name = "txtFirstContent";
            this.txtFirstContent.Size = new System.Drawing.Size(222, 20);
            this.txtFirstContent.TabIndex = 7;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(248, 208);
            this.txtTaskName.Multiline = true;
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(222, 64);
            this.txtTaskName.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(374, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "SEND EMAIL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbmailto
            // 
            this.cmbmailto.FormattingEnabled = true;
            this.cmbmailto.Location = new System.Drawing.Point(248, 31);
            this.cmbmailto.Name = "cmbmailto";
            this.cmbmailto.Size = new System.Drawing.Size(222, 21);
            this.cmbmailto.TabIndex = 11;
            // 
            // cmbProjectName
            // 
            this.cmbProjectName.FormattingEnabled = true;
            this.cmbProjectName.Items.AddRange(new object[] {
            "SoftDebugger",
            "PackageModule"});
            this.cmbProjectName.Location = new System.Drawing.Point(257, 331);
            this.cmbProjectName.Name = "cmbProjectName";
            this.cmbProjectName.Size = new System.Drawing.Size(222, 21);
            this.cmbProjectName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Assign to";
            // 
            // cmbAssignTo
            // 
            this.cmbAssignTo.FormattingEnabled = true;
            this.cmbAssignTo.Items.AddRange(new object[] {
            "Sanjeev Saraswat",
            "Raghwendra Singh",
            "Amit Pratap Singh"});
            this.cmbAssignTo.Location = new System.Drawing.Point(593, 36);
            this.cmbAssignTo.Name = "cmbAssignTo";
            this.cmbAssignTo.Size = new System.Drawing.Size(222, 21);
            this.cmbAssignTo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(537, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Urgent",
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(593, 77);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(222, 21);
            this.cmbPriority.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(537, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Start Date";
            // 
            // tskStartDate
            // 
            this.tskStartDate.Location = new System.Drawing.Point(603, 132);
            this.tskStartDate.Name = "tskStartDate";
            this.tskStartDate.Size = new System.Drawing.Size(200, 20);
            this.tskStartDate.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "End Date";
            // 
            // tskEndDate
            // 
            this.tskEndDate.Location = new System.Drawing.Point(603, 182);
            this.tskEndDate.Name = "tskEndDate";
            this.tskEndDate.Size = new System.Drawing.Size(200, 20);
            this.tskEndDate.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(537, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Db Changes";
            // 
            // cmbDBChanges
            // 
            this.cmbDBChanges.FormattingEnabled = true;
            this.cmbDBChanges.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbDBChanges.Location = new System.Drawing.Point(609, 227);
            this.cmbDBChanges.Name = "cmbDBChanges";
            this.cmbDBChanges.Size = new System.Drawing.Size(216, 21);
            this.cmbDBChanges.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(523, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Meeting Required";
            // 
            // cmbMeeting
            // 
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbMeeting.Location = new System.Drawing.Point(620, 291);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(230, 21);
            this.cmbMeeting.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(532, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Task Feedback";
            // 
            // txtTaskFeedback
            // 
            this.txtTaskFeedback.Location = new System.Drawing.Point(620, 331);
            this.txtTaskFeedback.Multiline = true;
            this.txtTaskFeedback.Name = "txtTaskFeedback";
            this.txtTaskFeedback.Size = new System.Drawing.Size(222, 64);
            this.txtTaskFeedback.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(887, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Ticket Status";
            // 
            // cmbTicketMainStatus
            // 
            this.cmbTicketMainStatus.FormattingEnabled = true;
            this.cmbTicketMainStatus.Items.AddRange(new object[] {
            "Open",
            "Updated",
            "Closed"});
            this.cmbTicketMainStatus.Location = new System.Drawing.Point(963, 33);
            this.cmbTicketMainStatus.Name = "cmbTicketMainStatus";
            this.cmbTicketMainStatus.Size = new System.Drawing.Size(222, 21);
            this.cmbTicketMainStatus.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(887, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Close Date";
            // 
            // DateTicketCloseddate
            // 
            this.DateTicketCloseddate.Location = new System.Drawing.Point(979, 78);
            this.DateTicketCloseddate.Name = "DateTicketCloseddate";
            this.DateTicketCloseddate.Size = new System.Drawing.Size(200, 20);
            this.DateTicketCloseddate.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(846, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Task Estimation(in Days)";
            // 
            // txtEstimateDays
            // 
            this.txtEstimateDays.Location = new System.Drawing.Point(975, 129);
            this.txtEstimateDays.Name = "txtEstimateDays";
            this.txtEstimateDays.Size = new System.Drawing.Size(222, 20);
            this.txtEstimateDays.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 560);
            this.Controls.Add(this.txtEstimateDays);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.DateTicketCloseddate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbTicketMainStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTaskFeedback);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbMeeting);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbDBChanges);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tskEndDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tskStartDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbAssignTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbProjectName);
            this.Controls.Add(this.cmbmailto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.txtFirstContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCCMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCCMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstContent;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbmailto;
        private System.Windows.Forms.ComboBox cmbProjectName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAssignTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker tskStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker tskEndDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDBChanges;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTaskFeedback;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTicketMainStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DateTicketCloseddate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEstimateDays;
    }
}

