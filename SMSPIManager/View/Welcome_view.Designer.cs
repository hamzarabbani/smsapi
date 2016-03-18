namespace SMSPIManager
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
            this.labelHorizontalLine = new System.Windows.Forms.Label();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.buttonToggle = new MetroFramework.Controls.MetroToggle();
            this.buttonLogs = new MetroFramework.Controls.MetroButton();
            this.textboxStatus = new MetroFramework.Controls.MetroTextBox();
            this.textboxAddMobile = new MetroFramework.Controls.MetroTextBox();
            this.listboxMobileList = new System.Windows.Forms.ListBox();
            this.textboxMobileNumbers = new MetroFramework.Controls.MetroTextBox();
            this.buttonSendMessage = new MetroFramework.Controls.MetroButton();
            this.textboxMessage = new MetroFramework.Controls.MetroTextBox();
            this.buttonAdd = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // labelHorizontalLine
            // 
            this.labelHorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHorizontalLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelHorizontalLine.Location = new System.Drawing.Point(-1, 114);
            this.labelHorizontalLine.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelHorizontalLine.Name = "labelHorizontalLine";
            this.labelHorizontalLine.Size = new System.Drawing.Size(793, 1);
            this.labelHorizontalLine.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 76);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Server:";
            // 
            // buttonToggle
            // 
            this.buttonToggle.AutoSize = true;
            this.buttonToggle.Location = new System.Drawing.Point(607, 78);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(80, 17);
            this.buttonToggle.TabIndex = 2;
            this.buttonToggle.Text = "Off";
            this.buttonToggle.UseSelectable = true;
            this.buttonToggle.CheckedChanged += new System.EventHandler(this.buttonToggle_CheckedChanged);
            // 
            // buttonLogs
            // 
            this.buttonLogs.Location = new System.Drawing.Point(693, 76);
            this.buttonLogs.Name = "buttonLogs";
            this.buttonLogs.Size = new System.Drawing.Size(75, 19);
            this.buttonLogs.TabIndex = 4;
            this.buttonLogs.Text = "Logs";
            this.buttonLogs.UseSelectable = true;
            this.buttonLogs.Click += new System.EventHandler(this.buttonLogs_Click);
            // 
            // textboxStatus
            // 
            this.textboxStatus.Lines = new string[0];
            this.textboxStatus.Location = new System.Drawing.Point(23, 307);
            this.textboxStatus.MaxLength = 32767;
            this.textboxStatus.Multiline = true;
            this.textboxStatus.Name = "textboxStatus";
            this.textboxStatus.PasswordChar = '\0';
            this.textboxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textboxStatus.SelectedText = "";
            this.textboxStatus.Size = new System.Drawing.Size(745, 127);
            this.textboxStatus.Style = MetroFramework.MetroColorStyle.Yellow;
            this.textboxStatus.TabIndex = 5;
            this.textboxStatus.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textboxStatus.UseSelectable = true;
            // 
            // textboxAddMobile
            // 
            this.textboxAddMobile.Lines = new string[0];
            this.textboxAddMobile.Location = new System.Drawing.Point(23, 128);
            this.textboxAddMobile.MaxLength = 32767;
            this.textboxAddMobile.Name = "textboxAddMobile";
            this.textboxAddMobile.PasswordChar = '\0';
            this.textboxAddMobile.PromptText = "Ex. 192.168.8.101";
            this.textboxAddMobile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textboxAddMobile.SelectedText = "";
            this.textboxAddMobile.Size = new System.Drawing.Size(190, 23);
            this.textboxAddMobile.TabIndex = 6;
            this.textboxAddMobile.UseSelectable = true;
            // 
            // listboxMobileList
            // 
            this.listboxMobileList.FormattingEnabled = true;
            this.listboxMobileList.HorizontalScrollbar = true;
            this.listboxMobileList.Location = new System.Drawing.Point(23, 157);
            this.listboxMobileList.Name = "listboxMobileList";
            this.listboxMobileList.Size = new System.Drawing.Size(271, 108);
            this.listboxMobileList.TabIndex = 8;
            // 
            // textboxMobileNumbers
            // 
            this.textboxMobileNumbers.Lines = new string[0];
            this.textboxMobileNumbers.Location = new System.Drawing.Point(469, 128);
            this.textboxMobileNumbers.MaxLength = 32767;
            this.textboxMobileNumbers.Multiline = true;
            this.textboxMobileNumbers.Name = "textboxMobileNumbers";
            this.textboxMobileNumbers.PasswordChar = '\0';
            this.textboxMobileNumbers.PromptText = "Ex. 03001234567";
            this.textboxMobileNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textboxMobileNumbers.SelectedText = "";
            this.textboxMobileNumbers.Size = new System.Drawing.Size(218, 23);
            this.textboxMobileNumbers.TabIndex = 9;
            this.textboxMobileNumbers.UseSelectable = true;
            this.textboxMobileNumbers.Click += new System.EventHandler(this.textboxMobileNumbers_Click);
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(693, 128);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMessage.TabIndex = 11;
            this.buttonSendMessage.Text = "Send";
            this.buttonSendMessage.Theme = MetroFramework.MetroThemeStyle.Light;
            this.buttonSendMessage.UseSelectable = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textboxMessage
            // 
            this.textboxMessage.Lines = new string[0];
            this.textboxMessage.Location = new System.Drawing.Point(469, 157);
            this.textboxMessage.MaxLength = 32767;
            this.textboxMessage.Multiline = true;
            this.textboxMessage.Name = "textboxMessage";
            this.textboxMessage.PasswordChar = '\0';
            this.textboxMessage.PromptText = "Message....";
            this.textboxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textboxMessage.SelectedText = "";
            this.textboxMessage.Size = new System.Drawing.Size(299, 108);
            this.textboxMessage.TabIndex = 10;
            this.textboxMessage.UseSelectable = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(219, 128);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Theme = MetroFramework.MetroThemeStyle.Light;
            this.buttonAdd.UseSelectable = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 285);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(46, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 457);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textboxMessage);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.textboxMobileNumbers);
            this.Controls.Add(this.listboxMobileList);
            this.Controls.Add(this.textboxAddMobile);
            this.Controls.Add(this.textboxStatus);
            this.Controls.Add(this.buttonLogs);
            this.Controls.Add(this.buttonToggle);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.labelHorizontalLine);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "SMS Control Panel v1.1";
            this.TransparencyKey = System.Drawing.Color.Navy;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHorizontalLine;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton buttonLogs;
        private MetroFramework.Controls.MetroTextBox textboxAddMobile;
        private MetroFramework.Controls.MetroTextBox textboxMobileNumbers;
        private MetroFramework.Controls.MetroButton buttonSendMessage;
        public MetroFramework.Controls.MetroTextBox textboxStatus;
        private MetroFramework.Controls.MetroTextBox textboxMessage;
        private MetroFramework.Controls.MetroButton buttonAdd;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.ListBox listboxMobileList;
        public MetroFramework.Controls.MetroToggle buttonToggle;
    }
}

