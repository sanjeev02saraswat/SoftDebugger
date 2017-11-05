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
            this.txtMailTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCCMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstContent = new System.Windows.Forms.TextBox();
            this.txtSecondContent = new System.Windows.Forms.TextBox();
            this.txtcontent3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // txtMailTo
            // 
            this.txtMailTo.Location = new System.Drawing.Point(248, 24);
            this.txtMailTo.Name = "txtMailTo";
            this.txtMailTo.Size = new System.Drawing.Size(222, 20);
            this.txtMailTo.TabIndex = 1;
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
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Content";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Second Content";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Third Content";
            // 
            // txtFirstContent
            // 
            this.txtFirstContent.Location = new System.Drawing.Point(248, 138);
            this.txtFirstContent.Multiline = true;
            this.txtFirstContent.Name = "txtFirstContent";
            this.txtFirstContent.Size = new System.Drawing.Size(222, 64);
            this.txtFirstContent.TabIndex = 7;
            // 
            // txtSecondContent
            // 
            this.txtSecondContent.Location = new System.Drawing.Point(248, 208);
            this.txtSecondContent.Multiline = true;
            this.txtSecondContent.Name = "txtSecondContent";
            this.txtSecondContent.Size = new System.Drawing.Size(222, 64);
            this.txtSecondContent.TabIndex = 8;
            // 
            // txtcontent3
            // 
            this.txtcontent3.Location = new System.Drawing.Point(248, 297);
            this.txtcontent3.Multiline = true;
            this.txtcontent3.Name = "txtcontent3";
            this.txtcontent3.Size = new System.Drawing.Size(222, 64);
            this.txtcontent3.TabIndex = 9;
            this.txtcontent3.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "SEND EMAIL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 471);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtcontent3);
            this.Controls.Add(this.txtSecondContent);
            this.Controls.Add(this.txtFirstContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCCMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMailTo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCCMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstContent;
        private System.Windows.Forms.TextBox txtSecondContent;
        private System.Windows.Forms.TextBox txtcontent3;
        private System.Windows.Forms.Button button1;
    }
}

