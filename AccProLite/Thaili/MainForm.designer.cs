namespace UEMS
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBarUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.fiscYear = new System.Windows.Forms.ToolStripStatusLabel();
            this.fiscYearText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDateTodays = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDateTodaysText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSurakchyan = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRightsAssign = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChangeUserLoging = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeableDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPerson_Role = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaster_Education = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaster_Sex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaster_Position = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaster_Ethnicity = new System.Windows.Forms.ToolStripMenuItem();
            this.frameUserInfo = new System.Windows.Forms.GroupBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblOrgName = new System.Windows.Forms.Label();
            this.lblFiscalYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalBody = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.frameUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.FlatAppearance.BorderSize = 0;
            this._closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._closeButton.Location = new System.Drawing.Point(990, 2);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBarUserName,
            this.StatusBarUserName,
            this.fiscYear,
            this.fiscYearText,
            this.statusDateTodays,
            this.statusDateTodaysText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 704);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1024, 34);
            this.statusStrip1.TabIndex = 64;
            // 
            // lblStatusBarUserName
            // 
            this.lblStatusBarUserName.Font = new System.Drawing.Font("Shangrila Numeric", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBarUserName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblStatusBarUserName.Name = "lblStatusBarUserName";
            this.lblStatusBarUserName.Size = new System.Drawing.Size(98, 29);
            this.lblStatusBarUserName.Text = "संचालानकर्ता :";
            // 
            // StatusBarUserName
            // 
            this.StatusBarUserName.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBarUserName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.StatusBarUserName.Name = "StatusBarUserName";
            this.StatusBarUserName.Size = new System.Drawing.Size(21, 29);
            this.StatusBarUserName.Text = " ";
            // 
            // fiscYear
            // 
            this.fiscYear.Font = new System.Drawing.Font("Shangrila Numeric", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiscYear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.fiscYear.Name = "fiscYear";
            this.fiscYear.Size = new System.Drawing.Size(91, 29);
            this.fiscYear.Text = "आर्थिक बर्ष :";
            // 
            // fiscYearText
            // 
            this.fiscYearText.Font = new System.Drawing.Font("Shangrila Numeric", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiscYearText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.fiscYearText.Name = "fiscYearText";
            this.fiscYearText.Size = new System.Drawing.Size(13, 29);
            this.fiscYearText.Text = " ";
            // 
            // statusDateTodays
            // 
            this.statusDateTodays.Font = new System.Drawing.Font("Shangrila Numeric", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDateTodays.ForeColor = System.Drawing.Color.MidnightBlue;
            this.statusDateTodays.Name = "statusDateTodays";
            this.statusDateTodays.Size = new System.Drawing.Size(104, 29);
            this.statusDateTodays.Text = "आजको मिति :";
            // 
            // statusDateTodaysText
            // 
            this.statusDateTodaysText.Font = new System.Drawing.Font("Shangrila Numeric", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDateTodaysText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.statusDateTodaysText.Name = "statusDateTodaysText";
            this.statusDateTodaysText.Size = new System.Drawing.Size(13, 29);
            this.statusDateTodaysText.Text = " ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSurakchyan,
            this.mnuReports,
            this.mnuMasterEntry});
            this.menuStrip1.Location = new System.Drawing.Point(9, 47);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 40);
            this.menuStrip1.TabIndex = 66;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // mnuSurakchyan
            // 
            this.mnuSurakchyan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mnuSurakchyan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuRightsAssign,
            this.MnuChangePassword,
            this.MnuChangeUserLoging,
            this.toolStripMenuItem9,
            this.MnuBackup,
            this.MnuRestore,
            this.mnuChangeableDetails,
            this.toolStripSeparator13,
            this.MnuExit});
            this.mnuSurakchyan.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSurakchyan.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mnuSurakchyan.Image = global::UEMS.Properties.Resources.system;
            this.mnuSurakchyan.ImageTransparentColor = System.Drawing.Color.Lime;
            this.mnuSurakchyan.Name = "mnuSurakchyan";
            this.mnuSurakchyan.Size = new System.Drawing.Size(119, 36);
            this.mnuSurakchyan.Text = "सुरक्षण  ";
            // 
            // MnuRightsAssign
            // 
            this.MnuRightsAssign.Name = "MnuRightsAssign";
            this.MnuRightsAssign.Size = new System.Drawing.Size(235, 34);
            this.MnuRightsAssign.Text = "अधिकार प्रत्यायोजन ";
            this.MnuRightsAssign.Click += new System.EventHandler(this.MnuRightsAssign_Click);
            // 
            // MnuChangePassword
            // 
            this.MnuChangePassword.Name = "MnuChangePassword";
            this.MnuChangePassword.Size = new System.Drawing.Size(235, 34);
            this.MnuChangePassword.Text = "पासवर्द बदल्ने ";
            this.MnuChangePassword.Click += new System.EventHandler(this.MnuChangePassword_Click);
            // 
            // MnuChangeUserLoging
            // 
            this.MnuChangeUserLoging.Name = "MnuChangeUserLoging";
            this.MnuChangeUserLoging.Size = new System.Drawing.Size(235, 34);
            this.MnuChangeUserLoging.Text = "सन्चालनकर्ता बदल्ने  ";
            this.MnuChangeUserLoging.Click += new System.EventHandler(this.MnuChangeUserLoging_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(232, 6);
            // 
            // MnuBackup
            // 
            this.MnuBackup.Name = "MnuBackup";
            this.MnuBackup.Size = new System.Drawing.Size(235, 34);
            this.MnuBackup.Text = "तथ्याँक संचयन ";
            this.MnuBackup.Click += new System.EventHandler(this.MnuBackup_Click);
            // 
            // MnuRestore
            // 
            this.MnuRestore.Name = "MnuRestore";
            this.MnuRestore.Size = new System.Drawing.Size(235, 34);
            this.MnuRestore.Text = "तथ्याँक पुनर्लेखन  ";
            this.MnuRestore.Click += new System.EventHandler(this.MnuRestore_Click);
            // 
            // mnuChangeableDetails
            // 
            this.mnuChangeableDetails.Name = "mnuChangeableDetails";
            this.mnuChangeableDetails.Size = new System.Drawing.Size(235, 34);
            this.mnuChangeableDetails.Text = "परिवर्तनीय सुचक";
            this.mnuChangeableDetails.Click += new System.EventHandler(this.mnuChangeableDetails_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(232, 6);
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(235, 34);
            this.MnuExit.Text = "बाहिर जाने ";
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuReports.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuReports.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mnuReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(89, 36);
            this.mnuReports.Text = "प्रतिवेदन ";
            this.mnuReports.Visible = false;
            // 
            // mnuMasterEntry
            // 
            this.mnuMasterEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator10,
            this.mnuPerson_Role,
            this.mnuPersonDetail});
            this.mnuMasterEntry.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mnuMasterEntry.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mnuMasterEntry.Name = "mnuMasterEntry";
            this.mnuMasterEntry.Size = new System.Drawing.Size(121, 36);
            this.mnuMasterEntry.Text = "Master Entries";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuPerson_Role
            // 
            this.mnuPerson_Role.Enabled = false;
            this.mnuPerson_Role.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPerson_Role.Name = "mnuPerson_Role";
            this.mnuPerson_Role.Size = new System.Drawing.Size(198, 34);
            this.mnuPerson_Role.Text = "Member";
            this.mnuPerson_Role.Visible = false;
            // 
            // mnuPersonDetail
            // 
            this.mnuPersonDetail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMaster_Education,
            this.mnuMaster_Sex,
            this.mnuMaster_Position,
            this.mnuMaster_Ethnicity});
            this.mnuPersonDetail.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPersonDetail.Name = "mnuPersonDetail";
            this.mnuPersonDetail.Size = new System.Drawing.Size(198, 34);
            this.mnuPersonDetail.Text = "ब्यक्तिका विवरण ";
            // 
            // mnuMaster_Education
            // 
            this.mnuMaster_Education.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMaster_Education.Name = "mnuMaster_Education";
            this.mnuMaster_Education.Size = new System.Drawing.Size(152, 34);
            this.mnuMaster_Education.Text = "शिक्षा ";
            // 
            // mnuMaster_Sex
            // 
            this.mnuMaster_Sex.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMaster_Sex.Name = "mnuMaster_Sex";
            this.mnuMaster_Sex.Size = new System.Drawing.Size(152, 34);
            this.mnuMaster_Sex.Text = "लिंग";
            // 
            // mnuMaster_Position
            // 
            this.mnuMaster_Position.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMaster_Position.Name = "mnuMaster_Position";
            this.mnuMaster_Position.Size = new System.Drawing.Size(152, 34);
            this.mnuMaster_Position.Text = "पद";
            // 
            // mnuMaster_Ethnicity
            // 
            this.mnuMaster_Ethnicity.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMaster_Ethnicity.Name = "mnuMaster_Ethnicity";
            this.mnuMaster_Ethnicity.Size = new System.Drawing.Size(152, 34);
            this.mnuMaster_Ethnicity.Text = "जाति";
            // 
            // frameUserInfo
            // 
            this.frameUserInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frameUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.frameUserInfo.Controls.Add(this.lblDistrict);
            this.frameUserInfo.Controls.Add(this.lblOrgName);
            this.frameUserInfo.Controls.Add(this.lblFiscalYear);
            this.frameUserInfo.Controls.Add(this.label2);
            this.frameUserInfo.Controls.Add(this.lblLocalBody);
            this.frameUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frameUserInfo.ForeColor = System.Drawing.Color.FloralWhite;
            this.frameUserInfo.Location = new System.Drawing.Point(127, 256);
            this.frameUserInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.frameUserInfo.Name = "frameUserInfo";
            this.frameUserInfo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.frameUserInfo.Size = new System.Drawing.Size(771, 282);
            this.frameUserInfo.TabIndex = 68;
            this.frameUserInfo.TabStop = false;
            this.frameUserInfo.Text = "प्रयोगाधिकार";
            // 
            // lblDistrict
            // 
            this.lblDistrict.Font = new System.Drawing.Font("Shangrila Numeric", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDistrict.Location = new System.Drawing.Point(6, 99);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(766, 37);
            this.lblDistrict.TabIndex = 8;
            this.lblDistrict.Text = "nlntk\'<,";
            this.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrgName
            // 
            this.lblOrgName.AutoSize = true;
            this.lblOrgName.Font = new System.Drawing.Font("Shangrila Numeric", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrgName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblOrgName.Location = new System.Drawing.Point(283, 21);
            this.lblOrgName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(216, 32);
            this.lblOrgName.TabIndex = 2;
            this.lblOrgName.Text = "gu<kflnsf sfof{no";
            this.lblOrgName.Visible = false;
            // 
            // lblFiscalYear
            // 
            this.lblFiscalYear.AutoSize = true;
            this.lblFiscalYear.Font = new System.Drawing.Font("Shangrila Numeric", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiscalYear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFiscalYear.Location = new System.Drawing.Point(406, 192);
            this.lblFiscalYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiscalYear.Name = "lblFiscalYear";
            this.lblFiscalYear.Size = new System.Drawing.Size(160, 37);
            this.lblFiscalYear.TabIndex = 1;
            this.lblFiscalYear.Text = "2065/2066";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mangal", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(228, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 59);
            this.label2.TabIndex = 0;
            this.label2.Text = "आर्थिक वर्ष:";
            // 
            // lblLocalBody
            // 
            this.lblLocalBody.Font = new System.Drawing.Font("Shangrila Numeric", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalBody.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLocalBody.Location = new System.Drawing.Point(0, 59);
            this.lblLocalBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalBody.Name = "lblLocalBody";
            this.lblLocalBody.Size = new System.Drawing.Size(771, 37);
            this.lblLocalBody.TabIndex = 3;
            this.lblLocalBody.Text = "w<fg";
            this.lblLocalBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitle
            // 
            this.LblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Mangal", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblTitle.Location = new System.Drawing.Point(2, 200);
            this.LblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1020, 59);
            this.LblTitle.TabIndex = 67;
            this.LblTitle.Text = "गैर - सरकारी संस्था व्यवस्थापन प्रणाली ";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(1024, 738);
            this.Controls.Add(this.frameUserInfo);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = false;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "गैर - सरकारी संस्था व्यवस्थापन प्रणाली ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this._closeButton, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.LblTitle, 0);
            this.Controls.SetChildIndex(this.frameUserInfo, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.frameUserInfo.ResumeLayout(false);
            this.frameUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBarUserName;
        private System.Windows.Forms.ToolStripStatusLabel fiscYear;
        private System.Windows.Forms.ToolStripMenuItem mnuSurakchyan;
        private System.Windows.Forms.ToolStripMenuItem MnuRightsAssign;
        private System.Windows.Forms.ToolStripMenuItem MnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem MnuChangeUserLoging;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem MnuBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.GroupBox frameUserInfo;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblOrgName;
        private System.Windows.Forms.Label lblFiscalYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalBody;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeableDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterEntry;
        private System.Windows.Forms.ToolStripMenuItem mnuPerson_Role;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster_Education;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster_Sex;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster_Position;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster_Ethnicity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripStatusLabel statusDateTodays;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarUserName;
        private System.Windows.Forms.ToolStripMenuItem MnuRestore;
        private System.Windows.Forms.ToolStripStatusLabel fiscYearText;
        private System.Windows.Forms.ToolStripStatusLabel statusDateTodaysText;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}
