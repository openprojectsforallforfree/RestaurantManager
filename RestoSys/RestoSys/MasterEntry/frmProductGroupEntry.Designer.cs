namespace RestoSys.MasterEntry
{
    partial class frmProductGroupEntry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCode = new Bsoft.Controls.VtextBox();
            this.cboGroupType = new System.Windows.Forms.ComboBox();
            this.lblfk_Group = new System.Windows.Forms.Label();
            this.txtId = new Bsoft.Controls.VtextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new Bsoft.Controls.VtextBox();
            this.txtDescription = new Bsoft.Controls.VtextBox();
            this.btnCancel = new bsoftcontrols.fsButton();
            this.btnOk = new bsoftcontrols.fsButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.FlatAppearance.BorderSize = 0;
            this._closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._closeButton.Location = new System.Drawing.Point(520, 2);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.cboGroupType);
            this.groupBox1.Controls.Add(this.lblfk_Group);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.lblDetail);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(10, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(206, 138);
            this.txtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCode.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCode.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 23);
            this.txtCode.TabIndex = 2;
            this.txtCode.ValidationType = Bsoft.Controls.VtextBox.ValidationTypeEnum.AlphaNumeric;
            this.txtCode.Value = "";
            // 
            // cboGroupType
            // 
            this.cboGroupType.FormattingEnabled = true;
            this.cboGroupType.Location = new System.Drawing.Point(206, 22);
            this.cboGroupType.Name = "cboGroupType";
            this.cboGroupType.Size = new System.Drawing.Size(260, 24);
            this.cboGroupType.TabIndex = 0;
            this.cboGroupType.SelectedIndexChanged += new System.EventHandler(this.cboGroupType_SelectedIndexChanged);
            // 
            // lblfk_Group
            // 
            this.lblfk_Group.BackColor = System.Drawing.Color.Transparent;
            this.lblfk_Group.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblfk_Group.ForeColor = System.Drawing.Color.Green;
            this.lblfk_Group.Location = new System.Drawing.Point(28, 22);
            this.lblfk_Group.Name = "lblfk_Group";
            this.lblfk_Group.Size = new System.Drawing.Size(160, 22);
            this.lblfk_Group.TabIndex = 4;
            this.lblfk_Group.Text = "Group Type:";
            this.lblfk_Group.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblfk_Group.Click += new System.EventHandler(this.lblfk_Group_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(226, 7);
            this.txtId.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtId.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(160, 23);
            this.txtId.TabIndex = 0;
            this.txtId.ValidationType = Bsoft.Controls.VtextBox.ValidationTypeEnum.No_Validation;
            this.txtId.Value = "";
            this.txtId.Visible = false;
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(28, 136);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(160, 22);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Group Code:";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetail
            // 
            this.lblDetail.BackColor = System.Drawing.Color.Transparent;
            this.lblDetail.Location = new System.Drawing.Point(203, 55);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(263, 48);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "--";
            this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(28, 167);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(160, 22);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(28, 106);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(160, 22);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Location = new System.Drawing.Point(48, 7);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(160, 22);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id:";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblId.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(206, 106);
            this.txtName.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtName.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 23);
            this.txtName.TabIndex = 1;
            this.txtName.ValidationType = Bsoft.Controls.VtextBox.ValidationTypeEnum.No_Validation;
            this.txtName.Value = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(206, 167);
            this.txtDescription.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescription.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(260, 23);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.ValidationType = Bsoft.Controls.VtextBox.ValidationTypeEnum.No_Validation;
            this.txtDescription.Value = "";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtonTheme = bsoftcontrols.fsButton.Themes.Office2003;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.Location = new System.Drawing.Point(308, 282);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeColor = System.Drawing.Color.Blue;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ButtonTheme = bsoftcontrols.fsButton.Themes.Office2003;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.Location = new System.Drawing.Point(201, 282);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 29);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.ThemeColor = System.Drawing.Color.Blue;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmProductGroupEntry
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(554, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Name = "frmProductGroupEntry";
            this.Text = "Product Group";
            this.Load += new System.EventHandler(this.frmProductGroupEntry_Load);
            this.Controls.SetChildIndex(this.lblId, 0);
            this.Controls.SetChildIndex(this._closeButton, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bsoft.Controls.VtextBox txtId;


        private Bsoft.Controls.VtextBox txtName;

        private Bsoft.Controls.VtextBox txtDescription;

        private System.Windows.Forms.Label lblId;


        private System.Windows.Forms.Label lblName;

        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Label lblCode; 
        private System.Windows.Forms.GroupBox groupBox1;
        public bsoftcontrols.fsButton btnCancel;
        public bsoftcontrols.fsButton btnOk;
        private System.Windows.Forms.ComboBox cboGroupType;
        private System.Windows.Forms.Label lblfk_Group;
        public Bsoft.Controls.VtextBox txtCode;
        private System.Windows.Forms.Label lblDetail;
    }
}
