namespace UEMS.Forms.MasterEntry
{
    partial class frmSelectVDCMunicipaListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectVDCMunicipaListView));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEditNew = new bsoftcontrols.fsButton();
            this.cmdExit = new bsoftcontrols.fsButton();
            this.cmdSelect = new bsoftcontrols.fsButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNepaliName = new System.Windows.Forms.TextBox();
            this.txtEngName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optEngLish = new System.Windows.Forms.RadioButton();
            this.optNepali = new System.Windows.Forms.RadioButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
         
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Madan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "आवश्यक अंचल, जिल्ला तथा गा.वि.स./न.पा छानेर रूजु गरी सदर गर्नुहोस्";
            // 
            // cmdEditNew
            // 
          
          
            this.cmdEditNew.ForeColor = System.Drawing.Color.MidnightBlue;
           
            this.cmdEditNew.Location = new System.Drawing.Point(373, 92);
            this.cmdEditNew.Margin = new System.Windows.Forms.Padding(0);
            this.cmdEditNew.Name = "cmdEditNew";
            this.cmdEditNew.Size = new System.Drawing.Size(180, 31);
            this.cmdEditNew.TabIndex = 3;
            this.cmdEditNew.Text = "थप/घट तथा सुधार गर्ने";
   
            this.cmdEditNew.Click += new System.EventHandler(this.cmdEditNew_Click);
            // 
            // cmdExit
            // 
           
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      
            this.cmdExit.ForeColor = System.Drawing.Color.MidnightBlue;
    
            this.cmdExit.Location = new System.Drawing.Point(301, 509);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(132, 31);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "त्यसै फर्कने";
 
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSelect
            // 
            
  
            this.cmdSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
      
            this.cmdSelect.ForeColor = System.Drawing.Color.MidnightBlue;
 
            this.cmdSelect.Location = new System.Drawing.Point(174, 509);
            this.cmdSelect.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(120, 31);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "सदर गरेर फर्कने";
 
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Madan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "नामबाट खोज्ने";
            // 
            // txtNepaliName
            // 
            this.txtNepaliName.Location = new System.Drawing.Point(389, 169);
            this.txtNepaliName.Name = "txtNepaliName";
            this.txtNepaliName.Size = new System.Drawing.Size(188, 34);
            this.txtNepaliName.TabIndex = 5;
            this.txtNepaliName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNepaliName_KeyPress);
            // 
            // txtEngName
            // 
            this.txtEngName.Font = new System.Drawing.Font("Madan",12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngName.Location = new System.Drawing.Point(389, 239);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(188, 29);
            this.txtEngName.TabIndex = 7;
            this.txtEngName.TextChanged += new System.EventHandler(this.txtEngName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Madan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "अंग्रजी नामबाट खाज्ने";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.optEngLish);
            this.groupBox2.Controls.Add(this.optNepali);
            this.groupBox2.Font = new System.Drawing.Font("Madan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(377, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 50);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "नेपाली/अंग्रेजी";
            // 
            // optEngLish
            // 
            this.optEngLish.AutoSize = true;
            this.optEngLish.Location = new System.Drawing.Point(111, 22);
            this.optEngLish.Name = "optEngLish";
            this.optEngLish.Size = new System.Drawing.Size(60, 27);
            this.optEngLish.TabIndex = 11;
            this.optEngLish.Text = "अंग्रेजी";
            this.optEngLish.UseVisualStyleBackColor = true;
            this.optEngLish.Click += new System.EventHandler(this.optEngLish_Click);
            // 
            // optNepali
            // 
            this.optNepali.AutoSize = true;
            this.optNepali.Checked = true;
            this.optNepali.Location = new System.Drawing.Point(25, 22);
            this.optNepali.Name = "optNepali";
            this.optNepali.Size = new System.Drawing.Size(61, 27);
            this.optNepali.TabIndex = 10;
            this.optNepali.TabStop = true;
            this.optNepali.Text = "नेपाली";
            this.optNepali.UseVisualStyleBackColor = true;
            this.optNepali.Click += new System.EventHandler(this.optNepali_Click);
            // 
            // treeView1
            // 
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(12, 90);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(318, 403);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
          
            this.imageList1.Images.SetKeyName(0, "NEPAL");
            this.imageList1.Images.SetKeyName(1, "vdc");
            this.imageList1.Images.SetKeyName(2, "zone");
            this.imageList1.Images.SetKeyName(3, "district");
            // 
            // frmSelectVDCMunicipaListView
            // 
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(606, 549);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtEngName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNepaliName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdEditNew);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Madan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSelectVDCMunicipaListView";
            this.Text = "ठेगानाको लागि अंचल, जिल्ला तथा गा.वि.स./न.पा.को छनौट";
            this.Load += new System.EventHandler(this.frmSelectVDCMunicipaListView_Load);
            this.Activated += new System.EventHandler(this.frmSelectVDCMunicipaListView_Activated);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSelect, 0);
            this.Controls.SetChildIndex(this.cmdExit, 0);
            this.Controls.SetChildIndex(this.cmdEditNew, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNepaliName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtEngName, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.treeView1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private bsoftcontrols.fsButton cmdEditNew;
        private bsoftcontrols.fsButton cmdExit;
        private bsoftcontrols.fsButton  cmdSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNepaliName;
        private System.Windows.Forms.TextBox txtEngName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.RadioButton optEngLish;
        public System.Windows.Forms.RadioButton optNepali;
        public System.Windows.Forms.TreeView treeView1;
    }
}
